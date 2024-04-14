using System.ComponentModel.DataAnnotations;

namespace Blooms___Bakes_Boutique.Core.Models.Patissier
{
	public class PatissierServiceModel
	{
		[Display(Name = "MasterChef Title")]
		public string MasterChefTitle { get; set; } = null!;

		public string UserName { get; set; } = null!;
    }
}
