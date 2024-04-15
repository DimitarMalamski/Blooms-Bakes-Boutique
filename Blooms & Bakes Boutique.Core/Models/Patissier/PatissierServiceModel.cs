using System.ComponentModel.DataAnnotations;

namespace Blooms___Bakes_Boutique.Core.Models.Patissier
{
	public class PatissierServiceModel
	{
		[Display(Name = "Full Name")]
		public string FullName { get; set; } = null!;

		[Display(Name = "MasterChef Title")]
		public string MasterChefTitle { get; set; } = null!;

		public string Email { get; set; } = null!;
    }
}
