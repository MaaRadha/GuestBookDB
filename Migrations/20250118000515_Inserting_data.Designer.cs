﻿// <auto-generated />
using System;
using FeedBackWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FeedBackWebApi.Migrations
{
    [DbContext(typeof(FeedbackDBContext))]
    [Migration("20250118000515_Inserting_data")]
    partial class Inserting_data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FeedBackWebApi.Models.PostComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("PostComments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Keep going",
                            CreatedAt = new DateTime(2025, 1, 17, 1, 5, 14, 634, DateTimeKind.Local).AddTicks(4953),
                            FullName = "Astri05"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Looks ok but more things i can see to work on ",
                            CreatedAt = new DateTime(2025, 1, 16, 1, 5, 14, 634, DateTimeKind.Local).AddTicks(4998),
                            FullName = "Martin"
                        });
                });

            modelBuilder.Entity("FeedBackWebApi.Models.PostReaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<int>("Hearts")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("PostCommentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PostReactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dislikes = 0,
                            Hearts = 0,
                            Likes = 1,
                            PostCommentId = 2
                        },
                        new
                        {
                            Id = 2,
                            Dislikes = 0,
                            Hearts = 0,
                            Likes = 1,
                            PostCommentId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
