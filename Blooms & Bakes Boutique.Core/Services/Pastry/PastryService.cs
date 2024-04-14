using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Enumerations;
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

		public Task<IEnumerable<PastryServiceModel>> AllPastriesByPatissierIdAsync(int patissierId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<PastryServiceModel>> AllPastriesByUserId(string userId)
		{
			throw new NotImplementedException();
		}

		public async Task<PastryQueryServiceModel> AllPastryAsync(
            string? pastryCategory = null, 
            string? searchTerm = null, 
            PastrySorting sorting = PastrySorting.Newest,
            int currentPage = 1,
            int pastryPerPage = 1)
		{
            var pastriesToShow = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.Pastry>();

            if (pastryCategory != null)
            {
                pastriesToShow = pastriesToShow
                    .Where(p => p.PastryCategory.Name == pastryCategory);

			}

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                pastriesToShow = pastriesToShow
                    .Where(p => p.Title.ToLower().Contains(normalizedSearchTerm) ||
                                p.Description.ToLower().Contains(normalizedSearchTerm) ||
                                p.Recipe.ToLower().Contains(normalizedSearchTerm));
            }

            pastriesToShow = sorting switch
            {
                PastrySorting.PriceOfPastry => pastriesToShow
                    .OrderBy(p => p.Price),
                PastrySorting.NotTastedFirst => pastriesToShow
                    .OrderByDescending(p => p.TasterId == null)
                    .ThenByDescending(p => p.Id),
                _ => pastriesToShow
                    .OrderByDescending(p => p.Id)
            };

            var pastries = await pastriesToShow
                .Skip((currentPage - 1) * pastryPerPage)
                .Take(pastryPerPage)
                .ProjectToPastryServiceModel()
                .ToListAsync();

            int totalPastries = await pastriesToShow.CountAsync();

            return new PastryQueryServiceModel()
            {
                Pastries = pastries,
                TotalPastriesCount = totalPastries
            };

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

		public async Task<IEnumerable<string>> AllPastryCategoriesNamesAsync()
		{
            return await repository.AllReadOnly<PastryCategory>()
                .Select(pc => pc.Name)
                .Distinct()
                .ToArrayAsync();
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
