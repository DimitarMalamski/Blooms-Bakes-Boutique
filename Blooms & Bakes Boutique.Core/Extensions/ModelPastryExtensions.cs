using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Extensions
{
	public static class ModelPastryExtensions
	{
		public static string GetInformation(this IPastryModel pastry)
		{
			string info = pastry.Title.Replace(" ", "-") + GetDescription(pastry.Description);
			info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

			return info;
		}

		private static string GetDescription(string description)
		{
			description = string.Join("-", description.Split(" ").Take(3));

			return description;
		}
	}
}
