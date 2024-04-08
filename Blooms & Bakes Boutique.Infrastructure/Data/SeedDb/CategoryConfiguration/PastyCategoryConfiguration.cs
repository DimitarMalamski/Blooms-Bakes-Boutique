using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
