using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.SeedDb.UserConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new ApplicationUser[] { data.PatissierUser, data.FloristUser, data.GuestUser});
        }
    }
}
