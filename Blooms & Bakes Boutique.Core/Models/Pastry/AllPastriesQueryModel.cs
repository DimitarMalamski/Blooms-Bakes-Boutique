using Blooms___Bakes_Boutique.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.Pastry
{
    public class AllPastriesQueryModel
    {
		public int PastriesPerPage { get; } = 3;

		public string PastryCategory { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public PastrySorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalPastriesCount { get; set; }

        public IEnumerable<string> PastryCategories { get; set; } = null!;

        public IEnumerable<PastryServiceModel> Pastries { get; set; } =
            new List<PastryServiceModel>();
    }
}
