using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class TasteController : AdminController
	{
		private readonly ITasteService tasteService;

        public TasteController(ITasteService _tasteService)
        {
            tasteService = _tasteService;
        }

		[Route("Taste/All")]
        public async Task<IActionResult> All()
		{
			var model = await tasteService.AllAsync();

			return View(model);
		}
	}
}
