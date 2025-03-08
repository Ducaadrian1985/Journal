using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJournalEntryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JournalEntryArchiveId",
                table: "JournalEntries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "JournalEntryArchiveId",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "JournalEntryArchiveId",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "JournalEntryArchiveId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JournalEntryArchiveId",
                table: "JournalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "JournalEntryArchiveId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "JournalEntryArchiveId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "JournalEntryArchiveId",
                value: 0);
        }
    }
}
