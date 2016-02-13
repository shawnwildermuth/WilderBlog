using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using WilderBlog.OldData;
using System.Linq;
using System;
using Microsoft.Data.Entity;
using WilderBlog.Data;
using System.Threading.Tasks;
using WilderBlog.Commands.OldDb;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using WilderBlog.Commands.Disqus;

namespace WilderBlog.Commands
{
  public class SiteMigration
  {
    private IConfigurationRoot _config;
    private OldWilderContext _ctx;
    private WilderRepository _repo;
    private WilderContext _newCtx;

    public void Run()
    {
      try
      {
        Console.WriteLine("Reading Configuration");
        var builder = new ConfigurationBuilder()
         .SetBasePath(PlatformServices.Default.Application.ApplicationBasePath)
         .AddJsonFile("config.json")
         .AddEnvironmentVariables();

        _config = builder.Build();
        _ctx = new OldWilderContext(_config);
        _newCtx = new WilderContext(_config);
        _repo = new WilderRepository(_config, _newCtx);

        Console.WriteLine("Migrating Stories");
        MigrateStories();

        //TODO More migration

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        Console.ReadKey();
      }
    }

    private void MigrateStories()
    {
      _newCtx.Stories.RemoveRange(_newCtx.Stories.ToList());

      var stories = _ctx.Stories
        .Include(s => s.Comments)
        .Include(s => s.StoryCategories)
        .OrderByDescending(s => s.DatePosted).ToList();

      var counter = 1;
      foreach (var story in stories)
      {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"Migrating {counter} of {stories.Count()}");
        MigrateStory(story);
        counter++;
      }

      var export = new DiscusImport();
      export.CreateXml(stories);

      _repo.SaveAll();
    }

    private void MigrateStory(Stories story)
    {
      FixBody(story.Body);

      var newStory = new BlogStory()
      {
        Title = story.Title,
        Body = story.Body,
        DatePublished = story.DatePosted,
        IsPublished = story.IsPublished,
        UniqueId = story.Permalink,
        Slug = story.GetSlug()
      };

      newStory.Categories = string.Join(",", _ctx.StoryCategories.Include(c => c.Category).Where(s => s.Story_Id == story.Id).Select(s => s.Category.Name).ToArray());

      _repo.AddStory(newStory);
    }

    private void FixBody(string body)
    {
      // TODO Fix Image Paths
      body.Replace("http://wildermuth.com/images/", "http://wildermuth.com/img/blog/");
      body.Replace("\"/images/", "\"/img/blog/");
    }
  }
}