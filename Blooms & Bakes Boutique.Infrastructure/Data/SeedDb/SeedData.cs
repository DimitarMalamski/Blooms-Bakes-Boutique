using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry;
using Microsoft.AspNetCore.Identity;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        // User roles
        public IdentityUser FloristUser { get; set; } = null!;
        public IdentityUser PatissierUser { get; set; } = null!;
        public IdentityUser GuestUser { get; set; } = null!;

        // Tyles of roles
        public Patissier Patissier { get; set; } = null!;
        public Florist Florist { get; set; } = null!;

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
            var hasher = new PasswordHasher<IdentityUser>();

            PatissierUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "patissier@mail.com",
                NormalizedUserName = "patissier@mail.com",
                Email = "patissier@mail.com",
                NormalizedEmail = "patissier@mail.com"
            };

            PatissierUser.PasswordHash = hasher.HashPassword(PatissierUser, "patissier123");

            FloristUser = new IdentityUser()
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                UserName = "florist@mail.com",
                NormalizedUserName = "florist@mail.com",
                Email = "florist@mail.com",
                NormalizedEmail = "florist@mail.com"
            };

            FloristUser.PasswordHash = hasher.HashPassword(FloristUser, "florist123");

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

        private void SeedPatissiers()
        {
            Patissier = new Patissier()
            {
                Id = 1,
                MasterChefTitle = "Master of the Oven",
                UserId = PatissierUser.Id
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
                Recipe = "none",
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
