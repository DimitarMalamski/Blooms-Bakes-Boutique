using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.CustomClaims;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        // User roles
        public ApplicationUser FloristUser { get; set; } = null!;

        public IdentityUserClaim<string> PatissierUserClaim { get; set; } = null!;
		public IdentityUserClaim<string> FloristUserClaim { get; set; } = null!;
		public IdentityUserClaim<string> GuestUserClaim { get; set; } = null!;
		public IdentityUserClaim<string> AdminUserClaim { get; set; } = null!;

		public ApplicationUser PatissierUser { get; set; } = null!;
        public ApplicationUser GuestUser { get; set; } = null!;
        public ApplicationUser AdminUser { get; set; } = null!;

        // Tyles of roles
        public Patissier Patissier { get; set; } = null!;
		public Patissier AdminPatissier { get; set; } = null!;
		public Florist Florist { get; set; } = null!;
		public Florist AdminFlorist { get; set; } = null!;

		// Pastry categories
		public PastryCategory CakeCategory { get; set; } = null!;
        public PastryCategory CupcakeCategory { get; set; } = null!;
        public PastryCategory IceCreamCategory { get; set; } = null!;

        // Pastries
        public Pastry FirstPastry { get; set; } = null!;
        public Pastry SecondPastry { get; set; } = null!;

        /* public Pastry ThirdPastry { get; set; } = null!; */

        // Flower categories
        public FlowerCategory AnnualCategory { get; set; } = null!;
        public FlowerCategory PerennialCategory { get; set; } = null!;
        public FlowerCategory BiennialCategory { get; set; } = null!;

        // Flowers
        public Flower FirstFlower { get; set; } = null!;
        public Flower SecondFlower { get; set; } = null!;

        /* public Flower ThirdFlower { get; set; } = null!; */

        // Constructor
        public SeedData()
        {
            SeedUsers();
            SeedPatissiers();
            SeedPastryCategories();
            SeedPastries();
            SeedFlorists();
            SeedFlowerCategories();
            SeedFlowers();
        }      

        // Private individual seeding methods
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            PatissierUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "patissier@mail.com",
                NormalizedUserName = "patissier@mail.com",
                Email = "patissier@mail.com",
                NormalizedEmail = "patissier@mail.com",
                FirstName = "Dimitar",
                LastName = "Malamski"
            };

            PatissierUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Dimitar Malamski",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
			};  

            PatissierUser.PasswordHash = hasher.HashPassword(PatissierUser, "patissier123");

            FloristUser = new ApplicationUser()
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                UserName = "florist@mail.com",
                NormalizedUserName = "florist@mail.com",
                Email = "florist@mail.com",
                NormalizedEmail = "florist@mail.com",
				FirstName = "Ivana",
				LastName = "Koroleeva"
			};

			FloristUserClaim = new IdentityUserClaim<string>()
			{
				Id = 2,
				ClaimType = UserFullNameClaim,
				ClaimValue = "Ivana Koroleeva",
				UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
			};

			FloristUser.PasswordHash = hasher.HashPassword(FloristUser, "florist123");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
				FirstName = "Iana",
				LastName = "Malamska"
			};

			GuestUserClaim = new IdentityUserClaim<string>()
			{
				Id = 3,
				ClaimType = UserFullNameClaim,
				ClaimValue = "Iana Malamska",
				UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
			};

			GuestUser.PasswordHash = hasher.HashPassword(PatissierUser, "guest123");

			AdminUser = new ApplicationUser()
			{
				Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
				UserName = "admin@mail.com",
				NormalizedUserName = "ADMIN@MAIL.COM",
				Email = "admin@mail.com",
				NormalizedEmail = "ADMIN@MAIL.COM",
				FirstName = "Great",
				LastName = "Admin"
			};

			AdminUserClaim = new IdentityUserClaim<string>()
			{
				Id = 4,
				ClaimType = UserFullNameClaim,
				ClaimValue = "Great Admin",
				UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3"
			};

			AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");
		}

        private void SeedPatissiers()
        {
            Patissier = new Patissier()
            {
                Id = 1,
                MasterChefTitle = "Master of the Oven",
                UserId = PatissierUser.Id
            };

			AdminPatissier = new Patissier()
			{
				Id = 4,
				MasterChefTitle = "Master of Everything",
				UserId = AdminUser.Id
			};
		}

        private void SeedFlorists()
        {
            Florist = new Florist()
            {
                Id = 1,
                FlowerMasterTitle = "Bloomsmith",
                UserId = FloristUser.Id
            };

			AdminFlorist = new Florist()
			{
				Id = 4,
				FlowerMasterTitle = "Master of Everything",
				UserId = AdminUser.Id
			};

		}

        private void SeedPastryCategories()
        {
            CakeCategory = new PastryCategory()
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
                Title = "Red Velvet Cupcakes",
                Description = "Red velvet cupcakes are rich, moist treats with a hint of cocoa and a striking red hue. Topped with creamy cream cheese frosting, they're a perfect blend of sweet and tangy flavors, ideal for any occasion.",
                Recipe = "Ingredients:\r\n\r\n1 1/4 cups all-purpose flour\r\n1/2 teaspoon baking soda\r\n1/2 teaspoon salt\r\n1 tablespoon unsweetened cocoa powder\r\n1/2 cup unsalted butter, softened\r\n1 cup granulated sugar\r\n2 large eggs\r\n1 teaspoon vanilla extract\r\n1/2 cup buttermilk\r\n1 tablespoon red food coloring\r\n1 teaspoon white vinegar\r\nCream cheese frosting (store-bought or homemade)\r\nInstructions:\r\n\r\nPreheat your oven to 350°F (175°C). Line a muffin tin with cupcake liners.\r\n\r\nIn a medium bowl, sift together the flour, baking soda, salt, and cocoa powder. Set aside.\r\n\r\nIn a large mixing bowl, cream together the butter and sugar until light and fluffy.\r\n\r\nBeat in the eggs, one at a time, then stir in the vanilla extract.\r\n\r\nGradually mix in the dry ingredients, alternating with the buttermilk. Begin and end with the dry ingredients. Mix until just combined.\r\n\r\nIn a small bowl, mix the red food coloring and vinegar together, then add it to the batter. Mix until the color is evenly distributed.\r\n\r\nSpoon the batter into the prepared cupcake liners, filling each about 2/3 full.\r\n\r\nBake in the preheated oven for 18-20 minutes, or until a toothpick inserted into the center comes out clean.\r\n\r\nAllow the cupcakes to cool in the pan for a few minutes, then transfer them to a wire rack to cool completely.\r\n\r\nOnce cooled, frost the cupcakes with cream cheese frosting. You can pipe the frosting on top for a decorative touch if desired.\r\n\r\nServe and enjoy your delicious homemade Red Velvet Cupcakes!\r\n\r\nThis recipe makes about 12 cupcakes. Enjoy baking!",
                ImageUrl = "https://www.livewellbakeoften.com/wp-content/uploads/2021/06/Red-Velvet-Cupcakes-3-New-copy.jpg",
                Price = 6.00M,
                CategoryId = CupcakeCategory.Id,
                PatissierId = Patissier.Id,
                TasterId = GuestUser.Id
            };
        }

        private void SeedFlowers()
        {
            FirstFlower = new Flower()
            {
                Id = 1,
                Title = "Sunflower",
                Description = "The sunflower is a bright, iconic flower known for its yellow petals and edible seeds. Symbolizing loyalty and adoration, it brings cheer and versatility to gardens and kitchens alike.",
                Colour = "Yellow",
                ImageUrl = "https://www.edenbrothers.com/cdn/shop/products/sunflower-mammoth-grey-stripe-aly-5.jpg?v=1653508165&width=1946",
                PricePerBouquet = 10.00M,
                CategoryId = AnnualCategory.Id,
                FloristId = Florist.Id,
                GathererId = GuestUser?.Id
            };
        }
    }

}
