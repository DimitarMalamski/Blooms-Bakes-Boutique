﻿using Blooms___Bakes_Boutique.Core.Contracts.Flower;
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
						UserName = f.Florist.User.UserName,
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
	}
}
