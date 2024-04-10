using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Controllers
{
    [Authorize]
    public class PastryController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> AllPastry()
        {
            return View(new AllPastriesQueryModel());
        }

        public async Task<IActionResult> MinePastry()
        {
            return View(new AllPastriesQueryModel());
        }

        public async Task<IActionResult> PastryDetails(int id)
        {
            return View(new PastryDetailsViewModel());
        }

        public async Task<IActionResult> AddPastry()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddPastry(PastryFormModel model)
		{
            return RedirectToAction(nameof(PastryDetails), new { id = "1" });
		}

		public async Task<IActionResult> EditPastry(int id)
		{
            return View(new PastryFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> EditPastry(int id, PastryFormModel model)
		{
			return RedirectToAction(nameof(PastryDetails), new { id = "1" });
		}
		public async Task<IActionResult> DeletePastry(int id)
		{
			return View(new PastryFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> DeletePastry(PastryDetailsViewModel model)
		{
			return RedirectToAction(nameof(AllPastry));
		}


	}
}
