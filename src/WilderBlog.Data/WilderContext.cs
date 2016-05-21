using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderContext : IdentityDbContext<WilderUser>
  {
    private IConfigurationRoot _config;

    public WilderContext(IConfigurationRoot config)
    {
      _config = config;
    }

    public DbSet<BlogStory> Stories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config["WilderDb:ConnectionString"]);

      base.OnConfiguring(optionsBuilder);
    }

  }
}