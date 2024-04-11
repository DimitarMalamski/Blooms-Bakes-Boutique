using Blooms___Bakes_Boutique.Attributes;
using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Models.Florist;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;

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
		[NotAFlorist]
		public IActionResult BecomeFlorist()
		{
			var model = new BecomeFloristFormModel();

			return View(model);
		}

		[HttpPost]
        [NotAFlorist]
        public async Task<IActionResult> BecomeFlorist(BecomeFloristFormModel model)
		{
            if (await floristService.UserWithFlowerMasterTitleExistsAsync(User.Id()))
            {
                ModelState.AddModelError(nameof(model.FlowerMasterTitle), FlowerMasterTitleExists);
            }

            if (await floristService.UserHasGatheredFlowersAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasGathered);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await floristService.CreateAsync(User.Id(), model.FlowerMasterTitle);

            return RedirectToAction(nameof(FlowerController.AllFlower), "Flower");
        }
	}
}
