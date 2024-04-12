using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.CategoryConfiguration
{
    internal class PastyCategoryConfiguration : IEntityTypeConfiguration<PastryCategory>
    {
        public void Configure(EntityTypeBuilder<PastryCategory> builder)
        {
            var data = new SeedData();

            builder.HasData(new PastryCategory[] { data.CakeCategory, data.CupcakeCategory, data.IceCreamCategory });
        }
    }
}
