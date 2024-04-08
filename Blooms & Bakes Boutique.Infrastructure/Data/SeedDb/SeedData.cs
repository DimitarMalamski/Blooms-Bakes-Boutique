using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        // User roles
        public IdentityUser FloristUser { get; set; }
        public IdentityUser PatissierUser { get; set; }
        public IdentityUser GuestUser { get; set; }

        // Tyles of roles
        public Patissier Patissier { get; set; }
        public Florist Florist { get; set; }

        // Pastry categories
        public PastryCategory CakesCategory { get; set; }
        public PastryCategory CupcakeCategory { get; set; }
        public PastryCategory IceCreamCategory { get; set; }

        // Pastries
        public Pastry FirstPastry { get; set; }
        public Pastry SecondPastry { get; set; }
        public Pastry ThirdPastry { get; set; }

        // Flower categories
        public FlowerCategory AnnualCategory { get; set; }
        public FlowerCategory PerennialCategory { get; set; }
        public FlowerCategory BiennialCategory { get; set; }

        // Flowers
        public Flower FirstFlower { get; set; }
        public Flower SecondFlower { get; set; }
        public Flower ThirdFlower { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            PatissierUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "patissier@mail.com",
                NormalizedUserName = "patissier@mail.com",
                Email = "patissier@mail.com",
                NormalizedEmail = "patissier@mail.com"
            };

            PatissierUser.PasswordHash = hasher.HashPassword(PatissierUser, "agent123");

            FloristUser = new IdentityUser()
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                UserName = "florist@mail.com",
                NormalizedUserName = "florist@mail.com",
                Email = "florist@mail.com",
                NormalizedEmail = "florist@mail.com"
            };

            FloristUser.PasswordHash = hasher.HashPassword(FloristUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(PatissierUser, "guest123");
        }

        private void SeedPatissier()
        {
            Patissier patissier = new Patissier()
            {
                Id = 1,
                MasterChefTitle = "Master of the Oven",
                UserId = PatissierUser.Id
            };
        }

        private void SeedFlorist()
        {
            Florist florist = new Florist()
            {
                Id = 1,
                FlowerMasterTitle = "Bloomsmith",
                UserId = FloristUser.Id
            };
        }

        private void SeedPastryCategories()
        {
            CakesCategory = new PastryCategory()
            {
                Id = 1,
                Name = "Cake"
            };

            CupcakeCategory = new PastryCategory()
            {
                Id = 2,
                Name = "Cupcake"
            };

            IceCreamCategory = new PastryCategory()
            {
                Id = 3,
                Name = "Ice-cream"
            };
        }

        private void SeedFlowerCategories()
        {
            AnnualCategory = new FlowerCategory()
            {
                Id = 1,
                Name = "Annual"
            };

            PerennialCategory = new FlowerCategory()
            {
                Id = 2,
                Name = "Perennial"
            };

            BiennialCategory = new FlowerCategory()
            {
                Id = 3,
                Name = "Biennial"
            };
        }

        private void SeedPastries()
        {
            FirstPastry = new Pastry()
            {
                Id = 1,
                Title = "Carrot Cake",
                Description = "Carrot cake is a moist and spiced dessert featuring grated carrots for sweetness and texture. Topped with tangy cream cheese frosting, it offers a delightful balance of flavors and textures, making it a timeless favorite.",
                Recipe = "Ingredients:\r\n- 2 cups grated carrots\r\n- 1 cup all-purpose flour\r\n- 1 teaspoon baking powder\r\n- 1/2 teaspoon baking soda\r\n- 1/2 teaspoon salt\r\n- 1 teaspoon ground cinnamon\r\n- 1/2 teaspoon ground nutmeg\r\n- 1/4 teaspoon ground cloves\r\n- 2 large eggs\r\n- 1/2 cup vegetable oil\r\n- 3/4 cup granulated sugar\r\n- 1/2 cup chopped walnuts or pecans (optional)\r\n- Cream cheese frosting (store-bought or homemade)\r\n\r\nInstructions:\r\n1. Preheat your oven to 350°F (175°C). Grease and flour a 9-inch round cake pan.\r\n2. In a large mixing bowl, whisk together the flour, baking powder, baking soda, salt, cinnamon, nutmeg, and cloves.\r\n3. In another bowl, beat the eggs, then mix in the vegetable oil and granulated sugar until well combined.\r\n4. Gradually add the wet ingredients to the dry ingredients, stirring until just combined. Fold in the grated carrots and chopped nuts, if using.\r\n5. Pour the batter into the prepared cake pan and smooth the top with a spatula.\r\n6. Bake in the preheated oven for 25-30 minutes, or until a toothpick inserted into the center comes out clean.\r\n7. Allow the cake to cool completely in the pan on a wire rack.\r\n8. Once cooled, spread a layer of cream cheese frosting over the top of the cake.\r\n9. Slice and serve your delicious homemade carrot cake! Enjoy!\"",
                ImageUrl = "https://www.glorioustreats.com/wp-content/uploads/2014/05/best-carrot-cake-recipe-square.jpeg",
                Price = 12.00M,
                CategoryId = CakesCategory.Id,
                PatissierId = Patissier.Id,
            };

            SecondPastry = new Pastry()
            {
                Id = 2,
                Title = "Red Velvet Cupcakes",
                Description = "Red velvet cupcakes are rich, moist treats with a hint of cocoa and a striking red hue. Topped with creamy cream cheese frosting, they're a perfect blend of sweet and tangy flavors, ideal for any occasion.",
                Recipe = "Ingredients:\r\n- 1 and 1/4 cups all-purpose flour\r\n- 1/2 teaspoon baking soda\r\n- 1 tablespoon unsweetened cocoa powder\r\n- 1/4 teaspoon salt\r\n- 1/2 cup unsalted butter, softened\r\n- 1 cup granulated sugar\r\n- 2 large eggs\r\n- 1 teaspoon vanilla extract\r\n- 1/2 cup buttermilk\r\n- 1 tablespoon red food coloring\r\n- 1/2 teaspoon white vinegar\r\n- 1/2 teaspoon baking soda\r\n\r\nCream Cheese Frosting:\r\n- 8 oz cream cheese, softened\r\n- 1/4 cup unsalted butter, softened\r\n- 2 cups powdered sugar\r\n- 1 teaspoon vanilla extract\r\n\r\nInstructions:\r\n1. Preheat your oven to 350°F (175°C). Line a muffin tin with cupcake liners.\r\n2. In a medium bowl, sift together the flour, baking soda, cocoa powder, and salt. Set aside.\r\n3. In a large bowl, cream together the softened butter and granulated sugar until light and fluffy.\r\n4. Beat in the eggs, one at a time, then stir in the vanilla extract.\r\n5. In a small bowl, whisk together the buttermilk and red food coloring. Gradually add this mixture to the wet ingredients, mixing until well combined.\r\n6. In a small bowl, mix together the white vinegar and baking soda. Quickly fold this into the batter.\r\n7. Gradually add the dry ingredients to the wet ingredients, mixing until just combined. Be careful not to overmix.\r\n8. Divide the batter evenly among the cupcake liners, filling each about 2/3 full.\r\n9. Bake in the preheated oven for 18-20 minutes, or until a toothpick inserted into the center comes out clean.\r\n10. Allow the cupcakes to cool in the muffin tin for 5 minutes, then transfer them to a wire rack to cool completely.\r\n\r\nFor the Cream Cheese Frosting:\r\n1. In a large bowl, beat together the softened cream cheese and butter until smooth.\r\n2. Gradually add the powdered sugar and vanilla extract, beating until creamy and smooth.\r\n3. Once the cupcakes are completely cooled, frost them with the cream cheese frosting.\r\n4. Enjoy your delicious homemade red velvet cupcakes!\"",
                ImageUrl = "https://www.livewellbakeoften.com/wp-content/uploads/2021/06/Red-Velvet-Cupcakes-3-New-copy.jpg",
                Price = 6.00M,
                CategoryId = CupcakeCategory.Id,
                PatissierId = Patissier.Id,
                TasterId = GuestUser.Id
            };

            ThirdPastry = new Pastry()
            {
                Id = 3,
                Title = "Mochi",
                Description = "Mochi ice cream is a delightful combination of creamy ice cream wrapped in chewy rice dough. With a variety of flavors to choose from, it offers a unique and satisfying treat for all ages.",
                Recipe = "Ingredients:\r\n- 1 cup glutinous rice flour (mochiko)\r\n- 1/4 cup granulated sugar\r\n- 1 cup water\r\n- Your choice of ice cream flavors\r\n\r\nInstructions:\r\n1. In a microwave-safe bowl, whisk together the glutinous rice flour and sugar.\r\n2. Gradually stir in the water until the mixture is smooth and well combined.\r\n3. Microwave the mixture on high for 1 minute, then remove and stir.\r\n4. Microwave for an additional 30 seconds to 1 minute, or until the mixture is thick and sticky.\r\n5. Allow the mixture to cool slightly.\r\n6. Divide the mochi dough into small balls, about 1 tablespoon each.\r\n7. Flatten each ball into a small disc.\r\n8. Place a scoop of your favorite ice cream flavor onto each mochi disc.\r\n9. Carefully wrap the mochi around the ice cream, pinching to seal.\r\n10. Place the mochi ice cream balls onto a baking sheet lined with parchment paper.\r\n11. Freeze the mochi ice cream balls for at least 2 hours, or until firm.\r\n12. Serve and enjoy your delicious homemade mochi ice cream treats!\"",
                ImageUrl = "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/k%2FPhoto%2FRecipes%2F2023-07-mochi%2FMochi-Ice-Cream_17700jpg",
                Price = 4.00M,
                CategoryId = IceCreamCategory.Id,
                PatissierId = Patissier.Id
            };
        }

        private void SeedFlowers()
        {
            FirstFlower = new Flower()
            {
                Id = 1,

            }
        }
    }

}
