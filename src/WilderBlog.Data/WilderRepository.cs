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

  }
}
