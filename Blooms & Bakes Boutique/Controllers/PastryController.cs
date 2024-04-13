using Blooms___Bakes_Boutique.Attributes;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class PastryController : BaseController
    {
		private readonly IPastryService pastryService;
		private readonly IPatissierService patissierService;

        public PastryController(
			IPastryService _pastryService,
			IPatissierService _patissierService)
        {
			pastryService = _pastryService;
			patissierService = _patissierService;
        }

        [AllowAnonymous]
		[HttpGet]
        public async Task<IActionResult> AllPastry([FromQuery]AllPastriesQueryModel query)
        {
            return View(query);
        }

		[HttpGet]
		public async Task<IActionResult> MinePastry()
        {
            return View(new AllPastriesQueryModel());
        }

		[HttpGet]
        public async Task<IActionResult> PastryDetails(int id)
        {
            return View(new PastryDetailsViewModel());
        }

		[HttpGet]
		[MustBePatissier]
		public async Task<IActionResult> AddPastry()
		{
			var model = new PastryFormModel()
			{
				PastryCategories = await pastryService.AllPastryCategoriesAsync()
			};

			return View(model);
        }

		[HttpPost]
		[MustBePatissier]
		public async Task<IActionResult> AddPastry(PastryFormModel model)
		{
			if (await pastryService.PastryCategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), PastryCategoryDoesNotExist);
			}

			if (ModelState.IsValid == false)
			{
				model.PastryCategories = await pastryService.AllPastryCategoriesAsync();

				return View(model);
			}

			int? patissierId = await patissierService.GetPatissierIdAsync(User.Id());

			int newPastryId = await pastryService.CreateAsync(model, patissierId ?? 0);

            return RedirectToAction(nameof(PastryDetails), new { id = newPastryId });
		}

		[HttpGet]
		public async Task<IActionResult> EditPastry(int id)
		{
            return View(new PastryFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> EditPastry(int id, PastryFormModel model)
		{
			return RedirectToAction(nameof(PastryDetails), new { id = "1" });
		}

		[HttpGet]
		public async Task<IActionResult> DeletePastry(int id)
		{
			return View(new PastryFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> DeletePastry(PastryDetailsViewModel model)
		{
			return RedirectToAction(nameof(AllPastry));
		}

		[HttpPost]
		public async Task<IActionResult> Taste(int id)
		{
			return RedirectToAction(nameof(MinePastry));
		}

		[HttpPost]
		public async Task<IActionResult> Untaste(int id)
		{
			return RedirectToAction(nameof(MinePastry));
		}
	}
}
