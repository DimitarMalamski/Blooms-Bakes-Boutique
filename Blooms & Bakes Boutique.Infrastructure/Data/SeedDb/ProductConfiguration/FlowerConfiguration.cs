using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.ProductConfiguration
{
    internal class FlowerConfiguration : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder
                .HasOne(f => f.FlowerCategory)
                .WithMany(fc => fc.Flowers)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.Florist)
                .WithMany()
                .HasForeignKey(f => f.FloristId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Flower[] { data.FirstFlower });
        }
    }
}
