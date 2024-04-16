using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.User;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Models.User
{
	public class ApplicationUser : IdentityUser
	{
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(UserLastNameMaxLength)]
		public string LastName { get; set; } = null!;

        public Patissier? Patissier { get; set; }

		public Florist? Florist { get; set; }
	}
}
