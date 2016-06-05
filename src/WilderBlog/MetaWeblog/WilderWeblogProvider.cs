using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using WilderBlog.Data;
using WilderBlog.Helpers;
using WilderMinds.MetaWeblog;

namespace WilderBlog.MetaWeblog
{
  public class WilderWeblogProvider : IMetaWeblogProvider
  {
    private IWilderRepository _repo;
    private UserManager<WilderUser> _userMgr;
    private IConfigurationRoot _config;
    private IHostingEnvironment _appEnv;

    public WilderWeblogProvider(UserManager<WilderUser> userMgr, IWilderRepository repo, IConfigurationRoot config, IHostingEnvironment appEnv)
    {
      _repo = repo;
      _userMgr = userMgr;
      _config = config;
      _appEnv = appEnv;
    }

    public string AddPost(string blogid, string username, string password, Post post, bool publish)
    {
      EnsureUser(username, password).Wait();

      var newStory = new BlogStory();
      try
      {
        newStory.Title = post.title;
        newStory.Body = post.description;
        newStory.DatePublished = post.dateCreated == DateTime.MinValue ? DateTime.UtcNow : post.dateCreated;
        newStory.Categories = string.Join(",", post.categories);
        newStory.IsPublished = publish;
        newStory.Slug = newStory.GetStoryUrl();
        newStory.UniqueId = newStory.Slug;

        _repo.AddStory(newStory);
        _repo.SaveAll();
      }
      catch (Exception)
      {
        throw new MetaWeblogException("Failed to save the post.");
      }
      return newStory.Id.ToString();

    }

    public bool EditPost(string postid, string username, string password, Post post, bool publish)
    {
      EnsureUser(username, password).Wait();

      try
      {
        var story = _repo.GetStory(int.Parse(postid));

        story.Title = post.title;
        story.Body = post.description;
        story.DatePublished = post.dateCreated == DateTime.MinValue ? DateTime.UtcNow : post.dateCreated;
        story.Categories = string.Join(",", post.categories);
        story.IsPublished = publish;
        story.Slug = story.GetStoryUrl();

        _repo.SaveAll();

        return true;
      }
      catch (Exception)
      {
        throw new MetaWeblogException("Failed to save the post.");
      }
    }

    public Post GetPost(string postid, string username, string password)
    {
      EnsureUser(username, password).Wait();

      try
      {
        var story = _repo.GetStory(int.Parse(postid));
        var newPost = new Post()
        {
          title = story.Title,
          description = story.Body,
          dateCreated = story.DatePublished,
          categories = story.Categories.Split(','),
          postid = story.Id,
          userid = "shawnwildermuth",
          wp_slug = story.GetStoryUrl()
        };

        return newPost;
      }
      catch (Exception)
      {
        throw new MetaWeblogException("Failed to get the post.");
      }
    }

    public MediaObjectInfo NewMediaObject(string blogid, string username, string password, MediaObject mediaObject)
    {
      EnsureUser(username, password).Wait();

      var filenameonly = mediaObject.name.Substring(mediaObject.name.LastIndexOf('/') + 1);

      var url = $"https://wilderminds.blob.core.windows.net/img/{filenameonly}";
      var creds = new StorageCredentials(_config["BlobStorage:Account"], _config["BlobStorage:Key"]);
      var blob = new CloudBlockBlob(new Uri(url), creds);
      var bits = Convert.FromBase64String(mediaObject.bits);
      blob.UploadFromByteArrayAsync(bits, 0, bits.Length).Wait();

      // Create the response
      MediaObjectInfo objectInfo = new MediaObjectInfo();
      objectInfo.url = url;

      return objectInfo;
    }

    public CategoryInfo[] GetCategories(string blogid, string username, string password)
    {
      EnsureUser(username, password).Wait();

      return _repo.GetCategories()
        .Select(c => new CategoryInfo()
        {
          categoryid = c,
          title = c,
          description = c,
          htmlUrl = string.Concat("http://wildermuth.com/tags/", c),
          rssUrl = ""
        }).ToArray();

    }

    public Post[] GetRecentPosts(string blogid, string username, string password, int numberOfPosts)
    {
      EnsureUser(username, password).Wait();

      return _repo.GetStories(numberOfPosts).Stories.Select(s => new Post()
      {
        title = s.Title,
        description = s.Body,
        categories = s.Categories.Split(','),
        dateCreated = s.DatePublished,
        postid = s.Id,
        permalink = s.GetStoryUrl(),
        wp_slug = s.Slug
      }).ToArray();
    }

    public bool DeletePost(string key, string postid, string username, string password, bool publish)
    {
      EnsureUser(username, password).Wait();

      try
      {
        var result = _repo.DeleteStory(postid);
        _repo.SaveAll();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public BlogInfo[] GetUsersBlogs(string key, string username, string password)
    {
      EnsureUser(username, password).Wait();

      var blog = new BlogInfo()
      {
        blogid = "stw",
        blogName = "Shawn Wildermuth's Rants and Raves",
        url = "/"
      };

      return new BlogInfo[] { blog };
    }

    public UserInfo GetUserInfo(string key, string username, string password)
    {
      EnsureUser(username, password).Wait();

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

    public int AddCategory(string key, string username, string password, NewCategory category)
    {
      EnsureUser(username, password).Wait();

      // We don't store these, just query them from the list of stories so don't do anything
      return 1;
    }
  }
}