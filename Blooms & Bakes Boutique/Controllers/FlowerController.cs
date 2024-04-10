using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class FlowerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
