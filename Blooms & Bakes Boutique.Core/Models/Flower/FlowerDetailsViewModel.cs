using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.Flower
{
	public class FlowerDetailsViewModel : IFlowerModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Colour { get; set; } = string.Empty;

		public string ImageUrl { get; set; } = string.Empty;
	}
}
