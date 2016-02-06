using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using WilderBlog.OldData;
using System.Linq;
using System;
using Microsoft.Data.Entity;
using WilderBlog.Data;
using System.Threading.Tasks;

namespace WilderBlog.Commands
{
  public class SiteMigration
  {
    private IConfigurationRoot _config;
    private WilderContext _ctx;
    private WilderBlogRepository _repo;

    public async Task Run()
    {
      try
      {
        Console.WriteLine("Reading Configuration");
        var builder = new ConfigurationBuilder()
         .SetBasePath(PlatformServices.Default.Application.ApplicationBasePath)
         .AddJsonFile("config.json")
         .AddEnvironmentVariables();

        _config = builder.Build();
        _ctx = new WilderContext(_config);
        _repo = new WilderBlogRepository(_config);

        Console.WriteLine("Clearing the DocumentDB Store");
        await ClearDatabase();

        Console.WriteLine("Migrating Stories");
        await MigrateStories();
        
        //TODO More migration

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        Console.ReadKey();
      }
    }

    private async Task ClearDatabase()
    {
      await _repo.ClearDatabaseAsync();
    }

    private async Task MigrateStories()
    {
      var stories = _ctx.Stories.Include(s => s.Comments).Include(s => s.Categories).OrderByDescending(s => s.DatePosted).ToList();
      var counter = 1;
      foreach (var story in stories)
      {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"Migrating {counter} of {stories.Count()}");
        await MigrateStory(story);
        counter++;
      }
    }

    private async Task MigrateStory(Story story)
    {
      FixBody(story.Body);

      await _repo.AddStory(new BlogStory()
      {
        Title = story.Title,
        Body = story.Body,
        DatePublished = story.DatePosted,
        IsPublished = story.IsPublished,
        UniqueId = story.Permalink,
        Slug = story.GetSlug(),
        Categories = story.Categories.Select(s => s.Name).ToList()
      });

      foreach (var comment in story.Comments)
      {
        MigrateComment();
      }
    }

    private void MigrateComment()
    {
      // TODO Migrate to Disqus
    }

    private void FixBody(string body)
    {
      // TODO Fix Image Paths
      body.Replace("http://wildermuth.com/images/", "http://wildermuth.com/img/blog/");
      // TODO Fix Download Paths
      body.Replace("http://wildermuth.com/downloads/", "http://wildermuth.com/files/");
    }
  }
}