using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

    public DbSet<BlogStory> Stories => Set<BlogStory>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
      // Create Defaults
      base.OnModelCreating(builder);

      MapEntity(builder.Entity<BlogStory>());
    }

    private void MapEntity(EntityTypeBuilder<BlogStory> bldr)
    {
      // Override the name of the table because of a RC2 change
      bldr.ToTable("BlogStory");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config["WilderDb:ConnectionString"]);
      base.OnConfiguring(optionsBuilder);
    }

  }
}