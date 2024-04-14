using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.Flower
{
	public class AllFlowersQueryModel
	{
		public int FlowersPerPage { get; } = 3;

		public string FlowerCategory { get; init; } = null!;

		[Display(Name = "Search by text")]
		public string SearchTerm { get; init; } = null!;

		public FlowerSorting Sorting { get; init; }

		public int CurrentPage { get; init; } = 1;

		public int TotalFlowersCount { get; set; }

		public IEnumerable<string> FlowerCategories { get; set; } = null!;

		public IEnumerable<FlowerServiceModel> Flowers { get; set; } =
			new List<FlowerServiceModel>();
	}
}
