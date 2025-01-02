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
                name: "Animes",
                columns: table => new
                {
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.AnimeId);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
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
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
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
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    MangaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.MangaId);
                });

            migrationBuilder.CreateTable(
                name: "Manwhas",
                columns: table => new
                {
                    ManwhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folder = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Logos = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manwhas", x => x.ManwhaId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
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
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "AnimeChapters",
                columns: table => new
                {
                    AnimeChapterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    Video = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeChapters", x => x.AnimeChapterId);
                    table.ForeignKey(
                        name: "FK_AnimeChapters_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeBrand",
                columns: table => new
                {
                    AnimesAnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandsBrandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeBrand", x => new { x.AnimesAnimeId, x.BrandsBrandId });
                    table.ForeignKey(
                        name: "FK_AnimeBrand_Animes_AnimesAnimeId",
                        column: x => x.AnimesAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeBrand_Brands_BrandsBrandId",
                        column: x => x.BrandsBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistManga",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    MangasMangaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistManga", x => new { x.ArtistsArtistId, x.MangasMangaId });
                    table.ForeignKey(
                        name: "FK_ArtistManga_Artists_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistManga_Mangas_MangasMangaId",
                        column: x => x.MangasMangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorManga",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    MangasMangaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorManga", x => new { x.AuthorsAuthorId, x.MangasMangaId });
                    table.ForeignKey(
                        name: "FK_AuthorManga_Authors_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorManga_Mangas_MangasMangaId",
                        column: x => x.MangasMangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandManga",
                columns: table => new
                {
                    BrandsBrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    MangasMangaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandManga", x => new { x.BrandsBrandId, x.MangasMangaId });
                    table.ForeignKey(
                        name: "FK_BrandManga_Brands_BrandsBrandId",
                        column: x => x.BrandsBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandManga_Mangas_MangasMangaId",
                        column: x => x.MangasMangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaChapters",
                columns: table => new
                {
                    MangaChapterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MangaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PagesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    PageExtension = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaChapters", x => x.MangaChapterId);
                    table.ForeignKey(
                        name: "FK_MangaChapters_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistManwha",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManwhasManwhaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistManwha", x => new { x.ArtistsArtistId, x.ManwhasManwhaId });
                    table.ForeignKey(
                        name: "FK_ArtistManwha_Artists_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistManwha_Manwhas_ManwhasManwhaId",
                        column: x => x.ManwhasManwhaId,
                        principalTable: "Manwhas",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorManwha",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManwhasManwhaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorManwha", x => new { x.AuthorsAuthorId, x.ManwhasManwhaId });
                    table.ForeignKey(
                        name: "FK_AuthorManwha_Authors_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorManwha_Manwhas_ManwhasManwhaId",
                        column: x => x.ManwhasManwhaId,
                        principalTable: "Manwhas",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandManwha",
                columns: table => new
                {
                    BrandsBrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManwhasManwhaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandManwha", x => new { x.BrandsBrandId, x.ManwhasManwhaId });
                    table.ForeignKey(
                        name: "FK_BrandManwha_Brands_BrandsBrandId",
                        column: x => x.BrandsBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandManwha_Manwhas_ManwhasManwhaId",
                        column: x => x.ManwhasManwhaId,
                        principalTable: "Manwhas",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaChapters",
                columns: table => new
                {
                    ManwhaChapterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManwhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChapterNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PagesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    PageExtension = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaChapters", x => x.ManwhaChapterId);
                    table.ForeignKey(
                        name: "FK_ManwhaChapters_Manwhas_ManwhaId",
                        column: x => x.ManwhaId,
                        principalTable: "Manwhas",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeTag",
                columns: table => new
                {
                    AnimesAnimeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsTagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeTag", x => new { x.AnimesAnimeId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_AnimeTag_Animes_AnimesAnimeId",
                        column: x => x.AnimesAnimeId,
                        principalTable: "Animes",
                        principalColumn: "AnimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaTag",
                columns: table => new
                {
                    MangasMangaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsTagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTag", x => new { x.MangasMangaId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_MangaTag_Mangas_MangasMangaId",
                        column: x => x.MangasMangaId,
                        principalTable: "Mangas",
                        principalColumn: "MangaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManwhaTag",
                columns: table => new
                {
                    ManwhasManwhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsTagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManwhaTag", x => new { x.ManwhasManwhaId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_ManwhaTag_Manwhas_ManwhasManwhaId",
                        column: x => x.ManwhasManwhaId,
                        principalTable: "Manwhas",
                        principalColumn: "ManwhaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManwhaTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeBrand_BrandsBrandId",
                table: "AnimeBrand",
                column: "BrandsBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeChapters_AnimeId",
                table: "AnimeChapters",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTag_TagsTagId",
                table: "AnimeTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistManga_MangasMangaId",
                table: "ArtistManga",
                column: "MangasMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistManwha_ManwhasManwhaId",
                table: "ArtistManwha",
                column: "ManwhasManwhaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorManga_MangasMangaId",
                table: "AuthorManga",
                column: "MangasMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorManwha_ManwhasManwhaId",
                table: "AuthorManwha",
                column: "ManwhasManwhaId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandManga_MangasMangaId",
                table: "BrandManga",
                column: "MangasMangaId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandManwha_ManwhasManwhaId",
                table: "BrandManwha",
                column: "ManwhasManwhaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaChapters_MangaId",
                table: "MangaChapters",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaTag_TagsTagId",
                table: "MangaTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaChapters_ManwhaId",
                table: "ManwhaChapters",
                column: "ManwhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ManwhaTag_TagsTagId",
                table: "ManwhaTag",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeBrand");

            migrationBuilder.DropTable(
                name: "AnimeChapters");

            migrationBuilder.DropTable(
                name: "AnimeTag");

            migrationBuilder.DropTable(
                name: "ArtistManga");

            migrationBuilder.DropTable(
                name: "ArtistManwha");

            migrationBuilder.DropTable(
                name: "AuthorManga");

            migrationBuilder.DropTable(
                name: "AuthorManwha");

            migrationBuilder.DropTable(
                name: "BrandManga");

            migrationBuilder.DropTable(
                name: "BrandManwha");

            migrationBuilder.DropTable(
                name: "MangaChapters");

            migrationBuilder.DropTable(
                name: "MangaTag");

            migrationBuilder.DropTable(
                name: "ManwhaChapters");

            migrationBuilder.DropTable(
                name: "ManwhaTag");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Manwhas");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
