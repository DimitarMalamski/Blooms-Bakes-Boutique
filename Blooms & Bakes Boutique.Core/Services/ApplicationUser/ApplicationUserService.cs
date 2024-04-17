using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Blooms___Bakes_Boutique.Core.Models.ApplicationUser;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Services.ApplicationUser
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepository repository;
        public ApplicationUserService(IRepository _repository)
        {
            repository = _repository;
        }

		public async Task<IEnumerable<ApplicationUserServiceModel>> AllAsync()
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.User.ApplicationUser>()
				.Include(u => u.Patissier)
                .Include(u => u.Florist)
				.Select(u => new ApplicationUserServiceModel()
				{
					Email = u.Email,
					FullName = $"{u.FirstName} {u.LastName}",
					MasterChefTitle = u.Patissier != null ? u.Patissier.MasterChefTitle : null,
                    FlowerMasterTitle = u.Florist != null ? u.Florist.FlowerMasterTitle : null,
					IsPatissier = u.Patissier != null,
                    IsFlorist = u.Florist != null
				})
				.ToListAsync();
		}

		public async Task<bool> UserHasGatheredFlowersAsync(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Flower>()
				.AnyAsync(f => f.GathererId == userId);
		}

		public async Task<bool> UserHasTastedPatriesAsync(string userId)
		{
			return await repository.AllReadOnly<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Pastry>()
				.AnyAsync(p => p.TasterId == userId);
		}

		public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;

            var user = await repository
                .GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.User.ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
