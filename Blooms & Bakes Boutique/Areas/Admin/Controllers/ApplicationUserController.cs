using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Blooms___Bakes_Boutique.Core.Models.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class ApplicationUserController : AdminController
	{
		private readonly IApplicationUserService applicationUserService;
		private readonly IMemoryCache memoryCache;

		public ApplicationUserController(
			IApplicationUserService _applicationUserService,
            IMemoryCache _memoryCache)
		{
			applicationUserService = _applicationUserService;
			memoryCache = _memoryCache;
		}

		[Route("ApplicationUser/All")]
		public async Task<IActionResult> All()
		{
			var users = memoryCache.Get<IEnumerable<ApplicationUserServiceModel>>(UsersCacheKey);

			if (users == null || users.Any() == false)
			{
                users = await applicationUserService.AllAsync();

				var cacheOptions = new MemoryCacheEntryOptions()
					.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

				memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }

			
			return View(users);
		}
	}
}
