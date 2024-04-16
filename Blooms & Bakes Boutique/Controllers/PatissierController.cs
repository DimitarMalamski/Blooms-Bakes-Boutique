using Blooms___Bakes_Boutique.Attributes;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Models.Patissier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;

namespace Blooms___Bakes_Boutique.Controllers
{
	public class PatissierController : BaseController
    {
        private readonly IPatissierService patissierService;

        public PatissierController(IPatissierService _patissierService)
        {
            patissierService = _patissierService;
        }

        [HttpGet]
        [NotAPatissier]
        public IActionResult BecomePatissier()
        {
            var model = new BecomePatissierFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAPatissier]
        public async Task<IActionResult> BecomePatissier(BecomePatissierFormModel model)
        {
            if (await patissierService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            if (await patissierService.UserWithMasterChefTitleExistsAsync(model.MasterChefTitle))
            {
                ModelState.AddModelError(nameof(model.MasterChefTitle), MasterChefTitleExists);
            }

            if (await patissierService.UserHasTastedPatriesAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasTasted);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await patissierService.CreateAsync(User.Id(), model.MasterChefTitle);

            TempData["message"] = "You have successfully become a patissier!";

            return RedirectToAction(nameof(PastryController.AllPastry), "Pastry");
        }
    }
}
