using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blooms___Bakes_Boutique.Data
{
    public class BloomsAndBakesDbContext : IdentityDbContext
    {
        public BloomsAndBakesDbContext(DbContextOptions<BloomsAndBakesDbContext> options)
            : base(options)
        {
        }
    }
}
