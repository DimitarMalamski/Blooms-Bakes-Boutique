using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.RoleConfiguration
{
    internal class FloristConfiguration : IEntityTypeConfiguration<Florist>
    {
        public void Configure(EntityTypeBuilder<Florist> builder)
        {
            var data = new SeedData();

            builder.HasData(new Florist[] { data.Florist, data.AdminFlorist });
        }
    }
}
