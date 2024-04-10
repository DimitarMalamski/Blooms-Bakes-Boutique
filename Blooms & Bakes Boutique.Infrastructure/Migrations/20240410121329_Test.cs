using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowersCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowersCategories", x => x.Id);
                },
                comment: "Flower's Type/Category");

            migrationBuilder.CreateTable(
                name: "PastriesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastriesCategories", x => x.Id);
                },
                comment: "Pastry's Type/Category");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Florists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Florist Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerMasterTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Florist FlowerMaster Title"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Florists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Florists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Flower's Florist");

            migrationBuilder.CreateTable(
                name: "Patissiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Patissier Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterChefTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Patissier MasterChef Title"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patissiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patissiers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Pastry's Patissier/Chef");

            migrationBuilder.CreateTable(
                name: "Flowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Flower Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Flower Title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Flower Description"),
                    Colour = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Flower Colour"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Flower Image"),
                    PricePerBouquet = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price Per Bouquet"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier"),
                    FloristId = table.Column<int>(type: "int", nullable: false, comment: "Florist Identifier"),
                    GathererId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User id of the Gatherer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flowers_Florists_FloristId",
                        column: x => x.FloristId,
                        principalTable: "Florists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flowers_FlowersCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FlowersCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Flowers to pick");

            migrationBuilder.CreateTable(
                name: "Pastries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Pastry Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Pastry Title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Pastry Description"),
                    Recipe = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false, comment: "Pastry Recipe"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Pastry Image"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Pastry Price"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier"),
                    PatissierId = table.Column<int>(type: "int", nullable: false, comment: "Patissier Identifier"),
                    TasterId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User id of the Taster")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastries_PastriesCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PastriesCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pastries_Patissiers_PatissierId",
                        column: x => x.PatissierId,
                        principalTable: "Patissiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Pastry to taste");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "d7863fa7-03b7-4ed2-a5aa-4aee97ec6c10", "florist@mail.com", false, false, null, "florist@mail.com", "florist@mail.com", "AQAAAAEAACcQAAAAEK28/VoHb1ku5Zd1FngwoF8J5cR8yr7r6/2f3ONDDgbg0s+NTCugf4/qEnDoadiQ6A==", null, false, "51cc5957-6243-4c22-977a-dc40306c95ee", false, "florist@mail.com" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "cdf8099f-0a90-4f0f-bb3d-3689523997f2", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEBgQ7Oiim64so2eaHTM6dLV99pltlnyw2XoU65YxwqiTTjpTEmRBkSw+LE7qob0BMA==", null, false, "928d3673-33b8-493c-aa5f-7fa605d14842", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "2e31a135-9fec-47d8-be84-1b230807a326", "patissier@mail.com", false, false, null, "patissier@mail.com", "patissier@mail.com", "AQAAAAEAACcQAAAAEHy6YJKcmgbKKQ1tAKQ6njIMBCR9t8k+qRm5JssMJGxc8aox1X7LcEW6hh9TUAgtmA==", null, false, "1b442f47-7d36-448a-b60a-763fdebd6932", false, "patissier@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "FlowersCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Annual" },
                    { 2, "Perennial" },
                    { 3, "Biennial" }
                });

            migrationBuilder.InsertData(
                table: "PastriesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cake" },
                    { 2, "Cupcake" },
                    { 3, "Ice-cream" }
                });

            migrationBuilder.InsertData(
                table: "Florists",
                columns: new[] { "Id", "FlowerMasterTitle", "UserId" },
                values: new object[] { 1, "Bloomsmith", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "Patissiers",
                columns: new[] { "Id", "MasterChefTitle", "UserId" },
                values: new object[] { 1, "Master of the Oven", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Flowers",
                columns: new[] { "Id", "CategoryId", "Colour", "Description", "FloristId", "GathererId", "ImageUrl", "PricePerBouquet", "Title" },
                values: new object[] { 1, 1, "Yellow", "The sunflower is a bright, iconic flower known for its yellow petals and edible seeds. Symbolizing loyalty and adoration, it brings cheer and versatility to gardens and kitchens alike.", 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "https://www.edenbrothers.com/cdn/shop/products/sunflower-mammoth-grey-stripe-aly-5.jpg?v=1653508165&width=1946", 10.00m, "Sunflower" });

            migrationBuilder.InsertData(
                table: "Pastries",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "PatissierId", "Price", "Recipe", "TasterId", "Title" },
                values: new object[] { 1, 2, "Red velvet cupcakes are rich, moist treats with a hint of cocoa and a striking red hue. Topped with creamy cream cheese frosting, they're a perfect blend of sweet and tangy flavors, ideal for any occasion.", "https://www.livewellbakeoften.com/wp-content/uploads/2021/06/Red-Velvet-Cupcakes-3-New-copy.jpg", 1, 6.00m, "none", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", "Red Velvet Cupcakes" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Florists_UserId",
                table: "Florists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_CategoryId",
                table: "Flowers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_FloristId",
                table: "Flowers",
                column: "FloristId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastries_CategoryId",
                table: "Pastries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastries_PatissierId",
                table: "Pastries",
                column: "PatissierId");

            migrationBuilder.CreateIndex(
                name: "IX_Patissiers_UserId",
                table: "Patissiers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Pastries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Florists");

            migrationBuilder.DropTable(
                name: "FlowersCategories");

            migrationBuilder.DropTable(
                name: "PastriesCategories");

            migrationBuilder.DropTable(
                name: "Patissiers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
