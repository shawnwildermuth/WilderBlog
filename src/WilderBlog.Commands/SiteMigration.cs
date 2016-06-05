using Microsoft.Extensions.Configuration;
using WilderBlog.OldData;
using System.Linq;
using System;
using WilderBlog.Data;
using WilderBlog.Commands.OldDb;
using WilderBlog.Commands.Disqus;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WilderBlog.Commands
{
  public class SiteMigration
  {
    private IConfigurationRoot _config;
    private OldWilderContext _ctx;
    private WilderRepository _repo;
    private WilderContext _newCtx;

    public void Run(string command)
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
        _newCtx = new WilderContext(new DbContextOptions<WilderContext>(), _config);
        _repo = new WilderRepository(_config, _newCtx);


        if (command == "" || command == "stories" || command == "comments")
        {
          MigrateStories(command == "comments");
        }
        if (command == "" || command == "podcast")
        {
          MigratePodcast();
        }
        if (command == "" || command == "publications")
        {
          MigratePublications();
        }
        if (command == "" || command == "calendar")
        {
          MigrateCalendar();
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        Console.ReadKey();
      }
    }

    private void MigrateStories(bool onlyComments = false)
    {
      Console.WriteLine("Migrating Stories");

      if (!onlyComments)
      {
        _newCtx.Stories.RemoveRange(_newCtx.Stories.ToList());
      }

      var stories = _ctx.Stories
        .Include(s => s.Comments)
        .Include(s => s.StoryCategories)
        .OrderByDescending(s => s.DatePosted).ToList();

      if (!onlyComments)
      {
        var counter = 1;
        foreach (var story in stories)
        {
          Console.WriteLine($"Migrating {counter} of {stories.Count()}");
          MigrateStory(story);
          counter++;
        }
      }

      Console.WriteLine();

      Console.WriteLine("Migrating Comments");
      var export = new DiscusImport();
      export.CreateXml(stories);

      Console.WriteLine();

      _repo.SaveAll();
    }

    private void MigratePodcast()
    {
      Console.WriteLine($"Migrating Podcast Episodes");

      File.WriteAllText("episodeList.json", JsonConvert.SerializeObject(new EpisodeList(), new JsonSerializerSettings()
      {
        Formatting = Newtonsoft.Json.Formatting.Indented,
        DateFormatString = "MM/dd/yy",
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      }));
    }

    private void MigratePublications()
    {
      Console.WriteLine($"Migrating Publications");

      var publications = _ctx.Publications.ToList();
      File.WriteAllText("publications.json", JsonConvert.SerializeObject(publications, new JsonSerializerSettings()
      {
        Formatting = Newtonsoft.Json.Formatting.Indented,
        DateFormatString = "MM/dd/yy",
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      }));

    }

    private void MigrateCalendar()
    {
      Console.WriteLine($"Migrating Calendar");

      File.WriteAllText("calendar.json", JsonConvert.SerializeObject(EventCalendar.Events, new JsonSerializerSettings()
      {
        Formatting = Newtonsoft.Json.Formatting.Indented,
        DateFormatString = "MM/dd/yy",
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      }));
    }

    private void MigrateStory(Stories story)
    {
      story.Body = FixBody(story.Body);

      var newStory = new BlogStory()
      {
        Title = story.Title,
        Body = story.Body,
        DatePublished = story.DatePosted,
        IsPublished = story.IsPublished,
        UniqueId = story.GetStoryUrl(),
        Slug = story.GetStoryUrl()
      };

      var cats = string.Join(",", _ctx.StoryCategories.Include(c => c.Category).Where(s => s.Story_Id == story.Id).Select(s => s.Category.Name).ToArray());
      newStory.Categories = cats;

      _repo.AddStory(newStory);
    }

    private string FixBody(string body)
    {
      // TODO Fix Image Paths
      return body.Replace("http://wildermuth.com/images/", "http://wilderminds.blob.core.windows.net/img/")
        .Replace("\"/images/", "\"http://wilderminds.blob.core.windows.net/img/")
        .Replace("http://wildermuth.com/downloads/", "http://wilderminds.blob.core.windows.net/downloads/")
        .Replace("\"/downloads/", "\"http://wilderminds.blob.core.windows.net/downloads/");
    }
  }
}