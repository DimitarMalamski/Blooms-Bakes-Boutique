using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;

namespace Blooms___Bakes_Boutique.Areas.Admin.Models.Flower
{
	public class MyFlowersViewModel
	{
		public IEnumerable<FlowerServiceModel> AddedFlowers { get; set; }
			= new List<FlowerServiceModel>();

		public IEnumerable<FlowerServiceModel> GatheredFlowers { get; set; }
			= new List<FlowerServiceModel>();
	}
}
