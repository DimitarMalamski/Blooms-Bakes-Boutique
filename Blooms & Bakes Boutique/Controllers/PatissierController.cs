using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Models.Patissier;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> BecomePatissier()
        {
            if (await patissierService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomePatissierFormModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> BecomePatissier(BecomePatissierFormModel model)
        {
            return RedirectToAction(nameof(PastryController.AllPastry), "Pastry");
        }
    }
}
