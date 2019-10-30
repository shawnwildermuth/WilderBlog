using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

    public async Task<BlogResult> GetStories(int pageSize = 25, int page = 1)
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
        Stories = await _ctx.Stories
          .Where( s => s.IsPublished)
          .OrderByDescending(s => s.DatePublished)
          .Skip(pageSize * (page - 1))
          .Take(pageSize)
          .ToListAsync(),
      };

      return FixResults(result);
    }

    public async Task<BlogResult> GetStoriesByTerm(string term, int pageSize, int page)
    {
      var lowerTerm = term.ToLower();
      var totalCount = await _ctx.Stories.Where(s =>
          s.IsPublished &&
          (s.Body.ToLower().Contains(lowerTerm) ||
          s.Categories.ToLower().Contains(lowerTerm) ||
          s.Title.ToLower().Contains(lowerTerm))
          ).CountAsync();

      var result = new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = await _ctx.Stories
          .Where(s => s.IsPublished && (s.Body.ToLower().Contains(lowerTerm) ||
                   s.Categories.ToLower().Contains(lowerTerm) ||
                   s.Title.ToLower().Contains(lowerTerm)))
          .OrderByDescending(o => o.DatePublished)
          .Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync()
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

    public async Task<BlogStory> GetStory(int id)
    {
      var result = await _ctx.Stories.Where(b => b.Id == id).FirstOrDefaultAsync();
      FixStory(result);
      return result;
    }

    public async Task<BlogStory> GetStory(string slug)
    {
      var result = await _ctx.Stories
        .Where(s => s.Slug == slug || s.Slug == slug.Replace('_', '-'))
        .FirstOrDefaultAsync();

      FixStory(result);
      return result;
    }

    public async Task<bool> DeleteStory(string postid)
    {
      var id = int.Parse(postid);
      var story = await _ctx.Stories.Where(w => w.Id == id).FirstOrDefaultAsync();
      if (story != null)
      {
        _ctx.Stories.Remove(story);
      }

      return false;
    }

    public async Task<IEnumerable<string>> GetCategories()
    {
      var cats = await _ctx.Stories
                .Select(c => c.Categories.Split(new[] { ',' }, StringSplitOptions.None))
                .ToListAsync();

      var result = new List<string>();
      foreach (var s in cats) result.AddRange(s);

      return result.Where(s => !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).Distinct();

    }

    public async Task<BlogResult> GetStoriesByTag(string tag, int pageSize, int page)
    {
      var lowerTag = tag.ToLowerInvariant();
      var subResult = await _ctx.Stories
        .Where(s => s.IsPublished && s.Categories.ToLower().Contains(lowerTag)) // Limiting the search for perf
        .ToArrayAsync();
      var totalCount =  subResult.Where(s => s.Categories.ToLower().Split(',').Contains(lowerTag)).Count();

      var stories = await _ctx.Stories
          .Where(s => s.IsPublished && s.Categories.ToLower().Contains(lowerTag))
          .ToArrayAsync();

      var result = new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = stories.Where(s => s.Categories.ToLower().Split(',').Contains(lowerTag))
          .OrderByDescending(s => s.DatePublished)
          .Skip((page - 1) * pageSize).Take(pageSize)
      };

      return FixResults(result);
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _ctx.SaveChangesAsync() > 0;
    }
  }
}
