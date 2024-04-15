using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.UserConfiguration
{
	public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
		{
			var data = new SeedData();

			builder.HasData(data.PatissierUserClaim, data.FloristUserClaim, data.GuestUserClaim, data.AdminUserClaim);
		}
	}
}
