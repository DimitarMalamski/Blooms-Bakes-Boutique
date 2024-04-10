using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Controllers
{
    [Authorize]
    public class FlowerController : Controller
    {
        [AllowAnonymous]
		public async Task<IActionResult> AllFlower()
		{
			return View(new AllFlowersQueryModel());
		}
		public async Task<IActionResult> MineFlower()
		{
			return View(new AllFlowersQueryModel());
		}

		public async Task<IActionResult> FlowerDetails(int id)
		{
			return View(new FlowerDetailsViewModel());
		}

		public async Task<IActionResult> AddFlower()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddFlower(FlowerFormModel model)
		{
			return RedirectToAction(nameof(FlowerDetails), new { id = "1" });
		}
		public async Task<IActionResult> EditFlower(int id)
		{
			return View(new FlowerFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> EditFlower(int id, FlowerFormModel model)
		{
			return RedirectToAction(nameof(FlowerDetails), new { id = "1" });
		}
		public async Task<IActionResult> DeleteFlower(int id)
		{
			return View(new FlowerFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> DeleteFlower(FlowerDetailsViewModel model)
		{
			return RedirectToAction(nameof(AllFlower));
		}
	}
}
