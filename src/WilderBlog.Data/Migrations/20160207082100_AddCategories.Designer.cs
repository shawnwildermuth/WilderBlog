using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WilderBlog.Data;

namespace WilderBlog.Data.Migrations
{
    [DbContext(typeof(WilderContext))]
    [Migration("20160207082100_AddCategories")]
    partial class AddCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16341")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WilderBlog.Data.BlogStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Categories");

                    b.Property<DateTime>("DatePublished");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<string>("UniqueId");

                    b.HasKey("Id");
                });
        }
    }
}
