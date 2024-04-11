using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class UniqueTitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9203764d-c37e-43be-b520-78de946ba90a", "AQAAAAEAACcQAAAAEMp1pkYt8/GvxjS9PqjHVEdvb3ZL5P3EetGa2mE68ZgV/P69bpLLb+pwNL1CFCz7OA==", "cd888b9e-e897-4770-8bd2-308a36366909" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e51c06a2-8c12-4c26-9b6b-91365dc969fb", "AQAAAAEAACcQAAAAEA9fw2KVw8COLLWCkT8WR1NgNSiurITCrlok2pqVfI7aq0P5QRHl6Z5GgF4DLW2v3A==", "a031354e-0f81-4d0b-8064-15be1d73e453" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c82b7552-5a9c-496f-9ae4-af33e8620b07", "AQAAAAEAACcQAAAAEET/d2rdN8Jk/+Td6yyG+a6FjKk0M50Tdui7A3yXYuZKTC9GXaMszcnZWI6d+fHZsA==", "ecb0c764-eea1-4ccf-b932-dd38e4118c51" });

            migrationBuilder.CreateIndex(
                name: "IX_Patissiers_MasterChefTitle",
                table: "Patissiers",
                column: "MasterChefTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Florists_FlowerMasterTitle",
                table: "Florists",
                column: "FlowerMasterTitle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patissiers_MasterChefTitle",
                table: "Patissiers");

            migrationBuilder.DropIndex(
                name: "IX_Florists_FlowerMasterTitle",
                table: "Florists");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7863fa7-03b7-4ed2-a5aa-4aee97ec6c10", "AQAAAAEAACcQAAAAEK28/VoHb1ku5Zd1FngwoF8J5cR8yr7r6/2f3ONDDgbg0s+NTCugf4/qEnDoadiQ6A==", "51cc5957-6243-4c22-977a-dc40306c95ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdf8099f-0a90-4f0f-bb3d-3689523997f2", "AQAAAAEAACcQAAAAEBgQ7Oiim64so2eaHTM6dLV99pltlnyw2XoU65YxwqiTTjpTEmRBkSw+LE7qob0BMA==", "928d3673-33b8-493c-aa5f-7fa605d14842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e31a135-9fec-47d8-be84-1b230807a326", "AQAAAAEAACcQAAAAEHy6YJKcmgbKKQ1tAKQ6njIMBCR9t8k+qRm5JssMJGxc8aox1X7LcEW6hh9TUAgtmA==", "1b442f47-7d36-448a-b60a-763fdebd6932" });
        }
    }
}
