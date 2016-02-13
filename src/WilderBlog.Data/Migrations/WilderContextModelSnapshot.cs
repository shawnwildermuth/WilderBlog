using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WilderBlog.Data;

namespace WilderBlog.Data.Migrations
{
    [DbContext(typeof(WilderContext))]
    partial class WilderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
