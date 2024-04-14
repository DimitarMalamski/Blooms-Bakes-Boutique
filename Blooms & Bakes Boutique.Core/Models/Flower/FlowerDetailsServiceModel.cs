using Blooms___Bakes_Boutique.Core.Models.Florist;
using Blooms___Bakes_Boutique.Core.Models.Patissier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.Flower
{
	public class FlowerDetailsServiceModel : FlowerServiceModel
	{
		public string Description { get; set; } = null!;

		public string FlowerCategory { get; set; } = null!;

		public FloristServiceModel Florist { get; set; } = null!;
	}
}
