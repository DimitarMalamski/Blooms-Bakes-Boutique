namespace Blooms___Bakes_Boutique.Core.Models.Pastry
{
	public class PastryQueryServiceModel
	{
        public int TotalPastriesCount { get; set; }

        public IEnumerable<PastryServiceModel> Pastries { get; set; } =
            new List<PastryServiceModel>();
    }
}
