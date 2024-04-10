﻿using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class HomeController : Controller
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

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
