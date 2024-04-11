using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Flowers.Florsit;

namespace Blooms___Bakes_Boutique.Core.Models.Florist
{
	public class BecomeFloristFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(FlowerMasterMaxLength,
			MinimumLength = FlowerMasterMinLength,
			ErrorMessage = LengthMessage)]
		[Display(Name = "FlowerMaster Title")]
		[RegularExpression(@"(?=.*?[A-Z]).*", ErrorMessage = RegexErrorMessage)]
		public string FlowerMasterTitle { get; set; } = null!;
	}
}
