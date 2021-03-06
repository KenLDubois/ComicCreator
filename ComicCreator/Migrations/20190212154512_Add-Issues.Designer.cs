﻿// <auto-generated />
using System;
using ComicCreator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComicCreator.Migrations
{
    [DbContext(typeof(ComicCreatorContext))]
    [Migration("20190212154512_Add-Issues")]
    partial class AddIssues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MU")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComicCreator.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CoverImageContent");

                    b.Property<string>("CoverImageFileName")
                        .HasMaxLength(100);

                    b.Property<string>("CoverImageMimeType")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("TitleId");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("ComicCreator.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<byte[]>("TitleImageContent");

                    b.Property<string>("TitleImageFileName")
                        .HasMaxLength(100);

                    b.Property<string>("TitleImageMimeType")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("ComicCreator.Models.Issue", b =>
                {
                    b.HasOne("ComicCreator.Models.Title", "Title")
                        .WithMany("Issues")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
