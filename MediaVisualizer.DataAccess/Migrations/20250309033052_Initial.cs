using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaVisualizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime.Anime",
                columns: table => new
                {
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    Video = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime.Anime", x => x.AnimeId);
                });

            migrationBuilder.CreateTable(
                name: "Manga.Manga",
                columns: table => new
                {
                    MangaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    PageExtension = table.Column<string>(type: "TEXT", nullable: false),
                    PagesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga.Manga", x => x.MangaId);
                });

            migrationBuilder.CreateTable(
                name: "Manwha.Manwha",
                columns: table => new
                {
                    ManwhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PagesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    PageExtension = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manwha.Manwha", x => x.ManwhaId);
                });

            migrationBuilder.CreateTable(
                name: "Shared.Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared.Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Shared.Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared.Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Shared.Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared.Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Manga.MangaArtist",
                columns: table => new
                {
                    MangaArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MangaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga.MangaArtist", x => x.MangaArtistId);
                    table.ForeignKey(
                        name: "FK_Manga.MangaArtist_Manga.Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga.Manga",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manga.MangaArtist_Shared.Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Shared.Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manwha.ManwhaArtist",
                columns: table => new
                {
                    ManwhaArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManwhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manwha.ManwhaArtist", x => x.ManwhaArtistId);
                    table.ForeignKey(
                        name: "FK_Manwha.ManwhaArtist_Manwha.Manwha_ManwhaId",
                        column: x => x.ManwhaId,
                        principalTable: "Manwha.Manwha",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manwha.ManwhaArtist_Shared.Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Shared.Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anime.AnimeBrand",
                columns: table => new
                {
                    AnimeBrandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime.AnimeBrand", x => x.AnimeBrandId);
                    table.ForeignKey(
                        name: "FK_Anime.AnimeBrand_Anime.Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime.Anime",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anime.AnimeBrand_Shared.Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Shared.Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anime.AnimeTag",
                columns: table => new
                {
                    AnimeTagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime.AnimeTag", x => x.AnimeTagId);
                    table.ForeignKey(
                        name: "FK_Anime.AnimeTag_Anime.Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime.Anime",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anime.AnimeTag_Shared.Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Shared.Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manga.MangaTag",
                columns: table => new
                {
                    MangaTagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MangaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga.MangaTag", x => x.MangaTagId);
                    table.ForeignKey(
                        name: "FK_Manga.MangaTag_Manga.Manga_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Manga.Manga",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manga.MangaTag_Shared.Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Shared.Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manwha.ManwhaTag",
                columns: table => new
                {
                    ManwhaTagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManwhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manwha.ManwhaTag", x => x.ManwhaTagId);
                    table.ForeignKey(
                        name: "FK_Manwha.ManwhaTag_Manwha.Manwha_ManwhaId",
                        column: x => x.ManwhaId,
                        principalTable: "Manwha.Manwha",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manwha.ManwhaTag_Shared.Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Shared.Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime.AnimeBrand_AnimeId",
                table: "Anime.AnimeBrand",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime.AnimeBrand_BrandId",
                table: "Anime.AnimeBrand",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime.AnimeTag_AnimeId",
                table: "Anime.AnimeTag",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime.AnimeTag_TagId",
                table: "Anime.AnimeTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga.MangaArtist_ArtistId",
                table: "Manga.MangaArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga.MangaArtist_MangaId",
                table: "Manga.MangaArtist",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga.MangaTag_MangaId",
                table: "Manga.MangaTag",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga.MangaTag_TagId",
                table: "Manga.MangaTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Manwha.ManwhaArtist_ArtistId",
                table: "Manwha.ManwhaArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Manwha.ManwhaArtist_ManwhaId",
                table: "Manwha.ManwhaArtist",
                column: "ManwhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manwha.ManwhaTag_ManwhaId",
                table: "Manwha.ManwhaTag",
                column: "ManwhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manwha.ManwhaTag_TagId",
                table: "Manwha.ManwhaTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime.AnimeBrand");

            migrationBuilder.DropTable(
                name: "Anime.AnimeTag");

            migrationBuilder.DropTable(
                name: "Manga.MangaArtist");

            migrationBuilder.DropTable(
                name: "Manga.MangaTag");

            migrationBuilder.DropTable(
                name: "Manwha.ManwhaArtist");

            migrationBuilder.DropTable(
                name: "Manwha.ManwhaTag");

            migrationBuilder.DropTable(
                name: "Shared.Brand");

            migrationBuilder.DropTable(
                name: "Anime.Anime");

            migrationBuilder.DropTable(
                name: "Manga.Manga");

            migrationBuilder.DropTable(
                name: "Shared.Artist");

            migrationBuilder.DropTable(
                name: "Manwha.Manwha");

            migrationBuilder.DropTable(
                name: "Shared.Tag");
        }
    }
}
