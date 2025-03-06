using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Migrations
{
    /// <inheritdoc />
    public partial class JournalToCategoryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JournalEntries",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_CategoryId",
                table: "JournalEntries",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_Categories_CategoryId",
                table: "JournalEntries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_Categories_CategoryId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_CategoryId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JournalEntries");
        }
    }
}
