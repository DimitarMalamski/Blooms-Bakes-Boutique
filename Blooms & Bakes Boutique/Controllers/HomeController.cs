using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IPastryService pastryService;
        //private readonly IFlowerService flowerService;

        public HomeController(
            ILogger<HomeController> logger
            /* IPastryService _pastryService,
            IFlowerService _flowerService*/ )
        {
            _logger = logger;
            //pastryService = _pastryService;
            //flowerService = _flowerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRole))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

			if (statusCode == 401)
			{
				return View("Error401");
			}

			return View();
        }
    }
}
