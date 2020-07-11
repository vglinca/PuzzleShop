using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class RemoveIsRCfromPuzzleAddIsRubicsCubeToPuzzleType_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRubicsCube",
                table: "Puzzles");

            migrationBuilder.AddColumn<bool>(
                name: "IsRubicsCube",
                table: "PuzzleTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsRubicsCube",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsRubicsCube",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsRubicsCube",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsRubicsCube",
                value: true);

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 376, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3651), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3658), new TimeSpan(0, 3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRubicsCube",
                table: "PuzzleTypes");

            migrationBuilder.AddColumn<bool>(
                name: "IsRubicsCube",
                table: "Puzzles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 484, DateTimeKind.Unspecified).AddTicks(4606), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(7959), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8080), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8084), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8095), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateWhenAdded", "IsRubicsCube" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8118), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 19, 0, 14, 28, 486, DateTimeKind.Unspecified).AddTicks(8122), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
