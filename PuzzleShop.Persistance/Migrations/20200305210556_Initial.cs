using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlasticColors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlasticColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuzzleTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuzzleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puzzles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    IsWcaPuzzle = table.Column<bool>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    DateWhenAdded = table.Column<DateTimeOffset>(nullable: false),
                    ManufacturerId = table.Column<long>(nullable: false),
                    PuzzleTypeId = table.Column<long>(nullable: false),
                    PlasticColorId = table.Column<long>(nullable: false),
                    DifficultyLevelId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puzzles_Levels_DifficultyLevelId",
                        column: x => x.DifficultyLevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puzzles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puzzles_PlasticColors_PlasticColorId",
                        column: x => x.PlasticColorId,
                        principalTable: "PlasticColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puzzles_PuzzleTypes_PuzzleTypeId",
                        column: x => x.PuzzleTypeId,
                        principalTable: "PuzzleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    PuzzleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Puzzles_PuzzleId",
                        column: x => x.PuzzleId,
                        principalTable: "Puzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "LevelName" },
                values: new object[,]
                {
                    { 1L, "Low" },
                    { 2L, "Middle" },
                    { 3L, "High" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, null, "Gan" },
                    { 2L, null, "MoYu" },
                    { 3L, null, "QiYi" },
                    { 4L, null, "Rubics" }
                });

            migrationBuilder.InsertData(
                table: "PlasticColors",
                columns: new[] { "Id", "Color" },
                values: new object[,]
                {
                    { 1L, "White" },
                    { 2L, "Black" },
                    { 3L, "Stickerless" }
                });

            migrationBuilder.InsertData(
                table: "PuzzleTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1L, "3x3x3" },
                    { 2L, "4x4x4" },
                    { 3L, "5x5x5" }
                });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "DateWhenAdded", "Description", "DifficultyLevelId", "IsWcaPuzzle", "ManufacturerId", "Name", "PlasticColorId", "Price", "PuzzleTypeId", "Weight" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2020, 3, 5, 23, 5, 55, 905, DateTimeKind.Unspecified).AddTicks(5918), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 1L, "Gan 356 X", 3L, null, 1L, 350.0 });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "DateWhenAdded", "Description", "DifficultyLevelId", "IsWcaPuzzle", "ManufacturerId", "Name", "PlasticColorId", "Price", "PuzzleTypeId", "Weight" },
                values: new object[] { 2L, new DateTimeOffset(new DateTime(2020, 3, 5, 23, 5, 55, 908, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 1L, "Gan 356 XS", 1L, null, 1L, 330.0 });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "DateWhenAdded", "Description", "DifficultyLevelId", "IsWcaPuzzle", "ManufacturerId", "Name", "PlasticColorId", "Price", "PuzzleTypeId", "Weight" },
                values: new object[] { 3L, new DateTimeOffset(new DateTime(2020, 3, 5, 23, 5, 55, 908, DateTimeKind.Unspecified).AddTicks(4260), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 2L, "MoYu Weilong GTS 3M", 3L, null, 1L, 345.0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FileName", "PuzzleId", "Title" },
                values: new object[] { 1L, "testfilename", 1L, null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FileName", "PuzzleId", "Title" },
                values: new object[] { 2L, "testfilename", 2L, null });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PuzzleId",
                table: "Images",
                column: "PuzzleId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_DifficultyLevelId",
                table: "Puzzles",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_ManufacturerId",
                table: "Puzzles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_PlasticColorId",
                table: "Puzzles",
                column: "PlasticColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_PuzzleTypeId",
                table: "Puzzles",
                column: "PuzzleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Puzzles");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "PlasticColors");

            migrationBuilder.DropTable(
                name: "PuzzleTypes");
        }
    }
}
