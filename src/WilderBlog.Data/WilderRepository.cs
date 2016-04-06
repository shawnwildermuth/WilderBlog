using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderRepository : BaseRepository, IWilderRepository
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

    public BlogResult GetStories(int pageSize = 25, int page = 1)
    {
      var count = _ctx.Stories.Count();

      return new BlogResult()
      {
        CurrentPage = page,
        TotalResults = count,
        TotalPages = CalculatePages(count, pageSize),
        Stories = _ctx.Stories
          .OrderByDescending(s => s.DatePublished)
          .Skip(pageSize * (page - 1))
          .Take(pageSize)
          .ToList(),
      };
    }

    public BlogResult GetStoriesByTerm(string term, int pageSize, int page)
    {
      var lowerTerm = term.ToLowerInvariant();
      var totalCount = _ctx.Stories.Where(s =>
          s.Body.ToLowerInvariant().Contains(lowerTerm) ||
          s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
          s.Title.ToLowerInvariant().Contains(lowerTerm)
          ).Count();

      return new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _ctx.Stories
        .Where(s => s.Body.ToLowerInvariant().Contains(lowerTerm) ||
                 s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
                 s.Title.ToLowerInvariant().Contains(lowerTerm))
        .Skip((page - 1) * pageSize).Take(pageSize)
      };
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

    public BlogResult GetStoriesByTag(string tag, int pageSize, int page)
    {
      var lowerTag = tag.ToLowerInvariant();
      var totalCount = _ctx.Stories
        .Where(s => s.Categories.ToLower().Contains(lowerTag)) // Limiting the search for perf
        .ToArray()
        .Where(s => s.Categories.ToLower().Split(',').Contains(lowerTag)).Count(); 

      return new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _ctx.Stories
          .Where(s => s.Categories.ToLower().Contains(lowerTag))
          .ToArray()
          .Where(s => s.Categories.ToLower().Split(',').Contains(lowerTag))
          .Skip((page - 1) * pageSize).Take(pageSize)
      };
    }
  }
}
