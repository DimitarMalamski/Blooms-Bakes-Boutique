using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Blooms___Bakes_Boutique.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries;
using Patissier = Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	[TestFixture]
	public class PatissierServiceClass : UnitTestsBase
	{
		private IPatissierService patissierService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			patissierService = new PatissierService(repository);
		}

		[Test]
		public async Task GetPatissierId_ShoudReturnCorrectUserId()
		{
			//Assert

			//Act
			var resultPatissierId = await patissierService.GetPatissierIdAsync(Patissier.UserId);

			//Assert a correct id is returned
			Assert.That(Convert.ToInt32(resultPatissierId), Is.EqualTo(Patissier.Id));
		}

		[Test]
		public async Task ExistById_ShouldReturnTrue_WithValidIdAsync()
		{
			//Assert

			//Act
			var result = await patissierService.ExistByIdAsync(Patissier.UserId);

			//Assert a correct id is returned
			Assert.IsTrue(result);
		}

		[Test]
		public async Task PatissierWithMasterChefTitleExists_ShouldReturnTrue_WithValidData()
		{
			//Assert

			//Act
			var result = await patissierService.PatissierWithMasterChefTitleExistsAsync(Patissier.MasterChefTitle);

			//Assert a correct id is returned
			Assert.IsTrue(result);
		}

		[Test]
		public async Task CreatedPatissier_ShouldWorkCorrectly()
		{
			var patissiersBefore = repository.AllReadOnly<Patissier>().ToList();

			await patissierService.CreateAsync(Patissier.UserId, Patissier.MasterChefTitle);

			var patissiersAfter = repository.AllReadOnly<Patissier>().ToList();

			Assert.That(patissiersAfter.Count(), Is.EqualTo(patissiersBefore.Count() + 1));

			var newPatissierId = await patissierService.GetPatissierIdAsync(Patissier.User.Id);
			var newPatissierIdDb = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier>(newPatissierId);

			Assert.IsNotNull(newPatissierIdDb);
			Assert.That(newPatissierIdDb.User.Id, Is.EqualTo(Patissier.User.Id));
			Assert.That(newPatissierIdDb.MasterChefTitle, Is.EqualTo(Patissier.MasterChefTitle));
		}

	}
}
