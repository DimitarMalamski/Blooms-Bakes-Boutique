using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Blooms___Bakes_Boutique.Core.Services.Florist
{
	public class FloristService : IFloristService
	{
		private readonly IRepository repository;
		public FloristService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task CreateAsync(string userId, string flowerMasterTitle)
		{
			await repository.AddAsync(new Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Florist()
			{
				UserId = userId,
				FlowerMasterTitle = flowerMasterTitle
			});

			await repository.SaveChangesAsync();
		}

		public async Task<bool> ExistByIdAsync(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Florist>()
				.AnyAsync(fl => fl.UserId == userId);
		}

		public async Task<int?> GetFloristIdAsync(string userId)
		{
			return (await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Florist>()
				.FirstOrDefaultAsync(pa => pa.UserId == userId))?.Id;
		}

		public async Task<bool> UserHasGatheredFlowersAsync(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.AnyAsync(f => f.GathererId == userId);
		}

		public async Task<bool> UserWithFlowerMasterTitleExistsAsync(string flowerMasterTitle)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Florist>()
				.AnyAsync(fl => fl.FlowerMasterTitle == flowerMasterTitle);
		}
	}
}
