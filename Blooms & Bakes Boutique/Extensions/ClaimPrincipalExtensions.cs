﻿using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace System.Security.Claims;

public static class ClaimPrincipalExtensions
{
	public static string Id(this ClaimsPrincipal user)
	{
		return user.FindFirstValue(ClaimTypes.NameIdentifier);
	}

	public static bool IsAdmin(this ClaimsPrincipal user)
	{
		return user.IsInRole(AdminRole);
	}
}
