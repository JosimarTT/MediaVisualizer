﻿// <auto-generated />
using System;
using MediaVisualizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediaVisualizer.DataAccess.Migrations
{
    [DbContext(typeof(MediaVisualizerDbContext))]
    [Migration("20250323013748_DecimalToDouble")]
    partial class DecimalToDouble
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Anime.Anime", b =>
                {
                    b.Property<int>("AnimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Folder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Video")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AnimeId");

                    b.ToTable("Anime.Anime");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Anime.AnimeBrand", b =>
                {
                    b.Property<int>("AnimeBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimeBrandId");

                    b.HasIndex("AnimeId");

                    b.HasIndex("BrandId");

                    b.ToTable("Anime.AnimeBrand");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Anime.AnimeTag", b =>
                {
                    b.Property<int>("AnimeTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimeTagId");

                    b.HasIndex("AnimeId");

                    b.HasIndex("TagId");

                    b.ToTable("Anime.AnimeTag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manga.Manga", b =>
                {
                    b.Property<int>("MangaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("ChapterNumber")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Folder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PageExtension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PagesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("MangaId");

                    b.ToTable("Manga.Manga");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manga.MangaArtist", b =>
                {
                    b.Property<int>("MangaArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MangaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MangaArtistId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("MangaId");

                    b.ToTable("Manga.MangaArtist");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manga.MangaTag", b =>
                {
                    b.Property<int>("MangaTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MangaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MangaTagId");

                    b.HasIndex("MangaId");

                    b.HasIndex("TagId");

                    b.ToTable("Manga.MangaTag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manwha.Manwha", b =>
                {
                    b.Property<int>("ManwhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Folder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PageExtension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PagesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ManwhaId");

                    b.ToTable("Manwha.Manwha");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manwha.ManwhaArtist", b =>
                {
                    b.Property<int>("ManwhaArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManwhaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ManwhaArtistId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ManwhaId");

                    b.ToTable("Manwha.ManwhaArtist");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manwha.ManwhaTag", b =>
                {
                    b.Property<int>("ManwhaTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManwhaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ManwhaTagId");

                    b.HasIndex("ManwhaId");

                    b.HasIndex("TagId");

                    b.ToTable("Manwha.ManwhaTag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Shared.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Shared.Artist");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Shared.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("BrandId");

                    b.ToTable("Shared.Brand");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Shared.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Shared.Tag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Anime.AnimeBrand", b =>
                {
                    b.HasOne("MediaVisualizer.DataAccess.Entities.Anime.Anime", "Anime")
                        .WithMany("AnimeBrands")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaVisualizer.DataAccess.Entities.Shared.Brand", "Brand")
                        .WithMany("AnimeBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Anime.AnimeTag", b =>
                {
                    b.HasOne("MediaVisualizer.DataAccess.Entities.Anime.Anime", "Anime")
                        .WithMany("AnimeTags")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaVisualizer.DataAccess.Entities.Shared.Tag", "Tag")
                        .WithMany("AnimeTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manga.MangaArtist", b =>
                {
                    b.HasOne("MediaVisualizer.DataAccess.Entities.Shared.Artist", "Artist")
                        .WithMany("MangasArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaVisualizer.DataAccess.Entities.Manga.Manga", "Manga")
                        .WithMany("MangaArtists")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manga.MangaTag", b =>
                {
                    b.HasOne("MediaVisualizer.DataAccess.Entities.Manga.Manga", "Manga")
                        .WithMany("MangaTags")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaVisualizer.DataAccess.Entities.Shared.Tag", "Tag")
                        .WithMany("MangaTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manga");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manwha.ManwhaArtist", b =>
                {
                    b.HasOne("MediaVisualizer.DataAccess.Entities.Shared.Artist", "Artist")
                        .WithMany("ManwhasArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaVisualizer.DataAccess.Entities.Manwha.Manwha", "Manwha")
                        .WithMany("ManwhaArtists")
                        .HasForeignKey("ManwhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Manwha");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manwha.ManwhaTag", b =>
                {
                    b.HasOne("MediaVisualizer.DataAccess.Entities.Manwha.Manwha", "Manwha")
                        .WithMany("ManwhaTags")
                        .HasForeignKey("ManwhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaVisualizer.DataAccess.Entities.Shared.Tag", "Tag")
                        .WithMany("ManwhaTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manwha");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Anime.Anime", b =>
                {
                    b.Navigation("AnimeBrands");

                    b.Navigation("AnimeTags");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manga.Manga", b =>
                {
                    b.Navigation("MangaArtists");

                    b.Navigation("MangaTags");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Manwha.Manwha", b =>
                {
                    b.Navigation("ManwhaArtists");

                    b.Navigation("ManwhaTags");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Shared.Artist", b =>
                {
                    b.Navigation("MangasArtists");

                    b.Navigation("ManwhasArtists");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Shared.Brand", b =>
                {
                    b.Navigation("AnimeBrands");
                });

            modelBuilder.Entity("MediaVisualizer.DataAccess.Entities.Shared.Tag", b =>
                {
                    b.Navigation("AnimeTags");

                    b.Navigation("MangaTags");

                    b.Navigation("ManwhaTags");
                });
#pragma warning restore 612, 618
        }
    }
}
