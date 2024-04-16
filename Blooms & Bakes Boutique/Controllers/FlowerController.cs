using Blooms___Bakes_Boutique.Attributes;
using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Exceptions;
using Blooms___Bakes_Boutique.Core.Extensions;
using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;
using Microsoft.Extensions.Caching.Memory;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class FlowerController : BaseController
    {
		private readonly IFlowerService flowerService;
		private readonly IFloristService floristService;
		private readonly IMemoryCache memoryCache;
		private readonly ILogger logger;

		public FlowerController(
			IFlowerService _flowerService,
			IFloristService _floristService,
			ILogger<FlowerController> _logger,
            IMemoryCache _memoryCache)
		{
			flowerService = _flowerService;
			floristService = _floristService;
			logger = _logger;
			memoryCache = _memoryCache;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> AllFlower([FromQuery]AllFlowersQueryModel model)
		{
			var flowers = await flowerService.AllFlowerAsync(
				model.FlowerCategory,
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				model.FlowersPerPage);

			model.TotalFlowersCount = flowers.TotalFlowersCount;
			model.Flowers = flowers.Flowers;
			model.FlowerCategories = await flowerService.AllFlowerCategoriesNamesAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> MineFlower()
		{
			var userId = User.Id();
			IEnumerable<FlowerServiceModel> model;

			if (User.IsAdmin())
			{
				return RedirectToAction("MineFlower", "Flower", new { area = "Admin" });
			}

			if (await floristService.ExistByIdAsync(userId))
			{
				int floristId = await floristService.GetFloristIdAsync(userId) ?? 0;
				model = await flowerService.AllFlowersByFloristIdAsync(floristId);
			}
			else
			{
				model = await flowerService.AllFlowersByUserId(userId);
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> FlowerDetails(int id, string information)
		{
			if (await flowerService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			var model = await flowerService.FlowerDetailsByIdAsync(id);


			if (information != model.GetInformation())
			{
				return BadRequest();
			}

			return View(model);
		}

		[HttpGet]
		[MustBeFlorist]
		public async Task<IActionResult> AddFlower()
		{
			var model = new FlowerFormModel()
			{
				FlowerCategories = await flowerService.AllFlowerCategoriesAsync()
			};

			return View(model);
		}

		[HttpPost]
		[MustBeFlorist]
		public async Task<IActionResult> AddFlower(FlowerFormModel model)
		{
			if (await flowerService.FlowerCategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), FlowerCategoryDoesNotExist);
			}

			if (ModelState.IsValid == false)
			{
				model.FlowerCategories = await flowerService.AllFlowerCategoriesAsync();

				return View(model);
			}

			int? floristId = await floristService.GetFloristIdAsync(User.Id());

			int newFlowerId = await flowerService.CreateAsync(model, floristId ?? 0);

			TempData["message"] = "You have successfully added a flower!";

			return RedirectToAction(nameof(FlowerDetails), new { id = newFlowerId, information = model.GetInformation() });
		}

		[HttpGet]
		public async Task<IActionResult> EditFlower(int id)
		{
			if (await flowerService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await flowerService.HasFloristWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var model = await flowerService.GetFlowerFormModelByIdAsync(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditFlower(int id, FlowerFormModel model)
		{
			if (await flowerService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await flowerService.HasFloristWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if (await flowerService.FlowerCategoryExistsAsync(model.CategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.CategoryId), FlowerCategoryDoesNotExist);
			}

			if (ModelState.IsValid == false)
			{
				model.FlowerCategories = await flowerService.AllFlowerCategoriesAsync();

				return View(model);
			}

			await flowerService.EditAsync(id, model);

			TempData["message"] = "You have successfully edited a flower!";

			return RedirectToAction(nameof(FlowerDetails), new { id = id, information = model.GetInformation() });
		}

		[HttpGet]
		public async Task<IActionResult> DeleteFlower(int id)
		{
			if (await flowerService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await flowerService.HasFloristWithIdAsync(id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			var pastry = await flowerService.FlowerDetailsByIdAsync(id);

			var model = new FlowerDetailsViewModel()
			{
				Id = id,
				Colour = pastry.Description,
				ImageUrl = pastry.ImageUrl,
				Title = pastry.Title
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteFlower(FlowerDetailsViewModel model)
		{
			if (await flowerService.ExistsAsync(model.Id) == false)
			{
				return BadRequest();
			}

			if (await flowerService.HasFloristWithIdAsync(model.Id, User.Id()) == false
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await flowerService.DeleteAsync(model.Id);

			TempData["message"] = "You have successfully deleted a flower!";

			return RedirectToAction(nameof(AllFlower));
		}

		[HttpPost]
		public async Task<IActionResult> Gather(int id)
		{
			if (await flowerService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			if (await floristService.ExistByIdAsync(User.Id())
				&& User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			if (await flowerService.IsGatheredAsync(id))
			{
				return BadRequest();
			}

			await flowerService.GatherAsync(id, User.Id());

			memoryCache.Remove(GathersCacheKey);

			TempData["message"] = "You have successfully gathered a flower!";

			return RedirectToAction(nameof(AllFlower));
		}

		[HttpPost]
		public async Task<IActionResult> Ungather(int id)
		{
			if (await flowerService.ExistsAsync(id) == false)
			{
				return BadRequest();
			}

			try
			{
				await flowerService.UngatherAsync(id, User.Id());
			}
			catch (UnauthorizedActionException uae)
			{
				logger.LogError(uae, "FlowerController/Ungather");

				return Unauthorized();
			}

            memoryCache.Remove(GathersCacheKey);

			TempData["message"] = "You have successfully ungathered a flower!";

			return RedirectToAction(nameof(AllFlower));
		}
	}
}
