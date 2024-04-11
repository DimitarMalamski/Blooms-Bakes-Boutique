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

		public Task Create(string userId, string flowerMasterTitle)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> ExistById(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Florist>()
				.AnyAsync(a => a.UserId == userId);
		}

		public Task<bool> UserHasGatheredFlowers(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UserWithFlowerMasterTitleExists(string flowerMasterTitle)
		{
			throw new NotImplementedException();
		}
	}
}
