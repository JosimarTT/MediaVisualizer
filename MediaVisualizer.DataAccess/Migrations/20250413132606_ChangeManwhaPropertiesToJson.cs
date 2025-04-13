using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaVisualizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeManwhaPropertiesToJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterNumber",
                table: "Manwha.Manwha");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Manwha.Manwha");

            migrationBuilder.DropColumn(
                name: "PagesCount",
                table: "Manwha.Manwha");

            migrationBuilder.RenameColumn(
                name: "PageExtension",
                table: "Manwha.Manwha",
                newName: "Logos");

            migrationBuilder.AddColumn<string>(
                name: "Chapters",
                table: "Manwha.Manwha",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chapters",
                table: "Manwha.Manwha");

            migrationBuilder.RenameColumn(
                name: "Logos",
                table: "Manwha.Manwha",
                newName: "PageExtension");

            migrationBuilder.AddColumn<int>(
                name: "ChapterNumber",
                table: "Manwha.Manwha",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Manwha.Manwha",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PagesCount",
                table: "Manwha.Manwha",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
