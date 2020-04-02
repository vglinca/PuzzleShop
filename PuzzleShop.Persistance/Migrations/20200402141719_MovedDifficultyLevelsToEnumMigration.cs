using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class MovedDifficultyLevelsToEnumMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Levels_DifficultyLevelId",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Levels",
                table: "Levels");

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Levels");

            migrationBuilder.RenameTable(
                name: "Levels",
                newName: "DifficultyLevels");

            migrationBuilder.AddColumn<long>(
                name: "DifficultyLevelId",
                table: "DifficultyLevels",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DifficultyLevels",
                table: "DifficultyLevels",
                column: "DifficultyLevelId");

            migrationBuilder.InsertData(
                table: "DifficultyLevels",
                columns: new[] { "DifficultyLevelId", "Title" },
                values: new object[,]
                {
                    { 0L, "Low" },
                    { 1L, "Medium" },
                    { 2L, "High" },
                    { 3L, "ExtraHigh" }
                });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 927, DateTimeKind.Unspecified).AddTicks(2063), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2304), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2477), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2492), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2500), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2508), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2515), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2519), new TimeSpan(0, 3, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2526), new TimeSpan(0, 3, 0, 0, 0)), 0L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 2, 17, 17, 17, 930, DateTimeKind.Unspecified).AddTicks(2534), new TimeSpan(0, 3, 0, 0, 0)), 1L });

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_DifficultyLevels_DifficultyLevelId",
                table: "Puzzles",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "DifficultyLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_DifficultyLevels_DifficultyLevelId",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DifficultyLevels",
                table: "DifficultyLevels");

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 0L);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "DifficultyLevels",
                keyColumn: "DifficultyLevelId",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId",
                table: "DifficultyLevels");

            migrationBuilder.RenameTable(
                name: "DifficultyLevels",
                newName: "Levels");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Levels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Levels",
                table: "Levels",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1L, "Low" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2L, "Middle" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3L, "High" });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 88, DateTimeKind.Unspecified).AddTicks(1540), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5475), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5615), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5622), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5641), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5649), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5656), new TimeSpan(0, 2, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5664), new TimeSpan(0, 2, 0, 0, 0)), 1L });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateWhenAdded", "DifficultyLevelId" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 27, 19, 12, 32, 90, DateTimeKind.Unspecified).AddTicks(5671), new TimeSpan(0, 2, 0, 0, 0)), 2L });

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_Levels_DifficultyLevelId",
                table: "Puzzles",
                column: "DifficultyLevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
