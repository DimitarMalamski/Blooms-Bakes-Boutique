using System.ComponentModel.DataAnnotations;

namespace Blooms___Bakes_Boutique.Core.Models.Florist
{
	public class FloristServiceModel
	{
		[Display(Name = "Full Name")]
		public string FullName { get; set; } = null!;

		[Display(Name = "FlowerMaster Title")]
		public string FlowerMasterTitle { get; set; } = null!;

		public string Email { get; set; } = null!;
	}
}
