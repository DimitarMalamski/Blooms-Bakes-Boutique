using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Blooms___Bakes_Boutique.Attributes
{
	public class NotAFloristAttribute : ActionFilterAttribute
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
				&& floristService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}

		}
	}
}
