using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Services.Patissier
{
	public class PatissierService : IPatissierService
	{
		private readonly IRepository repository;

		public PatissierService(IRepository _repository)
		{
			repository = _repository;
		}
		public async Task<bool> ExistById(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastry.Patissier>()
				.AnyAsync(a => a.UserId == userId);
		}
	}
}
