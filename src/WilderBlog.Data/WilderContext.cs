using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderContext : IdentityDbContext<WilderUser>
  {
    public WilderContext(DbContextOptions<WilderContext> options, IConfigurationRoot config) : base(options)
    {
      _config = config;
    }

    private IConfigurationRoot _config;

    public DbSet<BlogStory> Stories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config["WilderDb:ConnectionString"]);

      base.OnConfiguring(optionsBuilder);
    }

  }
}