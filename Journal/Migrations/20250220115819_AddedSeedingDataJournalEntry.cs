﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Journal.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataJournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JournalEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "This is the first entry", new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "First Entry" },
                    { 2, "This is the second entry", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Entry" },
                    { 3, "This is the third entry", new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Third Entry" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
