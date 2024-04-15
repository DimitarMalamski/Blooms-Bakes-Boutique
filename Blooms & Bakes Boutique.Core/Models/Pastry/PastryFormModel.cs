using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using System.ComponentModel.DataAnnotations;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries.Pastry;

namespace Blooms___Bakes_Boutique.Core.Models.Pastry
{
	public class PastryFormModel : IPastryModel
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
		[StringLength(RecipeMaxLength,
			MinimumLength = RecipeMinLength,
			ErrorMessage = LengthMessage)]
		public string Recipe { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Image Url")]
		public string ImageUrl { get; set; } = null!;

		[Required(ErrorMessage = RequiredMessage)]
		[Range(typeof(decimal),
			PriceMinLength,
			PriceMaxLength,
			ConvertValueInInvariantCulture = true,
			ErrorMessage = PriceErrorMessage)]
		[Display(Name = "Price Of Pastry")]
		public decimal Price { get; set; }

		[Display(Name = "Pastry Category")]
        public int CategoryId { get; set; }

        public IEnumerable<PastryCategoryServiceModel> PastryCategories { get; set; } =
			new List<PastryCategoryServiceModel>();	
    }
}
