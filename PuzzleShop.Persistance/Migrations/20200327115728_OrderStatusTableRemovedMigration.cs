using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class OrderStatusTableRemovedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdeStatusList_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrdeStatusList");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_PuzzleId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 786, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(6973), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7094), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7165), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7169), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7177), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7184), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7188), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7195), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 13, 57, 27, 788, DateTimeKind.Unspecified).AddTicks(7203), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PuzzleId",
                table: "OrderItems",
                column: "PuzzleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItems_PuzzleId",
                table: "OrderItems");

            migrationBuilder.AddColumn<long>(
                name: "OrderStatusId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrdeStatusList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdeStatusList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrdeStatusList",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1L, "NotSubmited" },
                    { 2L, "Submited" },
                    { 3L, "Dispatched" },
                    { 4L, "Arrived" }
                });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 71, DateTimeKind.Unspecified).AddTicks(3723), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(6876), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(6997), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7111), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7118), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7126), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7133), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7141), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7148), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 24, 19, 2, 38, 73, DateTimeKind.Unspecified).AddTicks(7156), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PuzzleId",
                table: "OrderItems",
                column: "PuzzleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdeStatusList_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrdeStatusList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
