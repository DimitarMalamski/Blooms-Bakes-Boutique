﻿using Blooms___Bakes_Boutique.Attributes;
using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Blooms___Bakes_Boutique.Core.Constants.MessageConstants;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class FlowerController : BaseController
    {
		private readonly IFlowerService flowerService;
		private readonly IFloristService floristService;

		public FlowerController(
			IFlowerService _flowerService,
			IFloristService _floristService)
		{
			flowerService = _flowerService;
			floristService = _floristService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> AllFlower()
		{
			return View(new AllFlowersQueryModel());
		}

		[HttpGet]
		public async Task<IActionResult> MineFlower()
		{
			return View(new AllFlowersQueryModel());
		}

		[HttpGet]
		public async Task<IActionResult> FlowerDetails(int id)
		{
			return View(new FlowerDetailsViewModel());
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

			return RedirectToAction(nameof(FlowerDetails), new { id = newFlowerId });
		}

		[HttpGet]
		public async Task<IActionResult> EditFlower(int id)
		{
			return View(new FlowerFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> EditFlower(int id, FlowerFormModel model)
		{
			return RedirectToAction(nameof(FlowerDetails), new { id = "1" });
		}

		[HttpGet]
		public async Task<IActionResult> DeleteFlower(int id)
		{
			return View(new FlowerFormModel());
		}

		[HttpPost]
		public async Task<IActionResult> DeleteFlower(FlowerDetailsViewModel model)
		{
			return RedirectToAction(nameof(AllFlower));
		}

		[HttpPost]
		public async Task<IActionResult> Gather(int id)
		{
			return RedirectToAction(nameof(MineFlower));
		}

		[HttpPost]
		public async Task<IActionResult> Ungather(int id)
		{
			return RedirectToAction(nameof(MineFlower));
		}
	}
}
