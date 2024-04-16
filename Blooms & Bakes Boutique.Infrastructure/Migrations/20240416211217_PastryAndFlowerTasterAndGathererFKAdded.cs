using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class PastryAndFlowerTasterAndGathererFKAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TasterId",
                table: "Pastries",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the Taster",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User id of the Taster");

            migrationBuilder.AlterColumn<string>(
                name: "GathererId",
                table: "Flowers",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the Gatherer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User id of the Gatherer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df4c3d9b-8424-40b5-8af8-9a485adbdbaf", "AQAAAAEAACcQAAAAEFOuMuH3drcW9vPnbAd+7JaqU48Kly8ws6xCjxC6/knTw6vWuvLM5X4MS6wLcwo3jw==", "5fc5bc78-a20f-4d7a-9c73-94333156f8ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd40d397-fb18-44b4-a167-7ebda892b950", "AQAAAAEAACcQAAAAEDQQzpgu6X+uyhl1e6Y1hpj8bdFbj4PeQUi3dh9/pOctlFOKbd117AR2ZZdf0kDN9g==", "edaefb8d-6ad8-4074-928e-8949dbe23497" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c2772e9-8b8a-41fe-b424-6568eb578f4a", "AQAAAAEAACcQAAAAEAYF7DqJkRb2ejm2BbmJTh00cA/O1Dripm3cNfBFlDgTAMf6bb6zR50Mvpepi9Va9w==", "e0f3d4c2-9706-4bb6-962b-34687e6c0b1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15f8832a-2d58-4cec-8e9f-c5d7e4287bfc", "AQAAAAEAACcQAAAAEB+mGF+TQbiBG8g5qLgMj5WadJNAm11IoqTH3MpNwzxzhRRts763GxdDXEBqNzGrxA==", "ec4fdd8b-e7fa-4bfe-8d7b-94d63b8f2934" });

            migrationBuilder.CreateIndex(
                name: "IX_Pastries_TasterId",
                table: "Pastries",
                column: "TasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_GathererId",
                table: "Flowers",
                column: "GathererId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_AspNetUsers_GathererId",
                table: "Flowers",
                column: "GathererId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastries_AspNetUsers_TasterId",
                table: "Pastries",
                column: "TasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_AspNetUsers_GathererId",
                table: "Flowers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pastries_AspNetUsers_TasterId",
                table: "Pastries");

            migrationBuilder.DropIndex(
                name: "IX_Pastries_TasterId",
                table: "Pastries");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_GathererId",
                table: "Flowers");

            migrationBuilder.AlterColumn<string>(
                name: "TasterId",
                table: "Pastries",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the Taster",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "User id of the Taster");

            migrationBuilder.AlterColumn<string>(
                name: "GathererId",
                table: "Flowers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the Gatherer",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "User id of the Gatherer");

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
        }
    }
}
