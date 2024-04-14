using Blooms___Bakes_Boutique.Core.Models.Pastry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
	public static class IQuerablePastryExtension
	{
		public static IQueryable<PastryServiceModel> ProjectToPastryServiceModel(this IQueryable<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry> pastries)
		{
			return pastries
				.Select(p => new PastryServiceModel()
				{
					Id = p.Id,
					Description = p.Description,
					ImageUrl = p.ImageUrl,
					IsTasted = p.TasterId != null,
					Price = p.Price,
					Title = p.Title
				});
		}
	}
}
