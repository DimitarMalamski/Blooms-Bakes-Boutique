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
		Task<IEnumerable<PastryCategoryServiceModel>> AllFlowerCategoriesAsync();

		Task<bool> FlowerCategoryExistsAsync(int categoryId);

		Task<int> CreateAsync(PastryFormModel model, int floristId);
	}
}
