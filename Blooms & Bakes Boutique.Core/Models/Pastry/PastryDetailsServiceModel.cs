using Blooms___Bakes_Boutique.Core.Models.Patissier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.Pastry
{
	public class PastryDetailsServiceModel : PastryServiceModel
	{
		public string Recipe { get; set; } = null!;

		public string PastryCategory { get; set; } = null!;

		public PatissierServiceModel Patissier { get; set; } = null!;
    }
}
