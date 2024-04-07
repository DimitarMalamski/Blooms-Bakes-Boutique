using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class InitialTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Flower Description"),
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
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Pastry Description"),
                    Recipe = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Pastry Recipe"),
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
                name: "Flowers");

            migrationBuilder.DropTable(
                name: "Pastries");

            migrationBuilder.DropTable(
                name: "Florists");

            migrationBuilder.DropTable(
                name: "FlowersCategories");

            migrationBuilder.DropTable(
                name: "PastriesCategories");

            migrationBuilder.DropTable(
                name: "Patissiers");
        }
    }
}
