using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class CascadeRuleAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_PlasticColors_ColorId",
                table: "Puzzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_MaterialType_MaterialTypeId",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlasticColors",
                table: "PlasticColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialType",
                table: "MaterialType");

            migrationBuilder.RenameTable(
                name: "PlasticColors",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "MaterialType",
                newName: "MaterialTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialTypes",
                table: "MaterialTypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 371, DateTimeKind.Unspecified).AddTicks(7584), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3324), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3445), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3509), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3517), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3520), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3528), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3535), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3543), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 19, 15, 16, 8, 374, DateTimeKind.Unspecified).AddTicks(3551), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_Colors_ColorId",
                table: "Puzzles",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_MaterialTypes_MaterialTypeId",
                table: "Puzzles",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Colors_ColorId",
                table: "Puzzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_MaterialTypes_MaterialTypeId",
                table: "Puzzles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialTypes",
                table: "MaterialTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "MaterialTypes",
                newName: "MaterialType");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "PlasticColors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialType",
                table: "MaterialType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlasticColors",
                table: "PlasticColors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 879, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateWhenAdded",
                value: new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_PlasticColors_ColorId",
                table: "Puzzles",
                column: "ColorId",
                principalTable: "PlasticColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_MaterialType_MaterialTypeId",
                table: "Puzzles",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
