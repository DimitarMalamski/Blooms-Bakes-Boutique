using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class HomeController : AdminController
	{
		public IActionResult Index() => View();
	}
}
