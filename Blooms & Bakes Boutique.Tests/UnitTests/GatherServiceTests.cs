using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Services.Actions;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	[TestFixture]
	public class GatherServiceTests : UnitTestsBase
	{
		private IGatherService gatherService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			gatherService = new GatherService(repository);
		}

		[Test]

		public async Task All_ShouldReturnCorrectData()
		{
			var result = await gatherService.AllAsync();

			Assert.IsNotNull(result);

			var gatheredFlowersInDb = repository.AllReadOnly<Flower>()
				.Where(p => p.GathererId != null);

			Assert.That(result.ToList().Count(), Is.EqualTo(gatheredFlowersInDb.Count()));

			var resultFlower = result.ToList()
				.Find(f => f.FlowerTitle == GatheredFlower.Title);

			Assert.IsNotNull(resultFlower);
			Assert.AreEqual(Gatherer.Email, resultFlower.GathererEmail);
			Assert.AreEqual(Gatherer.FirstName + " " + Gatherer.LastName,
				resultFlower.GathererFullName);

			Assert.AreEqual(Florist.User.Email, resultFlower.FloristEmail);
			Assert.AreEqual(Florist.User.FirstName + " " + Florist.User.LastName,
				resultFlower.FloristFullName);
		}
	}
}
