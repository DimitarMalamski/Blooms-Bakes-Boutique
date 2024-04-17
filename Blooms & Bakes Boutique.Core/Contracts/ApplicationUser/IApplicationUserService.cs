using Blooms___Bakes_Boutique.Core.Models.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser
{
    public interface IApplicationUserService
    {
        Task<string> UserFullNameAsync(string userId);

        Task<IEnumerable<ApplicationUserServiceModel>> AllAsync();

		Task<bool> UserHasTastedPatriesAsync(string userId);

		Task<bool> UserHasGatheredFlowersAsync(string userId);
	}
}
