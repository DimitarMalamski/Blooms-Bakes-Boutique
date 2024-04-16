using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class ApplicationUserController : AdminController
	{
		private readonly IApplicationUserService applicationUserService;

		public ApplicationUserController(
			IApplicationUserService _applicationUserService)
		{
			applicationUserService = _applicationUserService;
		}

		[Route("ApplicationUser/All")]
		public async Task<IActionResult> All()
		{
			var users = await applicationUserService.AllAsync();
			return View(users);
		}
	}
}
