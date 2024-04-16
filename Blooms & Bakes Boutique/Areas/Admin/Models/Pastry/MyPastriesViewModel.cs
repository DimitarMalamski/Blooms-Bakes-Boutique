using Blooms___Bakes_Boutique.Core.Models.Pastry;

namespace Blooms___Bakes_Boutique.Areas.Admin.Models.Pastry
{
	public class MyPastriesViewModel
	{
		public IEnumerable<PastryServiceModel> AddedPastries { get; set; }
			= new List<PastryServiceModel>();

		public IEnumerable<PastryServiceModel> TastedPastries { get; set; }
			= new List<PastryServiceModel>();
    }
}
