using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Migrations
{
    /// <inheritdoc />
    public partial class JournalEntryArchiveTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JournalEntryArchiveId",
                table: "JournalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JournalEntryArchives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntryArchives_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryArchives_JournalEntryId",
                table: "JournalEntryArchives",
                column: "JournalEntryId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntryArchives");

            migrationBuilder.DropColumn(
                name: "JournalEntryArchiveId",
                table: "JournalEntries");
        }
    }
}
