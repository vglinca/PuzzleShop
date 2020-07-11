using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class AddIsRubicsCubeField_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRubicsCube",
                table: "Puzzles",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRubicsCube",
                table: "Puzzles");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 348, DateTimeKind.Unspecified).AddTicks(1860), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6331), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6441), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6452), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6459), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6467), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6478), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6486), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 4, 17, 19, 11, 53, 350, DateTimeKind.Unspecified).AddTicks(6493), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
