using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
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
