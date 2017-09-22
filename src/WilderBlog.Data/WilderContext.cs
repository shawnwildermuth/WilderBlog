using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderContext : IdentityDbContext<WilderUser>
  {
    public WilderContext(DbContextOptions<WilderContext> options, IConfiguration config) : base(options)
    {
      _config = config;
    }

    private IConfiguration _config;

    public DbSet<BlogStory> Stories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      // Override the name of the table because of a RC2 change
      builder.Entity<BlogStory>().ToTable("BlogStory");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config["WilderDb:ConnectionString"]);
      base.OnConfiguring(optionsBuilder);
    }

  }
}