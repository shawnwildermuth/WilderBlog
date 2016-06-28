using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Commands.OldDb
{
  public partial class OldWilderContext : DbContext
  {
    private IConfigurationRoot _config;

    public OldWilderContext(IConfigurationRoot config)
    {
      _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      var connString = _config["WilderDb:OldConnectionString"];
      options.UseSqlServer(connString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Categories>(entity =>
      {
        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(120);
      });

      modelBuilder.Entity<Comments>(entity =>
      {
        entity.Property(e => e.DatePosted).HasColumnType("datetime");

        entity.Property(e => e.PosterEmail).HasMaxLength(255);

        entity.Property(e => e.PosterName)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.HasOne(d => d.Story).WithMany(p => p.Comments).HasForeignKey(d => d.Story_Id);
      });

      modelBuilder.Entity<Publications>(entity =>
      {
        entity.Property(e => e.DatePublished).HasColumnType("datetime");

        entity.Property(e => e.Link).HasMaxLength(250);

        entity.Property(e => e.PublicationName).HasMaxLength(250);

        entity.Property(e => e.Publisher).HasMaxLength(250);

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(250);
      });

      modelBuilder.Entity<Stories>(entity =>
      {
        entity.Property(e => e.DatePosted).HasColumnType("datetime");

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(250);
      });

      modelBuilder.Entity<StoryCategories>(entity =>
      {
        entity.HasKey(e => new { e.Category_Id, e.Story_Id });

        entity.HasOne(d => d.Category).WithMany(p => p.StoryCategories).HasForeignKey(d => d.Category_Id);

        entity.HasOne(d => d.Story).WithMany(p => p.StoryCategories).HasForeignKey(d => d.Story_Id);
      });

      modelBuilder.Entity<Talks>(entity =>
      {
        entity.Property(e => e.CodeLink).HasMaxLength(250);

        entity.Property(e => e.Description).IsRequired();

        entity.Property(e => e.EventDate).HasColumnType("datetime");

        entity.Property(e => e.EventLink).HasMaxLength(250);

        entity.Property(e => e.PdfLink).HasMaxLength(250);

        entity.Property(e => e.SlideLink).HasMaxLength(250);

        entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(250);
      });

      modelBuilder.Entity<Users>(entity =>
      {
        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasMaxLength(100);

        entity.Property(e => e.PasswordSalt)
                  .IsRequired()
                  .HasMaxLength(100);

        entity.Property(e => e.UserName)
                  .IsRequired()
                  .HasMaxLength(255);
      });
    }

    public virtual DbSet<Categories> Categories { get; set; }
    public virtual DbSet<Comments> Comments { get; set; }
    public virtual DbSet<Publications> Publications { get; set; }
    public virtual DbSet<Stories> Stories { get; set; }
    public virtual DbSet<StoryCategories> StoryCategories { get; set; }
    public virtual DbSet<Talks> Talks { get; set; }
    public virtual DbSet<Users> Users { get; set; }
  }
}