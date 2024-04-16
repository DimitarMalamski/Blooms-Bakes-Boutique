using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static Blooms___Bakes_Boutique.Areas.Admin.AdministratorConstants;

namespace Blooms___Bakes_Boutique.Areas.Admin.Controllers
{
    public class TasteController : AdminController
	{
		private readonly ITasteService tasteService;
		private readonly IMemoryCache memoryCache;

        public TasteController(
			ITasteService _tasteService,
            IMemoryCache _memoryCache)
        {
            tasteService = _tasteService;
			memoryCache = _memoryCache;
        }

		[Route("Taste/All")]
        public async Task<IActionResult> All()
		{
			var model = memoryCache
				.Get<IEnumerable<TasteServiceModel>>(UsersCacheKey);

			if (model == null)
			{
                model = await tasteService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(TastesCacheKey, model, cacheOptions);
            }			

			return View(model);
		}
	}
}
