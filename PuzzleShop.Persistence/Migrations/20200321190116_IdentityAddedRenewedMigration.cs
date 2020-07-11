using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuzzleShop.Persistance.Migrations
{
    public partial class IdentityAddedRenewedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
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
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuzzleTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuzzleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    ColorId = table.Column<long>(nullable: false),
                    DifficultyLevelId = table.Column<long>(nullable: false),
                    MaterialTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puzzles_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Puzzles_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
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
                name: "RoleClaims",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    TotalItems = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Auth",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Auth",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Auth",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Users",
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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    PuzzleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Puzzles_PuzzleId",
                        column: x => x.PuzzleId,
                        principalTable: "Puzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1L, "White" },
                    { 2L, "Black" },
                    { 3L, "Stickerless" },
                    { 4L, "Pink" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Title" },
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
                    { 6L, null, "YJ" },
                    { 5L, null, "DaYan" },
                    { 4L, null, "Rubics" },
                    { 2L, null, "MoYu" },
                    { 1L, null, "Gan" },
                    { 3L, null, "QiYi" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1L, "Plastic" });

            migrationBuilder.InsertData(
                table: "PuzzleTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 6L, "square-1" },
                    { 1L, "3x3x3" },
                    { 2L, "4x4x4" },
                    { 3L, "5x5x5" },
                    { 4L, "6x6x6" },
                    { 5L, "skewb" },
                    { 7L, "Megaminx" }
                });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "ColorId", "DateWhenAdded", "Description", "DifficultyLevelId", "IsWcaPuzzle", "ManufacturerId", "MaterialTypeId", "Name", "Price", "PuzzleTypeId", "Weight" },
                values: new object[,]
                {
                    { 1L, 3L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 78, DateTimeKind.Unspecified).AddTicks(4597), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 1L, 1L, "Gan 356 X", 45.0m, 1L, 350.0 },
                    { 2L, 1L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8021), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 1L, 1L, "Gan 356 XS", 60.0m, 1L, 330.0 },
                    { 3L, 3L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8131), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 2L, 1L, "MoYu Weilong GTS 3M", 30.0m, 1L, 345.0 },
                    { 4L, 3L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8138), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 5L, 1L, "DaYan 7 TengYun", 25.0m, 1L, 334.0 },
                    { 5L, 3L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8146), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 1L, 1L, "Gan 354 M", 34.0m, 1L, 290.0 },
                    { 6L, 1L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 3L, 1L, "QiYi Valk Power M", 17.0m, 1L, 330.0 },
                    { 7L, 3L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8157), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 3L, 1L, "QiYi WuQue Mini M", 24.0m, 2L, 330.0 },
                    { 8L, 3L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8165), new TimeSpan(0, 2, 0, 0, 0)), null, 1L, true, 3L, 1L, "QiYi X-Man Skewb Wingy M", 12.0m, 5L, 220.0 },
                    { 9L, 2L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8172), new TimeSpan(0, 2, 0, 0, 0)), null, 1L, true, 2L, 1L, "MoYu Skewb AoYan M", 22.0m, 5L, 220.0 },
                    { 10L, 2L, new DateTimeOffset(new DateTime(2020, 3, 21, 21, 1, 16, 80, DateTimeKind.Unspecified).AddTicks(8176), new TimeSpan(0, 2, 0, 0, 0)), null, 2L, true, 2L, 1L, "MoYu Square-1 MeiLong", 10.0m, 6L, 220.0 }
                });

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
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PuzzleId",
                table: "OrderItems",
                column: "PuzzleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_ColorId",
                table: "Puzzles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_DifficultyLevelId",
                table: "Puzzles",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_ManufacturerId",
                table: "Puzzles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_MaterialTypeId",
                table: "Puzzles",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_PuzzleTypeId",
                table: "Puzzles",
                column: "PuzzleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Auth",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Auth",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Auth",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Auth",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Auth",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Auth",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Auth",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Puzzles");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "PuzzleTypes");
        }
    }
}
