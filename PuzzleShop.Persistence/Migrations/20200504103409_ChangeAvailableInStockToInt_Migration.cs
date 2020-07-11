using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class ChangeAvailableInStockToInt_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AvailableInStock",
                table: "Puzzles",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 778, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3827), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3921), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3932), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3940), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3944), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3951), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3959), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3966), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0, new DateTimeOffset(new DateTime(2020, 5, 4, 13, 34, 8, 780, DateTimeKind.Unspecified).AddTicks(3970), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AvailableInStock",
                table: "Puzzles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 367, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2591), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2730), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2749), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2776), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2787), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2813), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2825), new TimeSpan(0, 3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "AvailableInStock", "DateWhenAdded" },
                values: new object[] { 0L, new DateTimeOffset(new DateTime(2020, 5, 1, 12, 42, 21, 372, DateTimeKind.Unspecified).AddTicks(2836), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
