﻿using Journal.Models;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<JournalEntry> JournalEntries { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<JournalEntry>().HasData(
            new JournalEntry
            {
                Id = 1, Title = "First Entry", Content = "This is the first entry",
                Created = new DateTime(2025, 2, 14,10 ,0, 0)
            },
            new JournalEntry
            {
                Id = 2, Title = "Second Entry", Content = "This is the second entry",
                Created = new DateTime(2025, 2, 15, 12, 0, 0)
            },
            new JournalEntry
            {
                Id = 3, Title = "Third Entry", Content = "This is the third entry",
                Created = new DateTime(2025, 2, 16, 11, 0, 0)
            }
        );
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Personal" },
            new Category { Id = 2, Name = "Work" },
            new Category { Id = 3, Name = "Travel" }
        );
        modelBuilder.Entity<JournalEntry>().HasOne(JournalEntry => JournalEntry.Category)
            .WithMany(Category => Category!.JournalEntries)
            .HasForeignKey(JournalEntry => JournalEntry.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Tag>().HasData(
            new Tag { Id = 1, Name = "Important" },
            new Tag { Id = 2, Name = "Urgent" },
            new Tag { Id = 3, Name = "Optional" }
        );
        modelBuilder.Entity<JournalEntry>().HasOne(JournalEntry => JournalEntry.Tag)
            .WithMany(Tag => Tag!.JournalEntries)
            .HasForeignKey(JournalEntry => JournalEntry.TagId)
            .OnDelete(DeleteBehavior.SetNull);


    }
}