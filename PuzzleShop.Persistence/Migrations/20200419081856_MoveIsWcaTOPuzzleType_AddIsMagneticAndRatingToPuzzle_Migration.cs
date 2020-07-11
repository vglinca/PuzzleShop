using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class MoveIsWcaTOPuzzleType_AddIsMagneticAndRatingToPuzzle_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWcaPuzzle",
                table: "Puzzles");

            migrationBuilder.AddColumn<bool>(
                name: "IsWca",
                table: "PuzzleTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMagnetic",
                table: "Puzzles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Puzzles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "IsWca",
                value: true);

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 186, DateTimeKind.Unspecified).AddTicks(635), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4137), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4319), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4326), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4338), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4349), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4368), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateWhenAdded", "IsMagnetic" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 11, 18, 55, 189, DateTimeKind.Unspecified).AddTicks(4379), new TimeSpan(0, 3, 0, 0, 0)), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWca",
                table: "PuzzleTypes");

            migrationBuilder.DropColumn(
                name: "IsMagnetic",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Puzzles");

            migrationBuilder.AddColumn<bool>(
                name: "IsWcaPuzzle",
                table: "Puzzles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 376, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3609), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3617), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3624), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3632), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3643), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3651), new TimeSpan(0, 3, 0, 0, 0)), true });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "DateWhenAdded", "IsWcaPuzzle" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 4, 19, 0, 21, 17, 379, DateTimeKind.Unspecified).AddTicks(3658), new TimeSpan(0, 3, 0, 0, 0)), true });
        }
    }
}
