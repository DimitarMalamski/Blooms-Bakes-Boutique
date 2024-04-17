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
	[TestFixture]
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

			var tastedPastriesInDb = repository.AllReadOnly<Pastry>()
				.Where(p => p.TasterId != null);

			Assert.That(result.ToList().Count(), Is.EqualTo(tastedPastriesInDb.Count()));

			var resultPastry = result.ToList()
				.Find(p => p.PastryTitle == TastedPastry.Title);

			Assert.IsNotNull(resultPastry);
			Assert.AreEqual(Taster.Email, resultPastry.TasterEmail);
			Assert.AreEqual(Taster.FirstName + " " + Taster.LastName,
				resultPastry.TasterFullName);

			Assert.AreEqual(Patissier.User.Email, resultPastry.PatissierEmail);
			Assert.AreEqual(Patissier.User.FirstName + " " + Patissier.User.LastName,
				resultPastry.PatissierFullName);
		}
	}
}
