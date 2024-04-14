using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Enumerations;
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

        Task<PastryQueryServiceModel> AllPastryAsync(
            string? pastryCategory = null,
            string? searchTerm = null,
            PastrySorting sorting = PastrySorting.Newest,
            int currentPage = 1,
            int pastryPerPage = 1);

        Task<IEnumerable<string>> AllPastryCategoriesNamesAsync();

        Task<IEnumerable<PastryServiceModel>> AllPastriesByPatissierIdAsync(int patissierId);

        Task<IEnumerable<PastryServiceModel>> AllPastriesByUserId(string userId);
	}
}
