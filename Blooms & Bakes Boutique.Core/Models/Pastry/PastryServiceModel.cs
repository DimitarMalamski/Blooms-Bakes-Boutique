using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries.Pastry;

namespace Blooms___Bakes_Boutique.Core.Models.Pastry
{
	public class PastryServiceModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(TitleMaxLength,
			MinimumLength = TitleMinLength,
			ErrorMessage = LengthMessage)]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength,
			ErrorMessage = LengthMessage)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]		
		[Range(typeof(decimal),
					PriceMinLength,
					PriceMaxLength,
					ConvertValueInInvariantCulture = true,
					ErrorMessage = PriceErrorMessage)]
		[Display(Name = "Price Of Pastry")]
		public decimal Price { get; set; }

		[Display(Name = "Is Tasted")]
		public bool IsTasted { get; set; }
	}
}
