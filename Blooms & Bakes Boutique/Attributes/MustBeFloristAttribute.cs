using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Blooms___Bakes_Boutique.Controllers;

namespace Blooms___Bakes_Boutique.Attributes
{
	public class MustBeFloristAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);

			IFloristService? floristService = context.HttpContext.RequestServices.GetService<IFloristService>();

			if (floristService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (floristService != null
				&& floristService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
			{
				context.Result = new RedirectToActionResult(nameof(FloristController.BecomeFlorist), "Florist", null);
			}

		}
	}
}
