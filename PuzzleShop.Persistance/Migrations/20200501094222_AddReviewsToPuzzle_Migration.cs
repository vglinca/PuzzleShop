using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class AddReviewsToPuzzle_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuzzleId = table.Column<long>(nullable: false),
                    ReviewerName = table.Column<string>(nullable: true),
                    ReviewerEmail = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: true),
                    ReviewTitle = table.Column<string>(nullable: true),
                    ReviewBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Puzzles_PuzzleId",
                        column: x => x.PuzzleId,
                        principalTable: "Puzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 367, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2591), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2730), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2749), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2787), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2813), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2825), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PuzzleId",
                table: "Reviews",
                column: "PuzzleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 400, DateTimeKind.Unspecified).AddTicks(4277), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8665), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8684), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8688), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8695), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8703), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8710), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 28, 11, 47, 38, 402, DateTimeKind.Unspecified).AddTicks(8714), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
