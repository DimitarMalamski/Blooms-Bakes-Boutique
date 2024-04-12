using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.RoleConfiguration
{
    internal class PatissierConfiguration : IEntityTypeConfiguration<Patissier>
    {
        public void Configure(EntityTypeBuilder<Patissier> builder)
        {
            var data = new SeedData();

            builder.HasData(new Patissier[] { data.Patissier });
        }
    }
}
