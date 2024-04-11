using System.ComponentModel.DataAnnotations;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries.Patissier;

namespace Blooms___Bakes_Boutique.Core.Models.Patissier
{
    public class BecomePatissierFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MasterChefMaxLength,
            MinimumLength = MasterChefMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "MasterChef Title")]
        [RegularExpression(@"/[A-Z]/", ErrorMessage = RegexErrorMessage)]
        public string MasterChefTitle { get; set; } = null!;
    }
}
