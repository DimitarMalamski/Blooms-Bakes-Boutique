using System.ComponentModel.DataAnnotations;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Flowers.Flower;

namespace Blooms___Bakes_Boutique.Core.Models.Flower
{
	public class FlowerFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(TitleMaxLength,
			MinimumLength = TitleMinLength,
			ErrorMessage = LengthMessage)]
		public string Title { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength,
			ErrorMessage = LengthMessage)]
		public string Description { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(ColourMaxLength,
			MinimumLength = ColourMinLength,
			ErrorMessage = LengthMessage)]
		public string Colour { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Image Url")]
		public string ImageUrl { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[Range(typeof(decimal),
			PricePerBouquetMinLength,
			PricePerBouquetMaxLength,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = PriceErrorMessage)]
		[Display(Name = "Price Per Bouquet")]
		public decimal PricePerBouquet { get; set; }

		[Display(Name = "Flower Category")]
		public int CategoryId { get; set; }

		public IEnumerable<FlowerCategoryServiceModel> FlowerCategories { get; set; } =
			new List<FlowerCategoryServiceModel>();
	}
}
