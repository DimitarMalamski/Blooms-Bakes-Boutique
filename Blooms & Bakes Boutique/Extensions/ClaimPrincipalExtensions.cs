using System.Security.Claims;

namespace Blooms___Bakes_Boutique.Extensions
{
	public static class ClaimPrincipalExtensions
	{
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
