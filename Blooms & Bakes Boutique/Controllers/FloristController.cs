using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Models.Florist;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blooms___Bakes_Boutique.Controllers
{
	public class FloristController : BaseController
    {
		private readonly IFloristService floristService;
		public FloristController(IFloristService _floristService)
		{
			floristService = _floristService;
		}

		[HttpGet]
		public async Task<IActionResult> BecomeFlorist()
		{
			if (await floristService.ExistByIdAsync(User.Id()))
			{
				return BadRequest();
			}

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
