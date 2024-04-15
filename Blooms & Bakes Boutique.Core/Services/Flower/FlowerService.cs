using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Exceptions;
using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Enumerations;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;

namespace Blooms___Bakes_Boutique.Core.Services.Flower
{
    public class FlowerService : IFlowerService
    {
        private readonly IRepository repository;

        public FlowerService(IRepository _repository)
        {
            repository = _repository;
        }

		public async Task<FlowerQueryServiceModel> AllFlowerAsync(
			string? flowerCategory = null,
			string? searchTerm = null,
			FlowerSorting sorting = FlowerSorting.Newest,
			int currentPage = 1,
			int flowerPerPage = 1)
		{
			var flowersToShow = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.Flower>();

			if (flowerCategory != null)
			{
				flowersToShow = flowersToShow
					.Where(p => p.FlowerCategory.Name == flowerCategory);

			}

			if (searchTerm != null)
			{
				string normalizedSearchTerm = searchTerm.ToLower();

				flowersToShow = flowersToShow
					.Where(p => p.Title.ToLower().Contains(normalizedSearchTerm) ||
								p.Description.ToLower().Contains(normalizedSearchTerm) ||
								p.Colour.ToLower().Contains(normalizedSearchTerm));
			}

			flowersToShow = sorting switch
			{
				FlowerSorting.PricePerBouquet => flowersToShow
					.OrderBy(p => p.PricePerBouquet),
				FlowerSorting.NotGatheredFirst => flowersToShow
					.OrderByDescending(p => p.GathererId == null)
					.ThenByDescending(p => p.Id),
				_ => flowersToShow
					.OrderByDescending(p => p.Id)
			};

			var flowers = await flowersToShow
				.Skip((currentPage - 1) * flowerPerPage)
				.Take(flowerPerPage)
				.ProjectToFlowerServiceModel()
				.ToListAsync();

			int totalFlowers = await flowersToShow.CountAsync();

			return new FlowerQueryServiceModel()
			{
				Flowers = flowers,
				TotalFlowersCount = totalFlowers
			};
		}

		public async Task<IEnumerable<FlowerCategoryServiceModel>> AllFlowerCategoriesAsync()
		{
			return await repository.AllReadOnly<FlowerCategory>()
				.Select(fc => new FlowerCategoryServiceModel()
				{
					Id = fc.Id,
					Name = fc.Name
				})
				.ToListAsync();
				
		}

		public async Task<IEnumerable<string>> AllFlowerCategoriesNamesAsync()
		{
			return await repository.AllReadOnly<FlowerCategory>()
				.Select(fc => fc.Name)
				.Distinct()
				.ToArrayAsync();
		}

		public async Task<IEnumerable<FlowerServiceModel>> AllFlowersByFloristIdAsync(int floristId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.Where(f => f.FloristId == floristId)
				.ProjectToFlowerServiceModel()
				.ToListAsync();
		}

		public async Task<IEnumerable<FlowerServiceModel>> AllFlowersByUserId(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.Where(f => f.GathererId == userId)
				.ProjectToFlowerServiceModel()
				.ToListAsync();
		}

		public async Task<int> CreateAsync(FlowerFormModel model, int floristId)
		{
			Infrastructure.Data.Models.Flowers.Flower flower = new Infrastructure.Data.Models.Flowers.Flower()
			{
				Title = model.Title,
				Description = model.Description,
				Colour = model.Colour,
				ImageUrl = model.ImageUrl,
				PricePerBouquet = model.PricePerBouquet,
				FloristId = floristId,
				CategoryId = model.CategoryId
			};

			await repository.AddAsync(flower);
			await repository.SaveChangesAsync();

			return flower.Id;
		}

		public async Task DeleteAsync(int flowerId)
		{
			await repository.DeleteAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>(flowerId);
			await repository.SaveChangesAsync();
		}

		public async Task EditAsync(int flowerId, FlowerFormModel model)
		{
			var flower = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>(flowerId);

			if (flower != null)
			{
				flower.Colour = model.Colour;
				flower.CategoryId = model.CategoryId;
				flower.Description = model.Description;
				flower.ImageUrl = model.ImageUrl;
				flower.PricePerBouquet = model.PricePerBouquet;
				flower.Title = model.Title;

				await repository.SaveChangesAsync();
			}
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.AnyAsync(f => f.Id == id);
		}

		public async Task<bool> FlowerCategoryExistsAsync(int categoryId)
		{
			return await repository.AllReadOnly<FlowerCategory>()
				.AnyAsync(fc => fc.Id == categoryId);
		}

		public async Task<FlowerDetailsServiceModel> FlowerDetailsByIdAsync(int id)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.Where(f => f.Id == id)
				.Select(f => new FlowerDetailsServiceModel()
				{
					Id = f.Id,
					Colour = f.Colour,
					Florist = new Models.Florist.FloristServiceModel()
					{
						FullName = $"{f.Florist.User.FirstName} {f.Florist.User.LastName}",
						Email = f.Florist.User.UserName,
						FlowerMasterTitle = f.Florist.FlowerMasterTitle
					},
					FlowerCategory = f.FlowerCategory.Name,
					Description = f.Description,
					ImageUrl = f.ImageUrl,
					IsGathered = f.GathererId != null,
					PricePerBouquet = f.PricePerBouquet,
					Title = f.Title
				})
				.FirstAsync();
		}

		public async Task GatherAsync(int id, string userId)
		{
			var flower = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>(id);

			if (flower != null)
			{
				flower.GathererId = userId;
				await repository.SaveChangesAsync();
			}
		}

		public async Task<FlowerFormModel?> GetFlowerFormModelByIdAsync(int id)
		{
			var flower = await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.Where(f => f.Id == id)
				.Select(f => new FlowerFormModel()
				{
					Colour = f.Colour,
					CategoryId = f.CategoryId,
					Description = f.Description,
					ImageUrl = f.ImageUrl,
					PricePerBouquet = f.PricePerBouquet,
					Title = f.Title,
				})
				.FirstOrDefaultAsync();

			if (flower != null)
			{
				flower.FlowerCategories = await AllFlowerCategoriesAsync();
			}

			return flower;
		}

		public async Task<bool> HasFloristWithIdAsync(int flowerId, string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.AnyAsync(f => f.Id == flowerId && f.Florist.UserId == userId);
		}

		public async Task<bool> IsGatheredAsync(int flowerId)
		{
			bool result = false;

			var flower = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>(flowerId);

			if (flower != null)
			{
				result = flower.GathererId != null;
			}

			return result;
		}

		public async Task<bool> IsGatheredByUserWithIdAsync(int flowerId, string userId)
		{
			bool result = false;

			var flower = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>(flowerId);

			if (flower != null)
			{
				result = flower.GathererId == userId;
			}

			return result;
		}

		public async Task UngatherAsync(int flowerId, string userId)
		{
			var flower = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>(flowerId);

			if (flower != null)
			{
				if (flower.GathererId != userId)
				{
					throw new UnauthorizedActionException(UnauthorizedActionExceptionGatherer);
				}

				flower.GathererId = null;
				await repository.SaveChangesAsync();
			}
		}
	}
}
