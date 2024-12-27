using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaVisualizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPagesCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PagesCount",
                table: "MangaChapter",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagesCount",
                table: "MangaChapter");
        }
    }
}
