using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Controllers
{
    public class PatissierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
