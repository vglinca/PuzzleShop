using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class OrderStatusChangedToEnumMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderStatusId",
                table: "Orders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "OrdeStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdeStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.InsertData(
                table: "OrdeStatuses",
                columns: new[] { "OrderStatusId", "Name" },
                values: new object[,]
                {
                    { 0L, "Pending" },
                    { 1L, "AwaitingPayment" },
                    { 2L, "ConfirmedPayment" },
                    { 3L, "AwaitingShipment" },
                    { 4L, "Completed" },
                    { 5L, "Cancelled" },
                    { 6L, "Declined" },
                    { 7L, "Refunded" }
                });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 769, DateTimeKind.Unspecified).AddTicks(3069), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5602), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5768), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5787), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5795), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5802), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5814), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5821), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5832), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 27, 14, 13, 34, 772, DateTimeKind.Unspecified).AddTicks(5844), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdeStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrdeStatuses",
                principalColumn: "OrderStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdeStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrdeStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
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
        }
    }
}
