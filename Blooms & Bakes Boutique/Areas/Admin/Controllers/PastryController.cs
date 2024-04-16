using Blooms___Bakes_Boutique.Areas.Admin.Models.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class PastryController : AdminController
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

		public async Task<IActionResult> MinePastry()
		{
			var userId = User.Id();
			int agentId = await patissierService.GetPatissierIdAsync(userId) ?? 0;
			var myPastries = new MyPastriesViewModel()
			{
				AddedPastries = await pastryService.AllPastriesByPatissierIdAsync(agentId),
				TastedPastries = await pastryService.AllPastriesByUserId(userId)
			};

			return View(myPastries);
		}
	}
}
