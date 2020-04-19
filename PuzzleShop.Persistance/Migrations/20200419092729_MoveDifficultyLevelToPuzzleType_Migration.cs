using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class MoveDifficultyLevelToPuzzleType_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_DifficultyLevels_DifficultyLevelId",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_DifficultyLevelId",
                table: "Puzzles");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "Puzzles");

            migrationBuilder.AddColumn<long>(
                name: "DifficultyLevelId",
                table: "PuzzleTypes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DifficultyLevelId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DifficultyLevelId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DifficultyLevelId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DifficultyLevelId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DifficultyLevelId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DifficultyLevelId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 286, DateTimeKind.Unspecified).AddTicks(1488), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2264), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2275), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2287), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2298), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2309), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2321), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 12, 27, 28, 289, DateTimeKind.Unspecified).AddTicks(2336), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_PuzzleTypes_DifficultyLevelId",
                table: "PuzzleTypes",
                column: "DifficultyLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PuzzleTypes_DifficultyLevels_DifficultyLevelId",
                table: "PuzzleTypes",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "DifficultyLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuzzleTypes_DifficultyLevels_DifficultyLevelId",
                table: "PuzzleTypes");

            migrationBuilder.DropIndex(
                name: "IX_PuzzleTypes_DifficultyLevelId",
                table: "PuzzleTypes");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "PuzzleTypes");

            migrationBuilder.AddColumn<long>(
                name: "DifficultyLevelId",
                table: "Puzzles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FileName", "PuzzleId", "Title" },
                values: new object[,]
                {
                    { 1L, "testfilename", 1L, null },
                    { 2L, "testfilename", 2L, null }
                });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 186, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4319), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4338), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4349), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4368), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4379), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_DifficultyLevelId",
                table: "Puzzles",
                column: "DifficultyLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_DifficultyLevels_DifficultyLevelId",
                table: "Puzzles",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "DifficultyLevelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
