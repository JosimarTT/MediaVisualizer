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
                name: "Anime",
                columns: table => new
                {
                    AnimeKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.AnimeKey);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistKey);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorKey);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandKey);
                });

            migrationBuilder.CreateTable(
                name: "Manga",
                columns: table => new
                {
                    MangaKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.MangaKey);
                });

            migrationBuilder.CreateTable(
                name: "Manwha",
                columns: table => new
                {
                    ManwhaKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manwha", x => x.ManwhaKey);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagKey);
                });

            migrationBuilder.CreateTable(
                name: "AnimeChapter",
                columns: table => new
                {
                    AnimeChapterKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeKey = table.Column<int>(type: "INTEGER", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeChapter", x => x.AnimeChapterKey);
                    table.ForeignKey(
                        name: "FK_AnimeChapter_Anime_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Anime",
                        principalColumn: "AnimeKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeBrand",
                columns: table => new
                {
                    AnimeKey = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeBrand", x => new { x.AnimeKey, x.BrandKey });
                    table.ForeignKey(
                        name: "FK_AnimeBrand_Anime_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Anime",
                        principalColumn: "AnimeKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeBrand_Brand_BrandKey",
                        column: x => x.BrandKey,
                        principalTable: "Brand",
                        principalColumn: "BrandKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaArtist",
                columns: table => new
                {
                    MangaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaArtist", x => new { x.MangaKey, x.ArtistKey });
                    table.ForeignKey(
                        name: "FK_MangaArtist_Artist_ArtistKey",
                        column: x => x.ArtistKey,
                        principalTable: "Artist",
                        principalColumn: "ArtistKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaArtist_Manga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Manga",
                        principalColumn: "MangaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthor",
                columns: table => new
                {
                    MangaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthor", x => new { x.MangaKey, x.AuthorKey });
                    table.ForeignKey(
                        name: "FK_MangaAuthor_Author_AuthorKey",
                        column: x => x.AuthorKey,
                        principalTable: "Author",
                        principalColumn: "AuthorKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaAuthor_Manga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Manga",
                        principalColumn: "MangaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaBrand",
                columns: table => new
                {
                    MangaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaBrand", x => new { x.MangaKey, x.BrandKey });
                    table.ForeignKey(
                        name: "FK_MangaBrand_Brand_BrandKey",
                        column: x => x.BrandKey,
                        principalTable: "Brand",
                        principalColumn: "BrandKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaBrand_Manga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Manga",
                        principalColumn: "MangaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaChapter",
                columns: table => new
                {
                    MangaChapterKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MangaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaChapter", x => x.MangaChapterKey);
                    table.ForeignKey(
                        name: "FK_MangaChapter_Manga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Manga",
                        principalColumn: "MangaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaArtist",
                columns: table => new
                {
                    ManwhaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaArtist", x => new { x.ManwhaKey, x.ArtistKey });
                    table.ForeignKey(
                        name: "FK_ManwhaArtist_Artist_ArtistKey",
                        column: x => x.ArtistKey,
                        principalTable: "Artist",
                        principalColumn: "ArtistKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManwhaArtist_Manwha_ManwhaKey",
                        column: x => x.ManwhaKey,
                        principalTable: "Manwha",
                        principalColumn: "ManwhaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaAuthor",
                columns: table => new
                {
                    ManwhaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaAuthor", x => new { x.ManwhaKey, x.AuthorKey });
                    table.ForeignKey(
                        name: "FK_ManwhaAuthor_Author_AuthorKey",
                        column: x => x.AuthorKey,
                        principalTable: "Author",
                        principalColumn: "AuthorKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManwhaAuthor_Manwha_ManwhaKey",
                        column: x => x.ManwhaKey,
                        principalTable: "Manwha",
                        principalColumn: "ManwhaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaBrand",
                columns: table => new
                {
                    ManwhaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaBrand", x => new { x.ManwhaKey, x.BrandKey });
                    table.ForeignKey(
                        name: "FK_ManwhaBrand_Brand_BrandKey",
                        column: x => x.BrandKey,
                        principalTable: "Brand",
                        principalColumn: "BrandKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManwhaBrand_Manwha_ManwhaKey",
                        column: x => x.ManwhaKey,
                        principalTable: "Manwha",
                        principalColumn: "ManwhaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaChapter",
                columns: table => new
                {
                    ManwhaChapterKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManwhaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaChapter", x => x.ManwhaChapterKey);
                    table.ForeignKey(
                        name: "FK_ManwhaChapter_Manwha_ManwhaKey",
                        column: x => x.ManwhaKey,
                        principalTable: "Manwha",
                        principalColumn: "ManwhaKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeTag",
                columns: table => new
                {
                    AnimeKey = table.Column<int>(type: "INTEGER", nullable: false),
                    TagKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeTag", x => new { x.AnimeKey, x.TagKey });
                    table.ForeignKey(
                        name: "FK_AnimeTag_Anime_AnimeKey",
                        column: x => x.AnimeKey,
                        principalTable: "Anime",
                        principalColumn: "AnimeKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeTag_Tag_TagKey",
                        column: x => x.TagKey,
                        principalTable: "Tag",
                        principalColumn: "TagKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaTag",
                columns: table => new
                {
                    MangaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    TagKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTag", x => new { x.MangaKey, x.TagKey });
                    table.ForeignKey(
                        name: "FK_MangaTag_Manga_MangaKey",
                        column: x => x.MangaKey,
                        principalTable: "Manga",
                        principalColumn: "MangaKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaTag_Tag_TagKey",
                        column: x => x.TagKey,
                        principalTable: "Tag",
                        principalColumn: "TagKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaTag",
                columns: table => new
                {
                    ManwhaKey = table.Column<int>(type: "INTEGER", nullable: false),
                    TagKey = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaTag", x => new { x.ManwhaKey, x.TagKey });
                    table.ForeignKey(
                        name: "FK_ManwhaTag_Manwha_ManwhaKey",
                        column: x => x.ManwhaKey,
                        principalTable: "Manwha",
                        principalColumn: "ManwhaKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManwhaTag_Tag_TagKey",
                        column: x => x.TagKey,
                        principalTable: "Tag",
                        principalColumn: "TagKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeBrand_BrandKey",
                table: "AnimeBrand",
                column: "BrandKey");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeChapter_AnimeKey",
                table: "AnimeChapter",
                column: "AnimeKey");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTag_TagKey",
                table: "AnimeTag",
                column: "TagKey");

            migrationBuilder.CreateIndex(
                name: "IX_MangaArtist_ArtistKey",
                table: "MangaArtist",
                column: "ArtistKey");

            migrationBuilder.CreateIndex(
                name: "IX_MangaAuthor_AuthorKey",
                table: "MangaAuthor",
                column: "AuthorKey");

            migrationBuilder.CreateIndex(
                name: "IX_MangaBrand_BrandKey",
                table: "MangaBrand",
                column: "BrandKey");

            migrationBuilder.CreateIndex(
                name: "IX_MangaChapter_MangaKey",
                table: "MangaChapter",
                column: "MangaKey");

            migrationBuilder.CreateIndex(
                name: "IX_MangaTag_TagKey",
                table: "MangaTag",
                column: "TagKey");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaArtist_ArtistKey",
                table: "ManwhaArtist",
                column: "ArtistKey");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaAuthor_AuthorKey",
                table: "ManwhaAuthor",
                column: "AuthorKey");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaBrand_BrandKey",
                table: "ManwhaBrand",
                column: "BrandKey");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaChapter_ManwhaKey",
                table: "ManwhaChapter",
                column: "ManwhaKey");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaTag_TagKey",
                table: "ManwhaTag",
                column: "TagKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeBrand");

            migrationBuilder.DropTable(
                name: "AnimeChapter");

            migrationBuilder.DropTable(
                name: "AnimeTag");

            migrationBuilder.DropTable(
                name: "MangaArtist");

            migrationBuilder.DropTable(
                name: "MangaAuthor");

            migrationBuilder.DropTable(
                name: "MangaBrand");

            migrationBuilder.DropTable(
                name: "MangaChapter");

            migrationBuilder.DropTable(
                name: "MangaTag");

            migrationBuilder.DropTable(
                name: "ManwhaArtist");

            migrationBuilder.DropTable(
                name: "ManwhaAuthor");

            migrationBuilder.DropTable(
                name: "ManwhaBrand");

            migrationBuilder.DropTable(
                name: "ManwhaChapter");

            migrationBuilder.DropTable(
                name: "ManwhaTag");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Manga");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Manwha");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
