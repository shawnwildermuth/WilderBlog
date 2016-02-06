using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace WilderBlog.OldData
{
  public class WilderRepository : IWilderRepository
  {
    private WilderContext _ctx;

    public WilderRepository(WilderContext ctx)
    {
      _ctx = ctx;
    }

    public IEnumerable<Story> GetNewStories()
    {
      return _ctx.Stories
        .Include(s => s.Comments)
        .Where(s => s.IsPublished)
        .OrderByDescending(s => s.DatePosted)
        .Take(5)
        .ToList();
    }
  }
}
