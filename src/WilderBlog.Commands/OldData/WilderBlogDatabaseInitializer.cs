using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;

namespace WilderBlog.OldData
{
  public class WilderBlogDatabaseInitializer
  {
    private WilderContext _ctx;
    private IHostingEnvironment _environ;
    private UserManager<WilderUser> _mgr;

    public WilderBlogDatabaseInitializer(WilderContext ctx, UserManager<WilderUser> mgr, IHostingEnvironment environ)
    {
      _ctx = ctx;
      _mgr = mgr;
      _environ = environ;
    }

    public async Task InitializeAsync()
    {
      await _ctx.Database.EnsureCreatedAsync();

      if (!_ctx.Stories.Any())
      {
        // Create Data
        if (_environ.IsDevelopment())
        {
          var user = new WilderUser()
          {
            UserName = "shawnwildermuth",
            Email = "shawn@wildermuth.com",
            EmailConfirmed = true
          };
          await _mgr.CreateAsync(user, "P@ssw0rd!");

          var story = new Story()
          {
            Body = "<p>Test Story</p>",
            DatePosted = DateTime.UtcNow,
            IsPublished = true,
            Permalink = Guid.NewGuid().ToString(),
            Title = "Welcome to My Blog"
          };

          _ctx.Stories.Add(story);
          await _ctx.SaveChangesAsync();
        }
      }
    }
  }
}
