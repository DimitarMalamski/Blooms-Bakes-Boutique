using Blooms___Bakes_Boutique.Core.Contracts.Flower;
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

		public Task<FlowerQueryServiceModel> AllFlowerAsync(string? flowerCategory = null, string? searchTerm = null, FlowerSorting sorting = FlowerSorting.Newest, int currentPage = 1, int flowerPerPage = 1)
		{
			throw new NotImplementedException();
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

		public Task<IEnumerable<string>> AllFlowerCategoriesNamesAsync()
		{
			throw new NotImplementedException();
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

		public async Task<bool> FlowerCategoryExistsAsync(int categoryId)
		{
			return await repository.AllReadOnly<FlowerCategory>()
				.AnyAsync(fc => fc.Id == categoryId);
		}
	}
}
