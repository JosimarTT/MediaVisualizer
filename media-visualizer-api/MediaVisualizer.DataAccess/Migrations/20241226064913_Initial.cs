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
                name: "anime.anime",
                columns: table => new
                {
                    anime_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    folder = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime.anime", x => x.anime_key);
                });

            migrationBuilder.CreateTable(
                name: "manga.manga",
                columns: table => new
                {
                    manga_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    folder = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manga.manga", x => x.manga_key);
                });

            migrationBuilder.CreateTable(
                name: "manwha.manwha",
                columns: table => new
                {
                    manwha_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    folder = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manwha.manwha", x => x.manwha_key);
                });

            migrationBuilder.CreateTable(
                name: "shared.artist",
                columns: table => new
                {
                    artist_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shared.artist", x => x.artist_key);
                });

            migrationBuilder.CreateTable(
                name: "shared.author",
                columns: table => new
                {
                    author_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shared.author", x => x.author_key);
                });

            migrationBuilder.CreateTable(
                name: "shared.brand",
                columns: table => new
                {
                    brand_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shared.brand", x => x.brand_key);
                });

            migrationBuilder.CreateTable(
                name: "shared.tag",
                columns: table => new
                {
                    tag_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shared.tag", x => x.tag_key);
                });

            migrationBuilder.CreateTable(
                name: "anime.chapter",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    anime_key = table.Column<int>(type: "INTEGER", nullable: false),
                    chapter_number = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime.chapter", x => x.chapter_key);
                    table.ForeignKey(
                        name: "FK_anime.chapter_anime.anime_anime_key",
                        column: x => x.anime_key,
                        principalTable: "anime.anime",
                        principalColumn: "anime_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manga.chapter",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    manga_key = table.Column<int>(type: "INTEGER", nullable: false),
                    chapter_number = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manga.chapter", x => x.chapter_key);
                    table.ForeignKey(
                        name: "FK_manga.chapter_manga.manga_manga_key",
                        column: x => x.manga_key,
                        principalTable: "manga.manga",
                        principalColumn: "manga_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manwha.chapter",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    manwha_key = table.Column<int>(type: "INTEGER", nullable: false),
                    chapter_number = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manwha.chapter", x => x.chapter_key);
                    table.ForeignKey(
                        name: "FK_manwha.chapter_manwha.manwha_manwha_key",
                        column: x => x.manwha_key,
                        principalTable: "manwha.manwha",
                        principalColumn: "manwha_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "anime.chapter_brand",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    brand_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime.chapter_brand", x => new { x.chapter_key, x.brand_key });
                    table.ForeignKey(
                        name: "FK_anime.chapter_brand_anime.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "anime.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_anime.chapter_brand_shared.brand_brand_key",
                        column: x => x.brand_key,
                        principalTable: "shared.brand",
                        principalColumn: "brand_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "anime.chapter_tag",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    tag_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime.chapter_tag", x => new { x.chapter_key, x.tag_key });
                    table.ForeignKey(
                        name: "FK_anime.chapter_tag_anime.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "anime.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_anime.chapter_tag_shared.tag_tag_key",
                        column: x => x.tag_key,
                        principalTable: "shared.tag",
                        principalColumn: "tag_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manga.chapter_artist",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    artist_key = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manga.chapter_artist", x => new { x.chapter_key, x.artist_key });
                    table.ForeignKey(
                        name: "FK_manga.chapter_artist_manga.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manga.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manga.chapter_artist_shared.artist_artist_key",
                        column: x => x.artist_key,
                        principalTable: "shared.artist",
                        principalColumn: "artist_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manga.chapter_author",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    author_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manga.chapter_author", x => new { x.chapter_key, x.author_key });
                    table.ForeignKey(
                        name: "FK_manga.chapter_author_manga.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manga.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manga.chapter_author_shared.author_author_key",
                        column: x => x.author_key,
                        principalTable: "shared.author",
                        principalColumn: "author_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manga.chapter_brand",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    brand_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manga.chapter_brand", x => new { x.chapter_key, x.brand_key });
                    table.ForeignKey(
                        name: "FK_manga.chapter_brand_manga.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manga.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manga.chapter_brand_shared.brand_brand_key",
                        column: x => x.brand_key,
                        principalTable: "shared.brand",
                        principalColumn: "brand_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manga.chapter_tag",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    tag_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manga.chapter_tag", x => new { x.chapter_key, x.tag_key });
                    table.ForeignKey(
                        name: "FK_manga.chapter_tag_manga.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manga.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manga.chapter_tag_shared.tag_tag_key",
                        column: x => x.tag_key,
                        principalTable: "shared.tag",
                        principalColumn: "tag_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manwha.chapter_artist",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    artist_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manwha.chapter_artist", x => new { x.chapter_key, x.artist_key });
                    table.ForeignKey(
                        name: "FK_manwha.chapter_artist_manwha.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manwha.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manwha.chapter_artist_shared.artist_artist_key",
                        column: x => x.artist_key,
                        principalTable: "shared.artist",
                        principalColumn: "artist_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manwha.chapter_author",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    author_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manwha.chapter_author", x => new { x.chapter_key, x.author_key });
                    table.ForeignKey(
                        name: "FK_manwha.chapter_author_manwha.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manwha.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manwha.chapter_author_shared.author_author_key",
                        column: x => x.author_key,
                        principalTable: "shared.author",
                        principalColumn: "author_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manwha.chapter_brand",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    brand_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manwha.chapter_brand", x => new { x.chapter_key, x.brand_key });
                    table.ForeignKey(
                        name: "FK_manwha.chapter_brand_manwha.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manwha.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manwha.chapter_brand_shared.brand_brand_key",
                        column: x => x.brand_key,
                        principalTable: "shared.brand",
                        principalColumn: "brand_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "manwha.chapter_tag",
                columns: table => new
                {
                    chapter_key = table.Column<int>(type: "INTEGER", nullable: false),
                    tag_key = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manwha.chapter_tag", x => new { x.chapter_key, x.tag_key });
                    table.ForeignKey(
                        name: "FK_manwha.chapter_tag_manwha.chapter_chapter_key",
                        column: x => x.chapter_key,
                        principalTable: "manwha.chapter",
                        principalColumn: "chapter_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_manwha.chapter_tag_shared.tag_tag_key",
                        column: x => x.tag_key,
                        principalTable: "shared.tag",
                        principalColumn: "tag_key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anime.chapter_anime_key",
                table: "anime.chapter",
                column: "anime_key");

            migrationBuilder.CreateIndex(
                name: "IX_anime.chapter_brand_brand_key",
                table: "anime.chapter_brand",
                column: "brand_key");

            migrationBuilder.CreateIndex(
                name: "IX_anime.chapter_tag_tag_key",
                table: "anime.chapter_tag",
                column: "tag_key");

            migrationBuilder.CreateIndex(
                name: "IX_manga.chapter_manga_key",
                table: "manga.chapter",
                column: "manga_key");

            migrationBuilder.CreateIndex(
                name: "IX_manga.chapter_artist_artist_key",
                table: "manga.chapter_artist",
                column: "artist_key");

            migrationBuilder.CreateIndex(
                name: "IX_manga.chapter_author_author_key",
                table: "manga.chapter_author",
                column: "author_key");

            migrationBuilder.CreateIndex(
                name: "IX_manga.chapter_brand_brand_key",
                table: "manga.chapter_brand",
                column: "brand_key");

            migrationBuilder.CreateIndex(
                name: "IX_manga.chapter_tag_tag_key",
                table: "manga.chapter_tag",
                column: "tag_key");

            migrationBuilder.CreateIndex(
                name: "IX_manwha.chapter_manwha_key",
                table: "manwha.chapter",
                column: "manwha_key");

            migrationBuilder.CreateIndex(
                name: "IX_manwha.chapter_artist_artist_key",
                table: "manwha.chapter_artist",
                column: "artist_key");

            migrationBuilder.CreateIndex(
                name: "IX_manwha.chapter_author_author_key",
                table: "manwha.chapter_author",
                column: "author_key");

            migrationBuilder.CreateIndex(
                name: "IX_manwha.chapter_brand_brand_key",
                table: "manwha.chapter_brand",
                column: "brand_key");

            migrationBuilder.CreateIndex(
                name: "IX_manwha.chapter_tag_tag_key",
                table: "manwha.chapter_tag",
                column: "tag_key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anime.chapter_brand");

            migrationBuilder.DropTable(
                name: "anime.chapter_tag");

            migrationBuilder.DropTable(
                name: "manga.chapter_artist");

            migrationBuilder.DropTable(
                name: "manga.chapter_author");

            migrationBuilder.DropTable(
                name: "manga.chapter_brand");

            migrationBuilder.DropTable(
                name: "manga.chapter_tag");

            migrationBuilder.DropTable(
                name: "manwha.chapter_artist");

            migrationBuilder.DropTable(
                name: "manwha.chapter_author");

            migrationBuilder.DropTable(
                name: "manwha.chapter_brand");

            migrationBuilder.DropTable(
                name: "manwha.chapter_tag");

            migrationBuilder.DropTable(
                name: "anime.chapter");

            migrationBuilder.DropTable(
                name: "manga.chapter");

            migrationBuilder.DropTable(
                name: "shared.artist");

            migrationBuilder.DropTable(
                name: "shared.author");

            migrationBuilder.DropTable(
                name: "shared.brand");

            migrationBuilder.DropTable(
                name: "manwha.chapter");

            migrationBuilder.DropTable(
                name: "shared.tag");

            migrationBuilder.DropTable(
                name: "anime.anime");

            migrationBuilder.DropTable(
                name: "manga.manga");

            migrationBuilder.DropTable(
                name: "manwha.manwha");
        }
    }
}
