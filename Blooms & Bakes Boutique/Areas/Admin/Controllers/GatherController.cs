using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Models.Actions;
using Blooms___Bakes_Boutique.Core.Services.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
	public class GatherController : AdminController
	{
		private readonly IGatherService gatherService;
        private readonly IMemoryCache memoryCache;

        public GatherController(
			IGatherService _gatherService,
            IMemoryCache _memoryCache)
		{
			gatherService = _gatherService;
			memoryCache = _memoryCache;
		}

		[Route("Gather/All")]
		public async Task<IActionResult> All()
		{
			var model = memoryCache
                .Get<IEnumerable<GatherServiceModel>>(UsersCacheKey);

            if (model == null)
            {
                model = await gatherService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(GathersCacheKey, model, cacheOptions);
            }

            return View(model);
		}
	}
}
