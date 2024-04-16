using Blooms___Bakes_Boutique.Areas.Admin.Models.Flower;
using Blooms___Bakes_Boutique.Areas.Admin.Models.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Services.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class FlowerController : AdminController
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
		public async Task<IActionResult> MineFlower()
		{
			var userId = User.Id();
			int agentId = await floristService.GetFloristIdAsync(userId) ?? 0;
			var myFlowers = new MyFlowersViewModel()
			{
				AddedFlowers = await flowerService.AllFlowersByFloristIdAsync(agentId),
				GatheredFlowers = await flowerService.AllFlowersByUserId(userId)
			};

			return View(myFlowers);
		}
	}
}
