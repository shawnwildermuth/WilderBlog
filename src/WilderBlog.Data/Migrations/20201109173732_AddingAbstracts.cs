using Microsoft.EntityFrameworkCore.Migrations;

namespace WilderBlog.Data.Migrations
{
    public partial class AddingAbstracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "BlogStory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureImageUrl",
                table: "BlogStory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "BlogStory");

            migrationBuilder.DropColumn(
                name: "FeatureImageUrl",
                table: "BlogStory");
        }
    }
}
