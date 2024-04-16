using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Models.Actions;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Services.Actions
{
	public class GatherService : IGatherService
	{
		private readonly IRepository repository;

		public GatherService(IRepository _repository)
		{
			repository = _repository;
		}
		public async Task<IEnumerable<GatherServiceModel>> AllAsync()
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.Include(p => p.Florist)
				.Include(p => p.Gatherer)
				.Where(p => p.GathererId != null)
				.Select(p => new GatherServiceModel()
				{
					FloristEmail = p.Florist.User.Email,
					FloristFullName = $"{p.Florist.User.FirstName} {p.Florist.User.LastName}",
					FlowerImageUrl = p.ImageUrl,
					FlowerTitle = p.Title,
					GathererEmail = p.Gatherer != null ? p.Gatherer.Email : string.Empty,
					GathererFullName = p.Gatherer != null ? $"{p.Gatherer.FirstName} {p.Gatherer.LastName}" : string.Empty,
				})
				.ToListAsync();
		}
	}
}
