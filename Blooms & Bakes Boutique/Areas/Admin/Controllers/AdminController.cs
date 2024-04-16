using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	[Area(AdminAreaName)]
	[Authorize(Roles = AdminRole)]
	public class AdminController : Controller
	{

	}
}
