using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Services.Actions;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class GatherController : AdminController
	{
		private readonly IGatherService gatherService;

		public GatherController(IGatherService _gatherService)
		{
			gatherService = _gatherService;
		}

		[Route("Gather/All")]
		public async Task<IActionResult> All()
		{
			var model = await gatherService.AllAsync();

			return View(model);
		}
	}
}
