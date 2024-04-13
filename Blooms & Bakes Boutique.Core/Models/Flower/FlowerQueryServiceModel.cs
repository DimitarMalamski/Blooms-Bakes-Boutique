namespace Blooms___Bakes_Boutique.Core.Models.Flower
{
	public class FlowerQueryServiceModel
	{
		public int TotalFlowersCount { get; set; }

		public IEnumerable<FlowerServiceModel> Flowers { get; set; } =
			new List<FlowerServiceModel>();
	}
}
