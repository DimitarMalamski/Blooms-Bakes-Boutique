using Blooms___Bakes_Boutique.Core.Models.Patissier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Controllers
{
    [Authorize]
    public class PatissierController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> BecomePatissier()
        {
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
