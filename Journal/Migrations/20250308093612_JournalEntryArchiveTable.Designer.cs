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
    [Migration("20250308093612_JournalEntryArchiveTable")]
    partial class JournalEntryArchiveTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Journal.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Personal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Travel"
                        });
                });

            modelBuilder.Entity("Journal.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("JournalEntryArchiveId")
                        .HasColumnType("int");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TagId");

                    b.ToTable("JournalEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is the first entry",
                            Created = new DateTime(2025, 2, 14, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            JournalEntryArchiveId = 0,
                            Title = "First Entry"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is the second entry",
                            Created = new DateTime(2025, 2, 15, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            JournalEntryArchiveId = 0,
                            Title = "Second Entry"
                        },
                        new
                        {
                            Id = 3,
                            Content = "This is the third entry",
                            Created = new DateTime(2025, 2, 16, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            JournalEntryArchiveId = 0,
                            Title = "Third Entry"
                        });
                });

            modelBuilder.Entity("Journal.Models.JournalEntryArchive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JournalEntryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JournalEntryId")
                        .IsUnique();

                    b.ToTable("JournalEntryArchives");
                });

            modelBuilder.Entity("Journal.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Important"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Urgent"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Optional"
                        });
                });

            modelBuilder.Entity("Journal.Models.JournalEntry", b =>
                {
                    b.HasOne("Journal.Models.Category", "Category")
                        .WithMany("JournalEntries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Journal.Models.Tag", "Tag")
                        .WithMany("JournalEntries")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Journal.Models.JournalEntryArchive", b =>
                {
                    b.HasOne("Journal.Models.JournalEntry", "JournalEntry")
                        .WithOne("JournalEntryArchive")
                        .HasForeignKey("Journal.Models.JournalEntryArchive", "JournalEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JournalEntry");
                });

            modelBuilder.Entity("Journal.Models.Category", b =>
                {
                    b.Navigation("JournalEntries");
                });

            modelBuilder.Entity("Journal.Models.JournalEntry", b =>
                {
                    b.Navigation("JournalEntryArchive");
                });

            modelBuilder.Entity("Journal.Models.Tag", b =>
                {
                    b.Navigation("JournalEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
