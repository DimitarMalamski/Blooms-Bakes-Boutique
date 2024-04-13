using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
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
	}
}
