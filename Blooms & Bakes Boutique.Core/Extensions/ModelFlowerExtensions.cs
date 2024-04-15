using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Extensions
{
	public static class ModelFlowerExtensions
	{
		public static string GetInformation(this IFlowerModel flower)
		{
			string info = flower.Title.Replace(" ", "-") + GetColour(flower.Colour);
			info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

			return info;
		}

		private static string GetColour(string colour)
		{
			colour = string.Join("-", colour.Split(" ").Take(3));

			return colour;
		}
	}
}
