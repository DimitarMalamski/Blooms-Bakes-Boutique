using System.Globalization;
using Blooms___Bakes_Boutique.Infrastructure.Data;
using Blooms___Bakes_Boutique.ModelBinders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adding application DBContext and Identity
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
	options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddMvc((options) =>
{
	options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
});

//Adding application Services
builder.Services.AddApplicationServices();

builder.Services.AddMemoryCache();

var app = builder.Build();

var supportedCultures = new[]
{
	new CultureInfo("en-US"),
	new CultureInfo("es"),
};

app.UseRequestLocalization(new RequestLocalizationOptions()
{
	DefaultRequestCulture = new RequestCulture("en-US"),
	// Formatting numbers, dates, etc.
	SupportedCultures = supportedCultures,
	// Localized UI strings.
	SupportedUICultures = supportedCultures
});

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseMigrationsEndPoint();
}
else
{
	// for unexpected errors!
	app.UseExceptionHandler("/Home/Error/500");
	app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "Areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


	endpoints.MapControllerRoute(
		name: "Pastry Details",
		pattern: "/Pastry/Details/{id}/{information}",
		defaults: new { Controller = "Pastry", Action = "PastryDetails" }
	);

	endpoints.MapControllerRoute(
		name: "Flower Details",
		pattern: "/Flower/Details/{id}/{information}",
		defaults: new { Controller = "Flower", Action = "FlowerDetails" }
	);
	endpoints.MapDefaultControllerRoute();
	endpoints.MapRazorPages();
});

app.SeedAdmin();

await app.RunAsync();
