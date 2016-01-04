using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace WilderBlog.Data
{
  public class WilderContext : IdentityDbContext<WilderUser>
  {
    public WilderContext()
    {
    }

    public DbSet<Story> Stories {get;set;}
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Story>().Property(s => s.Body).IsRequired();
      builder.Entity<Story>().Property(s => s.Title).IsRequired().HasMaxLength(250);
      builder.Entity<Story>().Property(s => s.Permalink).IsRequired();

      builder.Entity<Category>().Property(s => s.Name).IsRequired();

    }
  }
}
