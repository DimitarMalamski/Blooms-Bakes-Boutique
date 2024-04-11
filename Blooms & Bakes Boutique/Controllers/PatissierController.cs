using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Models.Patissier;
using Blooms___Bakes_Boutique.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            if (await patissierService.ExistById(User.Id()))
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
