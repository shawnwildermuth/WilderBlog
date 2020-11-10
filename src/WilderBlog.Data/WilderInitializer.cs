using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WilderBlog.Data
{
  public class WilderInitializer
  {
    private WilderContext _ctx;
    private UserManager<WilderUser> _userMgr;
    private readonly ILogger<WilderInitializer> _logger;

    public WilderInitializer(WilderContext ctx, UserManager<WilderUser> userMgr, ILogger<WilderInitializer> logger)
    {
      _ctx = ctx;
      _userMgr = userMgr;
      _logger = logger;
    }

    public async Task SeedAsync()
    {
      // Seed User
      if (await _userMgr.FindByNameAsync("shawnwildermuth") == null)
      {
        var user = new WilderUser()
        {
          Email = "shawn@wildermuth.com",
          UserName = "shawnwildermuth",
          EmailConfirmed = true
        };

        var result = await _userMgr.CreateAsync(user, "P@ssw0rd!"); // Temp Password
        if (!result.Succeeded) throw new InvalidProgramException("Failed to create seed user");
      }

      // Seed Stories
      if (!_ctx.Stories.Any())
      {
        var stories = MemoryRepository._stories;
        stories.ForEach(s => s.Id = 0);
        _ctx.Stories.AddRange(stories);
        await _ctx.SaveChangesAsync();
      }

      // Update Abstract and Image
      if (!_ctx.Stories.Any(s => !string.IsNullOrEmpty(s.Abstract)))
      {
        var stories = await _ctx.Stories.ToListAsync();
        foreach (var story in stories)
        {
          // Get Image
          var summary = GetSummary(story);
          var regex = new Regex("\\<img.+src\\=(?:\"|\')(.+?)(?:\"|\')(?:.+?)\\>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
          var result = regex.Matches(summary);
          if (result.Any())
          {
            var firstResult = result.First();
            var rawImg = firstResult.Groups[0].Value;
            var url = firstResult.Groups[1].Value;
            story.FeatureImageUrl = url;
            story.Body = story.Body.Replace(rawImg, "");
            story.Abstract = summary.Replace(rawImg, "");
            _logger.LogDebug($"Updating: {story.Title}");
          }
        }
        if (!(await _ctx.SaveChangesAsync() > 0))
        {
          _logger.LogError("Failed to save changes to image and abstracts");
        }
        _logger.LogDebug($"Done Updating");
      }
    }

    private string GetSummary(BlogStory story)
    {
      var MAXPARAGRAPHS = 3;
      var regex = new Regex("(<p[^>]*>.*?</p>)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
      var result = regex.Matches(story.Body);
      StringBuilder bldr = new StringBuilder();
      var x = 0;
      foreach (Match m in result)
      {
        x++;
        bldr.Append(m.Value);
        if (x == MAXPARAGRAPHS) break;
      }
      return bldr.ToString();
    }
  }
}
