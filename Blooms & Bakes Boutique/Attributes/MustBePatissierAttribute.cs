using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Blooms___Bakes_Boutique.Controllers;

namespace Blooms___Bakes_Boutique.Attributes
{
	public class MustBePatissierAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IPatissierService? patissierService = context.HttpContext.RequestServices.GetService<IPatissierService>();

			if (patissierService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (patissierService != null
				&& patissierService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
			{
				context.Result = new RedirectToActionResult(nameof(PatissierController.BecomePatissier), "Patissier", null);
			}

		}
	}
}
