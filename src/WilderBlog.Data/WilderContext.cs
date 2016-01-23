using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace WilderBlog.Data
{
  public class WilderContext : IdentityDbContext<WilderUser>
  {
    public WilderContext()
    {
    }

    public DbSet<Story> Stories {get;set;}
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Talk> Talks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      CreateModel(builder.Entity<Story>());
      CreateModel(builder.Entity<Comment>());
      CreateModel(builder.Entity<Category>());
      CreateModel(builder.Entity<Talk>());
      CreateModel(builder.Entity<Publication>());
    }

    private void CreateModel(EntityTypeBuilder<Story> builder)
    {
      builder.Property(s => s.Body).IsRequired();
      builder.Property(s => s.Title).IsRequired().HasMaxLength(250);
      builder.Property(s => s.IsPublished).IsRequired();
    }

    private void CreateModel(EntityTypeBuilder<Comment> builder)
    {
      builder.Property(s => s.PosterName).IsRequired().HasMaxLength(255);
      builder.Property(s => s.PosterEmail).HasMaxLength(255);
      builder.Property(s => s.DatePosted).IsRequired();
      builder.Property(s => s.IsApproved).IsRequired();
    }

    private void CreateModel(EntityTypeBuilder<Category> builder)
    {
      builder.Property(s => s.Name).IsRequired().HasMaxLength(120);
    }

    private void CreateModel(EntityTypeBuilder<Talk> builder)
    {
      builder.Property(s => s.Title).IsRequired().HasMaxLength(250);
      builder.Property(s => s.Description).IsRequired();
      builder.Property(s => s.EventDate).IsRequired();
      builder.Property(s => s.EventLink).HasMaxLength(250);
      builder.Property(s => s.CodeLink).HasMaxLength(250);
      builder.Property(s => s.SlideLink).HasMaxLength(250);
      builder.Property(s => s.PdfLink).HasMaxLength(250);
    }

    private void CreateModel(EntityTypeBuilder<Publication> builder)
    {
      builder.Property(s => s.Title).IsRequired().HasMaxLength(250);
      builder.Property(s => s.PublicationName).HasMaxLength(250);
      builder.Property(s => s.DatePublished).IsRequired();
      builder.Property(s => s.IsBook).IsRequired();
      builder.Property(s => s.Link).HasMaxLength(250);
      builder.Property(s => s.Publisher).HasMaxLength(250);
    }

  }
}
