using Blooms___Bakes_Boutique.Attributes;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Exceptions;
using Blooms___Bakes_Boutique.Core.Extensions;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class PastryController : BaseController
    {
		private readonly IPastryService pastryService;
		private readonly IPatissierService patissierService;
		private readonly ILogger logger;

        public PastryController(
			IPastryService _pastryService,
			IPatissierService _patissierService,
			ILogger<PastryController> _logger)
        {
			pastryService = _pastryService;
			patissierService = _patissierService;
			logger = _logger;
        }

        [AllowAnonymous]
		[HttpGet]
        public async Task<IActionResult> AllPastry([FromQuery]AllPastriesQueryModel model)
        {
			var pastries = await pastryService.AllPastryAsync(
				model.PastryCategory,
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				model.PastriesPerPage);

			model.TotalPastriesCount = pastries.TotalPastriesCount;
			model.Pastries = pastries.Pastries;
			model.PastryCategories = await pastryService.AllPastryCategoriesNamesAsync();

			return View(model);
        }

		[HttpGet]
		public async Task<IActionResult> MinePastry()
        {
			var userId = User.Id();
			IEnumerable<PastryServiceModel> model;

			if (await patissierService.ExistByIdAsync(userId))
			{
				int patissierId = await patissierService.GetPatissierIdAsync(userId) ?? 0;
				model = await pastryService.AllPastriesByPatissierIdAsync(patissierId);
			}
			else
			{
				model = await pastryService.AllPastriesByUserId(userId);
			}

			return View(model);
        }

		[HttpGet]
        public async Task<IActionResult> PastryDetails(int id, string information)
        {
			if (await pastryService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await pastryService.PastryDetailsByIdAsync(id);

			if (information != model.GetInformation())
			{
				return BadRequest();
			}

			return View(model);
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

            return RedirectToAction(nameof(PastryDetails), new { id = newPastryId, information = model.GetInformation() });
		}

		[HttpGet]
		public async Task<IActionResult> EditPastry(int id)
		{
			if (await pastryService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await pastryService.HasPatissierWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = await pastryService.GetPastryFormModelByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditPastry(int id, PastryFormModel model)
		{
			if (await pastryService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await pastryService.HasPatissierWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if (await pastryService.PastryCategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), PastryCategoryDoesNotExist);
			}

			if (ModelState.IsValid == false)
			{
				model.PastryCategories = await pastryService.AllPastryCategoriesAsync();

				return View(model);
			}

			await pastryService.EditAsync(id, model);

			return RedirectToAction(nameof(PastryDetails), new { id = id, Information = model.GetInformation() });
		}

		[HttpGet]
		public async Task<IActionResult> DeletePastry(int id)
		{		
			if (await pastryService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await pastryService.HasPatissierWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var pastry = await pastryService.PastryDetailsByIdAsync(id);

			var model = new PastryDetailsViewModel()
			{
				Id = id,
				Description = pastry.Description,
				ImageUrl = pastry.ImageUrl,
				Title = pastry.Title
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> DeletePastry(PastryDetailsViewModel model)
		{
			if (await pastryService.ExistsAsync(model.Id) == false)
			{
				return BadRequest();
			}

			if (await pastryService.HasPatissierWithIdAsync(model.Id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await pastryService.DeleteAsync(model.Id);

			return RedirectToAction(nameof(AllPastry));
		}

		[HttpPost]
		public async Task<IActionResult> Taste(int id)
		{
			if (await pastryService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await patissierService.ExistByIdAsync(User.Id())
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if (await pastryService.IsTastedAsync(id)) 
			{
				return BadRequest();
			}

			await pastryService.TasteAsync(id, User.Id());

			return RedirectToAction(nameof(AllPastry));
		}

		[HttpPost]
		public async Task<IActionResult> Untaste(int id)
		{
			if (await pastryService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			try
			{
				await pastryService.UntasteAsync(id, User.Id());
			}
			catch (UnauthorizedActionException uae)
			{
				logger.LogError(uae, "PastryController/Untaste");

				return Unauthorized();
			}	
			
			return RedirectToAction(nameof(AllPastry));
		}
	}
}
