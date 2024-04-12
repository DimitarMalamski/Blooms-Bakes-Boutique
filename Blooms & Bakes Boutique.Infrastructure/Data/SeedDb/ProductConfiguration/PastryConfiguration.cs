using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.ProductConfiguration
{
    internal class PastryConfiguration : IEntityTypeConfiguration<Pastry>
    {
        public void Configure(EntityTypeBuilder<Pastry> builder)
        {
            builder
                .HasOne(p => p.PastryCategory)
                .WithMany(pc => pc.Pastries)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Patissier)
                .WithMany()
                .HasForeignKey(p => p.PatissierId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Pastry[] { data.FirstPastry });
        }
    }
}
