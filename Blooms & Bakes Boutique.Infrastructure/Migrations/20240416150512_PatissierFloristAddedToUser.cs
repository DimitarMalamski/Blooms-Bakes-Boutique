using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class PatissierFloristAddedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patissiers_UserId",
                table: "Patissiers");

            migrationBuilder.DropIndex(
                name: "IX_Florists_UserId",
                table: "Florists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff007c48-4efb-48f0-a5d8-7c49f90409a1", "AQAAAAEAACcQAAAAEKVThi2/xFss+IzyFMYHTkSl1NQ1idtvdtcn/pawdmdMopDqEvlvyAFKTZmgDm4tRw==", "7f18c47e-da70-4cb8-98da-b0c86f65f2da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e489cafe-8851-4b42-abc1-ad9a6c5cf6cb", "AQAAAAEAACcQAAAAEEozC9XaRjBxRvWmKfjWw5g4Mgr4tc0rbtIF9PaVMpOqXB2l5UTrs/HzMl8FWMEKCQ==", "98d3b963-cd34-4c75-adb2-773f91ff0963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58aecef1-9cba-4983-aa7c-e00ba436cce2", "AQAAAAEAACcQAAAAEAbz5ge0Rc2slhCpHN5Cx8R8W0k5zQ2IhNI2OUPG3l+Q5g7ZxRIMV4fqeVAMJuXZ6g==", "e0f84eb8-9f27-41ea-8b71-1356fb409b50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a79e2668-67be-4b12-ba37-88341b7579d1", "AQAAAAEAACcQAAAAENDzxOGroaxaHmXgt6JAANgfsw+YIRqPEUU2xpir+/5+CEa5bP9wnjAVGC68cX3Ajw==", "6123e252-514c-4399-a001-1b70e4f68e8b" });

            migrationBuilder.CreateIndex(
                name: "IX_Patissiers_UserId",
                table: "Patissiers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Florists_UserId",
                table: "Florists",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patissiers_UserId",
                table: "Patissiers");

            migrationBuilder.DropIndex(
                name: "IX_Florists_UserId",
                table: "Florists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eebe01b-e727-4238-a7bf-87c5267dadb5", "AQAAAAEAACcQAAAAEONDjCA9f2e9HywNxil7p8p2QUqofDeZ5RXFmvDKwjGJzbNvlv9gtXCHU/jQ3NqtMg==", "d6e38ec3-8999-4bd0-8397-d82f9c3bed7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2574d38b-38e5-4a0f-8ecf-1ec951347abd", "AQAAAAEAACcQAAAAECSAyJgYh2b0DqTLAS9Bq0pTQk1owcNomsBrZLF+JbmjSy6vB5UME4MZZUeSInIYug==", "7416cddc-cb5a-4da9-9603-924da817a82e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4322ae73-9da0-4872-a908-6cb31ff9140a", "AQAAAAEAACcQAAAAEPSrdyM99ocatWqH7xXenUHWBHTK2oPbzJ8gllX65HFsaQT3LfG2ZA9crJM8EQb/UA==", "a61cca59-b235-44a0-9810-0aa0dd880c43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "620e5824-ee8e-496a-97b7-359c7a9dceeb", "AQAAAAEAACcQAAAAEJ2iJAO+EaPhFdTec/isGAjLTUqEFaF/K9jqw5D9cWqrbuoBAWVhBEjMXYFLoSs1Rg==", "1810fc2b-67c8-4b87-8a85-37a1247da0d3" });

            migrationBuilder.CreateIndex(
                name: "IX_Patissiers_UserId",
                table: "Patissiers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Florists_UserId",
                table: "Florists",
                column: "UserId");
        }
    }
}
