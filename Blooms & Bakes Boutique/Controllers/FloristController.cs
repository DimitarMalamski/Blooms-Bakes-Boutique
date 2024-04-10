using Blooms___Bakes_Boutique.Core.Models.Florist;
using Blooms___Bakes_Boutique.Core.Models.Patissier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Controllers
{
    [Authorize]
    public class FloristController : Controller
    {
		[HttpGet]
		public async Task<IActionResult> BecomeFlorist()
		{
			var model = new BecomeFloristFormModel();

			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> BecomeFlorist(BecomeFloristFormModel model)
		{
			return RedirectToAction(nameof(FlowerController.AllFlower), "Flower");
		}
	}
}
