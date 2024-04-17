using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Services.Actions;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	public class TasteServiceTests : UnitTestsBase
	{
		private ITasteService tasteService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			tasteService = new TasteService(repository);
		}

		[Test]

		public async Task All_ShouldReturnCorrectData()
		{
			var result = await tasteService.AllAsync();

			Assert.IsNotNull(result);

			var tastedpastriesCount = repository.AllReadOnly<Pastry>()
		}
	}
}
