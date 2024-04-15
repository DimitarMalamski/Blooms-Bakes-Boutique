using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blooms___Bakes_Boutique.Infrastructure.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Dimitar Malamski", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Ivana Koroleeva", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 3, "user:fullname", "Iana Malamska", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, "620e5824-ee8e-496a-97b7-359c7a9dceeb", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEJ2iJAO+EaPhFdTec/isGAjLTUqEFaF/K9jqw5D9cWqrbuoBAWVhBEjMXYFLoSs1Rg==", null, false, "1810fc2b-67c8-4b87-8a85-37a1247da0d3", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Pastries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Recipe",
                value: "Ingredients:\r\n\r\n1 1/4 cups all-purpose flour\r\n1/2 teaspoon baking soda\r\n1/2 teaspoon salt\r\n1 tablespoon unsweetened cocoa powder\r\n1/2 cup unsalted butter, softened\r\n1 cup granulated sugar\r\n2 large eggs\r\n1 teaspoon vanilla extract\r\n1/2 cup buttermilk\r\n1 tablespoon red food coloring\r\n1 teaspoon white vinegar\r\nCream cheese frosting (store-bought or homemade)\r\nInstructions:\r\n\r\nPreheat your oven to 350°F (175°C). Line a muffin tin with cupcake liners.\r\n\r\nIn a medium bowl, sift together the flour, baking soda, salt, and cocoa powder. Set aside.\r\n\r\nIn a large mixing bowl, cream together the butter and sugar until light and fluffy.\r\n\r\nBeat in the eggs, one at a time, then stir in the vanilla extract.\r\n\r\nGradually mix in the dry ingredients, alternating with the buttermilk. Begin and end with the dry ingredients. Mix until just combined.\r\n\r\nIn a small bowl, mix the red food coloring and vinegar together, then add it to the batter. Mix until the color is evenly distributed.\r\n\r\nSpoon the batter into the prepared cupcake liners, filling each about 2/3 full.\r\n\r\nBake in the preheated oven for 18-20 minutes, or until a toothpick inserted into the center comes out clean.\r\n\r\nAllow the cupcakes to cool in the pan for a few minutes, then transfer them to a wire rack to cool completely.\r\n\r\nOnce cooled, frost the cupcakes with cream cheese frosting. You can pipe the frosting on top for a decorative touch if desired.\r\n\r\nServe and enjoy your delicious homemade Red Velvet Cupcakes!\r\n\r\nThis recipe makes about 12 cupcakes. Enjoy baking!");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 4, "user:fullname", "Great Admin", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });

            migrationBuilder.InsertData(
                table: "Florists",
                columns: new[] { "Id", "FlowerMasterTitle", "UserId" },
                values: new object[] { 4, "Master of Everything", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });

            migrationBuilder.InsertData(
                table: "Patissiers",
                columns: new[] { "Id", "MasterChefTitle", "UserId" },
                values: new object[] { 4, "Master of Everything", "e43ce836-997d-4927-ac59-74e8c41bbfd3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Florists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patissiers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a16263b-86a3-46e2-a3c9-63b145a2bedc", "AQAAAAEAACcQAAAAEBLgHPE2uwzVzHCyM6Mo4XvJg1QtVmOyY+TP9CM7Zq9Pb8jlGg+aNRziYWAoDFQbVg==", "4efcde75-39ac-4a03-92ae-995b10d1b754" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e24e95e-7910-4e49-9020-2f46b2043a58", "AQAAAAEAACcQAAAAEHkexoPaL3Y7lQ2W7uYQjte2Pf0vEs/iEN+DyvAx0QZMQIMensmHEH/9/0Q3Sjlncw==", "c90b3753-c85f-44a4-a773-1d24f489a194" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d1b8f65-c5dd-4a14-a4a0-3173895b3be2", "AQAAAAEAACcQAAAAELf1X6PSYtNaPl7XGtTYDKbJxSSm7tK37wU35hBISMtCkbpvXdqYPnIkD1wrysZY4w==", "9f27a5e2-61c9-4f1f-8b46-e6a24586b492" });

            migrationBuilder.UpdateData(
                table: "Pastries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Recipe",
                value: "none");
        }
    }
}
