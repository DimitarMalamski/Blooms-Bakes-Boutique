using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Contracts.Flower
{
    public interface IFlowerService
    {
		Task<IEnumerable<FlowerCategoryServiceModel>> AllFlowerCategoriesAsync();

		Task<bool> FlowerCategoryExistsAsync(int categoryId);

		Task<int> CreateAsync(FlowerFormModel model, int floristId);

		Task<FlowerQueryServiceModel> AllFlowerAsync(
			string? flowerCategory = null,
			string? searchTerm = null,
			FlowerSorting sorting = FlowerSorting.Newest,
			int currentPage = 1,
			int flowerPerPage = 1);

		Task<IEnumerable<string>> AllFlowerCategoriesNamesAsync();

		Task<IEnumerable<FlowerServiceModel>> AllFlowersByFloristIdAsync(int floristId);

		Task<IEnumerable<FlowerServiceModel>> AllFlowersByUserId(string userId);

		Task<bool> ExistsAsync(int id);

		Task<FlowerDetailsServiceModel> FlowerDetailsByIdAsync(int id);
	}
}
