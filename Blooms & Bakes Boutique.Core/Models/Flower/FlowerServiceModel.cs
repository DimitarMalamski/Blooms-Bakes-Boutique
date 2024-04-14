using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Flowers.Flower;

namespace Blooms___Bakes_Boutique.Core.Models.Flower
{
	public class FlowerServiceModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(TitleMaxLength,
			MinimumLength = TitleMinLength,
			ErrorMessage = LengthMessage)]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ColourMaxLength,
			MinimumLength = ColourMinLength,
			ErrorMessage = LengthMessage)]
		public string Colour { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Image URL")]
		public string ImageUrl { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredMessage)]
		[Range(typeof(decimal),
					PricePerBouquetMinLength,
					PricePerBouquetMaxLength,
					ConvertValueInInvariantCulture = true,
					ErrorMessage = PriceErrorMessage)]
		[Display(Name = "Price Per Bouquet")]
		public decimal PricePerBouquet { get; set; }

		[Display(Name = "Is Gathered")]
		public bool IsGathered { get; set; }
	}
}
