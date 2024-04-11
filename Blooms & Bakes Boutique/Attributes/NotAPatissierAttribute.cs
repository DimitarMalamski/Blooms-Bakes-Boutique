﻿using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Blooms___Bakes_Boutique.Attributes
{
	public class NotAPatissierAttribute : ActionFilterAttribute
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
				&& patissierService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}

		}
	}
}
