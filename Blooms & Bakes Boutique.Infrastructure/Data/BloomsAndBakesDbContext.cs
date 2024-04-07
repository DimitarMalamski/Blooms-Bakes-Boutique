using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blooms___Bakes_Boutique.Infrastructure.Data
{
    public class BloomsAndBakesDbContext : IdentityDbContext
    {
        public BloomsAndBakesDbContext(DbContextOptions<BloomsAndBakesDbContext> options)
            : base(options)
        {
        }

        //overwriting OnModelCreating method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Pastries
            builder.Entity<Pastry>()
                .HasOne(p => p.PastryCategory)
                .WithMany(pc => pc.Pastries)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pastry>()
                .HasOne(p => p.Patissier)
                .WithMany(pt => pt.Pastries)
                .HasForeignKey(p => p.PatissierId)
                .OnDelete(DeleteBehavior.Restrict);

            //Flowers
            builder.Entity<Flower>()
                .HasOne(f => f.FlowerCategory)
                .WithMany(fc => fc.Flowers)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flower>()
                .HasOne(f => f.Florist)
                .WithMany(fr => fr.Flowers)
                .HasForeignKey(f => f.FloristId)
                .OnDelete(DeleteBehavior.Restrict);

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
