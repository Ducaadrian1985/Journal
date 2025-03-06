using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Journal.Migrations
{
    /// <inheritdoc />
    public partial class TagMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "JournalEntries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagId",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagId",
                value: null);

            migrationBuilder.UpdateData(
                table: "JournalEntries",
                keyColumn: "Id",
                keyValue: 3,
                column: "TagId",
                value: null);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Important" },
                    { 2, "Urgent" },
                    { 3, "Optional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_TagId",
                table: "JournalEntries",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_Tags_TagId",
                table: "JournalEntries",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_Tags_TagId",
                table: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_TagId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "JournalEntries");
        }
    }
}
