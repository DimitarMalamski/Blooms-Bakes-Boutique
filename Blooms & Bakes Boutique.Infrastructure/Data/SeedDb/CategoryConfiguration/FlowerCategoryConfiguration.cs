﻿using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.CategoryConfiguration
{
    internal class FlowerCategoryConfiguration : IEntityTypeConfiguration<FlowerCategory>
    {
        public void Configure(EntityTypeBuilder<FlowerCategory> builder)
        {
            var data = new SeedData();

            builder.HasData(new FlowerCategory[] { data.AnnualCategory, data.PerennialCategory, data.BiennialCategory });
        }
    }
}
