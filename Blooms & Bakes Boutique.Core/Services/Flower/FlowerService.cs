using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
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

		public Task<IEnumerable<PastryCategoryServiceModel>> AllFlowerCategoriesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<int> CreateAsync(PastryFormModel model, int floristId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> FlowerCategoryExistsAsync(int categoryId)
		{
			throw new NotImplementedException();
		}
	}
}
