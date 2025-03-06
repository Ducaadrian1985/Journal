﻿// <auto-generated />
using System;
using Journal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Journal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250220115819_AddedSeedingDataJournalEntry")]
    partial class AddedSeedingDataJournalEntry
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Journal.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JournalEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is the first entry",
                            Created = new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "First Entry"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is the second entry",
                            Created = new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Second Entry"
                        },
                        new
                        {
                            Id = 3,
                            Content = "This is the third entry",
                            Created = new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Third Entry"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
