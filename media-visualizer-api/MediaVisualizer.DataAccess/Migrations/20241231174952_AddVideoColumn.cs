using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaVisualizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "AnimeChapters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "AnimeChapters");
        }
    }
}
