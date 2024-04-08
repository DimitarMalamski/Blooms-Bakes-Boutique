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
    }

    }
}
