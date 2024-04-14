using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Enumerations;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries;

namespace Blooms___Bakes_Boutique.Core.Services.Pastry
{
	public class PastryService : IPastryService
    {
        private readonly IRepository repository;

        public PastryService(IRepository _repository)
        {
            repository = _repository;
        }

		public async Task<IEnumerable<PastryServiceModel>> AllPastriesByPatissierIdAsync(int patissierId)
		{
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
                .Where(p => p.PatissierId == patissierId)
                .ProjectToPastryServiceModel()
                .ToListAsync();
		}

		public async Task<IEnumerable<PastryServiceModel>> AllPastriesByUserId(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
				.Where(p => p.TasterId == userId)
				.ProjectToPastryServiceModel()
				.ToListAsync();
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
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.PastryCategory>()
                .Select(pc => new PastryCategoryServiceModel()
                {
                    Id = pc.Id,
                    Name = pc.Name
                })
                .ToListAsync();
		}

		public async Task<IEnumerable<string>> AllPastryCategoriesNamesAsync()
		{
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.PastryCategory>()
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

		public async Task EditAsync(int pastryId, PastryFormModel model)
		{
            var pastry = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>(pastryId);

            if (pastry != null)
            {
                pastry.Description = model.Description;
                pastry.CategoryId = model.CategoryId;
                pastry.Recipe = model.Recipe;
                pastry.ImageUrl = model.ImageUrl;
                pastry.Price = model.Price;
                pastry.Title = model.Title;

                await repository.SaveChangesAsync();
            }
		}

		public async Task<bool> ExistsAsync(int id)
		{
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
                .AnyAsync(p => p.Id == id);
		}

		public async Task<PastryFormModel?> GetPastryFormModelByIdAsync(int id)
		{
            var pastry = await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
                .Where(p => p.Id == id)
                .Select(p => new PastryFormModel()
                {
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    Recipe = p.Recipe,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Title = p.Title,
                })
                .FirstOrDefaultAsync();

            if (pastry != null)
            {
                pastry.PastryCategories = await AllPastryCategoriesAsync(); 
			}

            return pastry;
            
		}

		public async Task<bool> HasPatissierWithIdAsync(int pastryId, string userId)
		{
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
                .AnyAsync(p => p.Id == pastryId && p.Patissier.UserId == userId);
		}

		public async Task<bool> PastryCategoryExistsAsync(int categoryId)
		{
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.PastryCategory>()
                .AnyAsync(pc => pc.Id == categoryId);
		}

		public async Task<PastryDetailsServiceModel> PastryDetailsByIdAsync(int id)
		{
            return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
                .Where(p => p.Id == id)
                .Select(p => new PastryDetailsServiceModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Patissier = new Models.Patissier.PatissierServiceModel()
                    {
                        UserName = p.Patissier.User.UserName,
                        MasterChefTitle = p.Patissier.MasterChefTitle
                    },
                    PastryCategory = p.PastryCategory.Name,
                    Recipe = p.Recipe,
                    ImageUrl = p.ImageUrl,
                    IsTasted = p.TasterId != null,
                    Price = p.Price,
                    Title = p.Title
                })
                .FirstAsync();
		}
	}
}
