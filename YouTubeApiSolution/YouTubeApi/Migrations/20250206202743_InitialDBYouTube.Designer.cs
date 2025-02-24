﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YouTubeApi._4.Infrastructure.Data;

#nullable disable

namespace YouTubeApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250206202743_InitialDBYouTube")]
    partial class InitialDBYouTube
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("YouTubeApi._3.Domain.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Canal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Duracao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Excluido")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
