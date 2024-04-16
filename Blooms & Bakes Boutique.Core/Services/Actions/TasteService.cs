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
	public class TasteService : ITasteService
	{
		private readonly IRepository repository;

        public TasteService(IRepository _repository)
        {
			repository = _repository;
        }
        public async Task<IEnumerable<TasteServiceModel>> AllAsync()
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
				.Include(p => p.Patissier)
				.Include(p => p.Taster)
				.Where(p => p.TasterId != null)
				.Select(p => new TasteServiceModel()
				{
					PatissierEmail = p.Patissier.User.Email,
					PatissierFullName = $"{p.Patissier.User.FirstName} {p.Patissier.User.LastName}",
					PastryImageUrl = p.ImageUrl,
					PastryTitle = p.Title,
					TasterEmail = p.Taster != null ? p.Taster.Email : string.Empty,
					TasterFullName = p.Taster != null ? $"{p.Taster.FirstName} {p.Taster.LastName}" : string.Empty,
				})
				.ToListAsync();
		}
	}
}
