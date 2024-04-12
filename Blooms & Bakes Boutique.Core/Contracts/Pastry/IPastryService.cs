using Blooms___Bakes_Boutique.Core.Models.Pastry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Contracts.Pastry
{
    public interface IPastryService
    {
        Task<IEnumerable<PastryCategoryServiceModel>> AllPastryCategoriesAsync();

        Task<bool> PastryCategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(PastryFormModel model, int patissierId);
	}
}
