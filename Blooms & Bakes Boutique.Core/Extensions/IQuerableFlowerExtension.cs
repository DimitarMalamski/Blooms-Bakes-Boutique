using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
	public static class IQuerableFlowerExtension
	{
		public static IQueryable<FlowerServiceModel> ProjectToFlowerServiceModel(this IQueryable<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower> flowers)
		{
			return flowers
				.Select(f => new FlowerServiceModel()
				{
					Id = f.Id,
					Colour = f.Colour,
					ImageUrl = f.ImageUrl,
					IsGathered = f.GathererId != null,
					PricePerBouquet = f.PricePerBouquet,
					Title = f.Title
				});
		}
	}
}
