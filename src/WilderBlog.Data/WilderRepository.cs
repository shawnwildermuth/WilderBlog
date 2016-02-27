using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderRepository : IWilderRepository
  {
    private WilderContext _ctx;

    public WilderRepository(IConfigurationRoot config, WilderContext ctx)
    {
      _ctx = ctx;
    }

    public void AddStory(BlogStory story)
    {
      _ctx.Stories.Add(story);
    }

    public void SaveAll()
    {
      _ctx.SaveChanges();
    }

    public IEnumerable<BlogStory> GetStories(int count = 10, int page = 0)
    {
      return _ctx.Stories.OrderByDescending(s => s.DatePublished).Skip(count * page).Take(count).ToList();
    }

    public BlogStory GetStory(int id)
    {
      return _ctx.Stories.Where(b => b.Id == id).FirstOrDefault();
    }

    public BlogStory GetStory(string slug)
    {
      return _ctx.Stories.Where(s => s.Slug == slug || s.Slug == slug.Replace('_', '-'))
        .FirstOrDefault();
    }

    public bool DeleteStory(string postid)
    {
      var id = int.Parse(postid);
      var story = _ctx.Stories.Where(w => w.Id == id).FirstOrDefault();
      if (story != null)
      {
        _ctx.Stories.Remove(story);
      }

      return false;
    }

    public IEnumerable<string> GetCategories()
    {
      var cats = _ctx.Stories
                .Select(c => c.Categories.Split(','))
                .ToList();

      var result = new List<string>();
      foreach (var s in cats) result.AddRange(s);

      return result.Where(s => !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).Distinct();

    }

  }
}
