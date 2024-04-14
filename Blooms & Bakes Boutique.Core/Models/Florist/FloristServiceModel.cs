using System.ComponentModel.DataAnnotations;

namespace Blooms___Bakes_Boutique.Core.Models.Florist
{
	public class FloristServiceModel
	{
		[Display(Name = "FlowerMaster Title")]
		public string FlowerMasterTitle { get; set; } = null!;

		public string UserName { get; set; } = null!;
	}
}
