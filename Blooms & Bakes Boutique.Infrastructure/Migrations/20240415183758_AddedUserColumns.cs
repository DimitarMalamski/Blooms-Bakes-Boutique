using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Flowers",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Flower Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Flower Description");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a16263b-86a3-46e2-a3c9-63b145a2bedc", "Ivana", "Koroleeva", "AQAAAAEAACcQAAAAEBLgHPE2uwzVzHCyM6Mo4XvJg1QtVmOyY+TP9CM7Zq9Pb8jlGg+aNRziYWAoDFQbVg==", "4efcde75-39ac-4a03-92ae-995b10d1b754" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e24e95e-7910-4e49-9020-2f46b2043a58", "Iana", "Malamska", "AQAAAAEAACcQAAAAEHkexoPaL3Y7lQ2W7uYQjte2Pf0vEs/iEN+DyvAx0QZMQIMensmHEH/9/0Q3Sjlncw==", "c90b3753-c85f-44a4-a773-1d24f489a194" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d1b8f65-c5dd-4a14-a4a0-3173895b3be2", "Dimitar", "Malamski", "AQAAAAEAACcQAAAAELf1X6PSYtNaPl7XGtTYDKbJxSSm7tK37wU35hBISMtCkbpvXdqYPnIkD1wrysZY4w==", "9f27a5e2-61c9-4f1f-8b46-e6a24586b492" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Flowers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Flower Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Flower Description");

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
        }
    }
}
