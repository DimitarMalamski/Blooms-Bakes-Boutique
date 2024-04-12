using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.EntityFrameworkCore;

namespace Blooms___Bakes_Boutique.Core.Services.Pastry
{
	public class PastryService : IPastryService
    {
        private readonly IRepository repository;

        public PastryService(IRepository _repository)
        {
            repository = _repository;
        }

		public async Task<IEnumerable<PastryCategoryServiceModel>> AllPastryCategoriesAsync()
		{
            return await repository.AllReadOnly<PastryCategory>()
                .Select(pc => new PastryCategoryServiceModel()
                {
                    Id = pc.Id,
                    Name = pc.Name
                })
                .ToListAsync();
		}

		public async Task<int> CreateAsync(PastryFormModel model, int patissierId)
		{
            Infrastructure.Data.Models.Pastries.Pastry pastry = new Infrastructure.Data.Models.Pastries.Pastry()
            {
                Description = model.Description,
                PatissierId = patissierId,
                CategoryId = model.CategoryId,
                Recipe = model.Recipe,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Title = model.Title
            };

            await repository.AddAsync(pastry);
            await repository.SaveChangesAsync();

            return pastry.Id;
		}

		public async Task<bool> PastryCategoryExistsAsync(int categoryId)
		{
            return await repository.AllReadOnly<PastryCategory>()
                .AnyAsync(pc => pc.Id == categoryId);
		}
	}
}
