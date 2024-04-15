using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;
using Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.CategoryConfiguration;
using Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.ProductConfiguration;
using Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.RoleConfiguration;
using Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.UserConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blooms___Bakes_Boutique.Infrastructure.Data
{
    public class BloomsAndBakesDbContext : IdentityDbContext<ApplicationUser>
    {
        public BloomsAndBakesDbContext(DbContextOptions<BloomsAndBakesDbContext> options)
            : base(options)
        {
        }

        //overwriting OnModelCreating method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PatissierConfiguration());
            builder.ApplyConfiguration(new PastyCategoryConfiguration());
            builder.ApplyConfiguration(new PastryConfiguration());
            builder.ApplyConfiguration(new FloristConfiguration());           
            builder.ApplyConfiguration(new FlowerCategoryConfiguration());           
            builder.ApplyConfiguration(new FlowerConfiguration());
			builder.ApplyConfiguration(new UserClaimsConfiguration());

			base.OnModelCreating(builder);
        }

        // Pastries DbSets
        public DbSet<Pastry> Pastries { get; set; } = null!;

        public DbSet<PastryCategory> PastriesCategories { get; set; } = null!;

        public DbSet<Patissier> Patissiers { get; set; } = null!;

        // Flowers DbSets
        public DbSet<Flower> Flowers { get; set; } = null!;

        public DbSet<FlowerCategory> FlowersCategories { get; set; } = null!;

        public DbSet<Florist> Florists { get; set; } = null!;
    }
}
