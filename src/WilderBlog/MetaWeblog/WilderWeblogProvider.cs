using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WilderBlog.Config;
using WilderBlog.Data;
using WilderBlog.Helpers;
using WilderBlog.Services;
using WilderMinds.AzureImageStorageService;
using WilderMinds.MetaWeblog;

namespace WilderBlog.MetaWeblog
{
  public class WilderWeblogProvider : IMetaWeblogProvider
  {
    private const string CONTAINER_NAME = "img";
    private IWilderRepository _repo;
    private UserManager<WilderUser> _userMgr;
    private IHostEnvironment _appEnv;
    private readonly IAzureImageStorageService _imageService;
    private readonly ILogger<WilderWeblogProvider> _logger;

    public WilderWeblogProvider(UserManager<WilderUser> userMgr, 
      IWilderRepository repo, 
      IHostEnvironment appEnv, 
      IAzureImageStorageService imageService, 
      ILogger<WilderWeblogProvider> logger)
    {
      _repo = repo;
      _userMgr = userMgr;
      _appEnv = appEnv;
      _imageService = imageService;
      _logger = logger;
    }

    public async Task<string> AddPostAsync(string blogid, string username, string password, Post post, bool publish)
    {
      await EnsureUser(username, password);

      if (post.categories == null) throw new MetaWeblogException("Failed to specify categories");

      var newStory = new BlogStory();
      try
      {
        newStory.Title = post.title;
        newStory.Body = post.description;
        newStory.DatePublished = post.dateCreated == DateTime.MinValue ? DateTime.UtcNow : post.dateCreated;
        if (post.categories != null) newStory.Categories = string.Join(",", post.categories);
        newStory.IsPublished = publish;
        newStory.Slug = newStory.GetStoryUrl();
        newStory.UniqueId = newStory.Slug;
        newStory.FeatureImageUrl = post?.wp_post_thumbnail;
        newStory.Abstract = newStory.GetSummary();

        _repo.AddStory(newStory);
        if (await _repo.SaveAllAsync())
        {
          return newStory.Id.ToString();

        }
      }
      catch (Exception)
      {
        _logger.LogError("Failed to add new Post");
      }

      throw new MetaWeblogException("Failed to save the post.");
    }

    public async Task<bool> EditPostAsync(string postid, string username, string password, Post post, bool publish)
    {
      await EnsureUser(username, password);

      if (post.categories == null) throw new MetaWeblogException("Failed to specify categories");

      try
      {
        var story = await _repo.GetStory(int.Parse(postid));

        story.Title = post.title;
        story.Body = post.description;
        if (post.dateCreated == DateTime.MinValue) story.DatePublished = DateTime.UtcNow; // Only overwrite date if is empty
        story.Categories = string.Join(",", post.categories);
        story.IsPublished = publish;
        if (string.IsNullOrWhiteSpace(story.Slug)) story.Slug = story.GetStoryUrl(); // Only recalcuate Slug if absolutely necessary
        story.FeatureImageUrl = post?.wp_post_thumbnail;
        story.Abstract = story.GetSummary();

        if (await _repo.SaveAllAsync())
        {
          return true;
        }
      }
      catch (Exception)
      {
        _logger.LogError("Failed to edit the post.");
      }

      throw new MetaWeblogException("Failed to edit the post.");
    }

    public async Task<Post> GetPostAsync(string postid, string username, string password)
    {
      await EnsureUser(username, password);

      try
      {
        var story = await _repo.GetStory(int.Parse(postid));
        var newPost = new Post()
        {
          title = story.Title,
          description = story.Body,
          dateCreated = story.DatePublished,
          categories = story.Categories.Split(','),
          postid = story.Id,
          userid = "shawnwildermuth",
          wp_slug = story.GetStoryUrl(),
          wp_post_thumbnail = story.FeatureImageUrl
        };

        return newPost;
      }
      catch (Exception)
      {
        throw new MetaWeblogException("Failed to get the post.");
      }
    }

    public async Task<MediaObjectInfo> NewMediaObjectAsync(string blogid, string username, string password, MediaObject mediaObject)
    {
      await EnsureUser(username, password);

      var bits = Convert.FromBase64String(mediaObject.bits);
      var result = await _imageService.StoreImage(CONTAINER_NAME, mediaObject.name, bits);

      if (result.Success)
      {
        var url = result.ImageUrl;

        // Create the response
        MediaObjectInfo objectInfo = new MediaObjectInfo();
        objectInfo.url = url;

        return objectInfo;
      }

      throw new MetaWeblogException("Failed to upload Media Object");
    }

    public async Task<CategoryInfo[]> GetCategoriesAsync(string blogid, string username, string password)
    {
      await EnsureUser(username, password);

      return (await _repo.GetCategories())
        .Select(c => new CategoryInfo()
        {
          categoryid = c,
          title = c,
          description = c,
          htmlUrl = string.Concat("http://wildermuth.com/tags/", c),
          rssUrl = ""
        }).ToArray();

    }

    public async Task<Post[]> GetRecentPostsAsync(string blogid, string username, string password, int numberOfPosts)
    {
      await EnsureUser(username, password);

      var result = (await _repo.GetStories(numberOfPosts)).Stories.Select(s =>
      {
        var summary = new HtmlDocument();
        summary.LoadHtml(s.GetSummary());

        return new Post()
        {
          title = s.Title,
          mt_excerpt = summary.DocumentNode.InnerText,
          description = s.Title,
          categories = s.Categories.Split(','),
          dateCreated = s.DatePublished,
          postid = s.Id,
          permalink = string.Concat("http://wildermuth.com/", s.GetStoryUrl()),
          link = string.Concat("http://wildermuth.com/", s.GetStoryUrl()),
          wp_slug = s.Slug,
          userid = "shawnwildermuth",
          wp_post_thumbnail = s.FeatureImageUrl
        };
      }).ToArray();

      return result;
    }

    public async Task<bool> DeletePostAsync(string key, string postid, string username, string password, bool publish)
    {
      await EnsureUser(username, password);

      try
      {
        var result = _repo.DeleteStory(postid);
        return await _repo.SaveAllAsync();
      }
      catch (Exception)
      {
        return false;
      }
    }

    public async Task<BlogInfo[]> GetUsersBlogsAsync(string key, string username, string password)
    {
      await EnsureUser(username, password);

      var blog = new BlogInfo()
      {
        blogid = "stw",
        blogName = "Shawn Wildermuth's Rants and Raves",
        url = "/"
      };

      return new BlogInfo[] { blog };
    }

    public async Task<UserInfo> GetUserInfoAsync(string key, string username, string password)
    {
      await EnsureUser(username, password);

      return new UserInfo()
      {
        email = "shawn@wildermuth.com",
        lastname = "Shawn",
        firstname = "Wildermuth",
        userid = "shawnwildermuth",
        url = "http://wildermuth.com"
      };
    }

    async Task EnsureUser(string username, string password)
    {
      var user = await _userMgr.FindByNameAsync(username);
      if (user != null)
      {
        if (await _userMgr.CheckPasswordAsync(user, password))
        {
          return;
        }
      }

      throw new MetaWeblogException("Authentication failed.");
    }

    void EnsureDirectory(DirectoryInfo dir)
    {
      if (dir.Parent != null)
      {
        EnsureDirectory(dir.Parent);
      }

      if (!dir.Exists)
      {
        dir.Create();
      }
    }

    public async Task<int> AddCategoryAsync(string key, string username, string password, NewCategory category)
    {
      await EnsureUser(username, password);

      // We don't store these, just query them from the list of stories so don't do anything
      return 1;
    }

    // WordPress support, don't care so just implementing the interface
    public Task<Page> GetPageAsync(string blogid, string pageid, string username, string password)
    {
      throw new NotImplementedException();
    }

    public Task<Page[]> GetPagesAsync(string blogid, string username, string password, int numPages)
    {
      throw new NotImplementedException();
    }

    public Task<Author[]> GetAuthorsAsync(string blogid, string username, string password)
    {
      throw new NotImplementedException();
    }

    public Task<string> AddPageAsync(string blogid, string username, string password, Page page, bool publish)
    {
      throw new NotImplementedException();
    }

    public Task<bool> EditPageAsync(string blogid, string pageid, string username, string password, Page page, bool publish)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeletePageAsync(string blogid, string username, string password, string pageid)
    {
      throw new NotImplementedException();
    }

    public Task<Tag[]> GetTagsAsync(string blogid, string username, string password)
    {
      throw new NotImplementedException();
    }

  }
}