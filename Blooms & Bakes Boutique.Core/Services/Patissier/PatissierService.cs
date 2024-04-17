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

		public async Task CreateAsync(string userId, string masterChefTitle)
		{
			await repository.AddAsync(new Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier()
			{
				UserId = userId,
				MasterChefTitle = masterChefTitle
			});

			await repository.SaveChangesAsync();
		}

		public async Task<bool> ExistByIdAsync(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier>()
				.AnyAsync(pa => pa.UserId == userId);
		}

		public async Task<int?> GetPatissierIdAsync(string userId)
		{
			return (await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier>()
				.FirstOrDefaultAsync(pa => pa.UserId == userId))?.Id ?? 0;
		}

		public async Task<bool> PatissierWithMasterChefTitleExistsAsync(string masterChefTitle)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier>()
				.AnyAsync(pa => pa.MasterChefTitle == masterChefTitle);
		}
	}
}
