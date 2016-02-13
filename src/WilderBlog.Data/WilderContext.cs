using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderContext : DbContext
  {
    private IConfigurationRoot _config;

    public WilderContext(IConfigurationRoot config)
    {
      _config = config;

      Database.EnsureCreated();
      Database.Migrate();
    }

    public DbSet<BlogStory> Stories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config["WilderDb:ConnectionString"]);

      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      OnCreating(builder.Entity<BlogStory>());
    }

    private void OnCreating(EntityTypeBuilder<BlogStory> bldr)
    {
    }
  }
}