using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WilderBlog.Data;

namespace WilderBlog.Migrations
{
    [DbContext(typeof(WilderContext))]
    partial class WilderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16341")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("WilderBlog.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 120);

                    b.Property<int?>("StoryId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("WilderBlog.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("DatePosted");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("PosterEmail")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("PosterName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int?>("StoryId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("WilderBlog.Data.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DatePublished");

                    b.Property<bool>("IsBook");

                    b.Property<string>("Link")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("PublicationName")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("Publisher")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("WilderBlog.Data.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("DatePosted");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Permalink");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("WilderBlog.Data.Talk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeLink")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventLink")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("PdfLink")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("SlideLink")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 250);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("WilderBlog.Data.WilderUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WilderBlog.Data.WilderUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WilderBlog.Data.WilderUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("WilderBlog.Data.WilderUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WilderBlog.Data.Category", b =>
                {
                    b.HasOne("WilderBlog.Data.Story")
                        .WithMany()
                        .HasForeignKey("StoryId");
                });

            modelBuilder.Entity("WilderBlog.Data.Comment", b =>
                {
                    b.HasOne("WilderBlog.Data.Story")
                        .WithMany()
                        .HasForeignKey("StoryId");
                });
        }
    }
}
