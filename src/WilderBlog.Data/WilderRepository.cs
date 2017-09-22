using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderRepository : BaseRepository, IWilderRepository
  {
    private WilderContext _ctx;

    public WilderRepository(WilderContext ctx)
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

      // Fix random SQL Errors due to bad offset
      if (page < 1) page = 1;
      if (pageSize > 100) pageSize = 100;

      var result = new BlogResult()
      {
        CurrentPage = page,
        TotalResults = count,
        TotalPages = CalculatePages(count, pageSize),
        Stories = _ctx.Stories
          .Where( s => s.IsPublished)
          .OrderByDescending(s => s.DatePublished)
          .Skip(pageSize * (page - 1))
          .Take(pageSize)
          .ToList(),
      };

      return FixResults(result);
    }

    public BlogResult GetStoriesByTerm(string term, int pageSize, int page)
    {
      var lowerTerm = term.ToLowerInvariant();
      var totalCount = _ctx.Stories.Where(s =>
          s.IsPublished &&
          (s.Body.ToLowerInvariant().Contains(lowerTerm) ||
          s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
          s.Title.ToLowerInvariant().Contains(lowerTerm))
          ).Count();

      var result = new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _ctx.Stories
        .Where(s => s.IsPublished && (s.Body.ToLowerInvariant().Contains(lowerTerm) ||
                 s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
                 s.Title.ToLowerInvariant().Contains(lowerTerm)))
        .OrderByDescending(o => o.DatePublished)
        .Skip((page - 1) * pageSize).Take(pageSize)
      };

      return FixResults(result);

    }

    private BlogResult FixResults(BlogResult result)
    {
      foreach (var s in result.Stories)
      {
        FixStory(s);
      }

      return result;
    }

    private void FixStory(BlogStory s)
    {
      if (s != null)
      {
        s.Body = s.Body.Replace("http://wilderminds.blob.core.windows.net/img/", "//wilderminds.blob.core.windows.net/img/");
      }
    }

    public BlogStory GetStory(int id)
    {
      var result = _ctx.Stories.Where(b => b.Id == id).FirstOrDefault();
      FixStory(result);
      return result;
    }

    public BlogStory GetStory(string slug)
    {
      var result = _ctx.Stories
        .Where(s => s.Slug == slug || s.Slug == slug.Replace('_', '-'))
        .FirstOrDefault();

      FixStory(result);
      return result;
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
                .Select(c => c.Categories.Split(new[] { ',' }, StringSplitOptions.None))
                .ToList();

      var result = new List<string>();
      foreach (var s in cats) result.AddRange(s);

      return result.Where(s => !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).Distinct();

    }

    public BlogResult GetStoriesByTag(string tag, int pageSize, int page)
    {
      var lowerTag = tag.ToLowerInvariant();
      var totalCount = _ctx.Stories
        .Where(s => s.IsPublished && s.Categories.ToLower().Contains(lowerTag)) // Limiting the search for perf
        .ToArray()
        .Where(s => s.Categories.ToLower().Split(',').Contains(lowerTag)).Count(); 

      var result = new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _ctx.Stories
          .Where(s => s.IsPublished && s.Categories.ToLower().Contains(lowerTag))
          .ToArray()
          .Where(s => s.Categories.ToLower().Split(',').Contains(lowerTag))
          .Skip((page - 1) * pageSize).Take(pageSize)
      };

      return FixResults(result);
    }
  }
}
