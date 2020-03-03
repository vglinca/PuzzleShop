using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Migrations
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
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: true)
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
                    Color = table.Column<string>(maxLength: 25, nullable: false)
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
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
                    FileName = table.Column<string>(nullable: false),
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
