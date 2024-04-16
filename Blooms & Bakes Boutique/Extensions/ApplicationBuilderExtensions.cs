using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace Microsoft.AspNetCore.Builder
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
		{
			using var scopedServices = app.ApplicationServices.CreateScope();

			var services = scopedServices.ServiceProvider;

			var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

			Task
				.Run(async () =>
				{
					if (await roleManager.RoleExistsAsync(AdminRole))
					{
						return;
					}

					var role = new IdentityRole { Name = AdminRole };

					await roleManager.CreateAsync(role);

					var admin = await userManager.FindByNameAsync(AdminEmail);

					await userManager.AddToRoleAsync(admin, role.Name);
				})
				.GetAwaiter()
				.GetResult();

			return app;
		}
	}
}
