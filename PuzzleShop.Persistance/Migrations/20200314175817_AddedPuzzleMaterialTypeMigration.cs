using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class AddedPuzzleMaterialTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_PlasticColors_PlasticColorId",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_PlasticColorId",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "PlasticColorId",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "PlasticColors");

            migrationBuilder.DropColumn(
                name: "LevelName",
                table: "Levels");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "PuzzleTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MaterialTypeId",
                table: "Puzzles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PlasticColors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Levels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Title",
                value: "Low");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Title",
                value: "Middle");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Title",
                value: "High");

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 5L, null, "DaYan" },
                    { 6L, null, "YJ" }
                });

            migrationBuilder.InsertData(
                table: "MaterialType",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1L, "Plastic" });

            migrationBuilder.UpdateData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Title",
                value: "White");

            migrationBuilder.UpdateData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Title",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Title",
                value: "Stickerless");

            migrationBuilder.InsertData(
                table: "PlasticColors",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4L, "Pink" });

            migrationBuilder.InsertData(
                table: "PuzzleTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 4L, "6x6x6" },
                    { 5L, "skewb" },
                    { 6L, "square-1" },
                    { 7L, "Megaminx" }
                });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ColorId", "DateWhenAdded", "MaterialTypeId", "Price" },
                values: new object[] { 3L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 879, DateTimeKind.Unspecified).AddTicks(4551), new TimeSpan(0, 2, 0, 0, 0)), 1L, 45.0m });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ColorId", "DateWhenAdded", "MaterialTypeId", "Price" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 2, 0, 0, 0)), 1L, 60.0m });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ColorId", "DateWhenAdded", "MaterialTypeId", "Price" },
                values: new object[] { 3L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9886), new TimeSpan(0, 2, 0, 0, 0)), 1L, 30.0m });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "ColorId", "DateWhenAdded", "Description", "DifficultyLevelId", "IsWcaPuzzle", "ManufacturerId", "MaterialTypeId", "Name", "Price", "PuzzleTypeId", "Weight" },
                values: new object[,]
                {
                    { 4L, 3L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9913), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 5L, 1L, "DaYan 7 TengYun", 25.0m, 1L, 334.0 },
                    { 5L, 3L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 1L, 1L, "Gan 354 M", 34.0m, 1L, 290.0 },
                    { 6L, 1L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9928), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 3L, 1L, "QiYi Valk Power M", 17.0m, 1L, 330.0 },
                    { 7L, 3L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9932), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 3L, 1L, "QiYi WuQue Mini M", 24.0m, 2L, 330.0 },
                    { 8L, 3L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 2, 0, 0, 0)), null, 1L, true, 3L, 1L, "QiYi X-Man Skewb Wingy M", 12.0m, 5L, 220.0 },
                    { 9L, 2L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9947), new TimeSpan(0, 2, 0, 0, 0)), null, 1L, true, 2L, 1L, "MoYu Skewb AoYan M", 22.0m, 5L, 220.0 },
                    { 10L, 2L, new DateTimeOffset(new DateTime(2020, 3, 14, 19, 58, 16, 881, DateTimeKind.Unspecified).AddTicks(9954), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 2L, 1L, "MoYu Square-1 MeiLong", 10.0m, 6L, 220.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_ColorId",
                table: "Puzzles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_MaterialTypeId",
                table: "Puzzles",
                column: "MaterialTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_PlasticColors_ColorId",
                table: "Puzzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_MaterialType_MaterialTypeId",
                table: "Puzzles");

            migrationBuilder.DropTable(
                name: "MaterialType");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_ColorId",
                table: "Puzzles");

            migrationBuilder.DropIndex(
                name: "IX_Puzzles_MaterialTypeId",
                table: "Puzzles");

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "PuzzleTypes",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "Puzzles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PlasticColors");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Levels");

            migrationBuilder.AlterColumn<string>(
                name: "TypeName",
                table: "PuzzleTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PlasticColorId",
                table: "Puzzles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PlasticColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelName",
                table: "Levels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LevelName",
                value: "Low");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LevelName",
                value: "Middle");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3L,
                column: "LevelName",
                value: "High");

            migrationBuilder.UpdateData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Color",
                value: "White");

            migrationBuilder.UpdateData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Color",
                value: "Black");

            migrationBuilder.UpdateData(
                table: "PlasticColors",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Color",
                value: "Stickerless");

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateWhenAdded", "PlasticColorId", "Price" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 5, 23, 5, 55, 905, DateTimeKind.Unspecified).AddTicks(5918), new TimeSpan(0, 2, 0, 0, 0)), 3L, null });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateWhenAdded", "PlasticColorId", "Price" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 5, 23, 5, 55, 908, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, 2, 0, 0, 0)), 1L, null });

            migrationBuilder.UpdateData(
                table: "Puzzles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateWhenAdded", "PlasticColorId", "Price" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 3, 5, 23, 5, 55, 908, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 2, 0, 0, 0)), 3L, null });

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_PlasticColorId",
                table: "Puzzles",
                column: "PlasticColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_PlasticColors_PlasticColorId",
                table: "Puzzles",
                column: "PlasticColorId",
                principalTable: "PlasticColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
