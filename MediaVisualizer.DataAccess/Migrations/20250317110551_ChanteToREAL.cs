using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaVisualizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChanteToREAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ChapterNumber",
                table: "Manga.Manga",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChapterNumber",
                table: "Manga.Manga",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");
        }
    }
}
