using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      OnCreating(builder.Entity<BlogStory>());

      base.OnModelCreating(builder);
    }

    private void OnCreating(EntityTypeBuilder<BlogStory> bldr)
    {
    }
  }
}