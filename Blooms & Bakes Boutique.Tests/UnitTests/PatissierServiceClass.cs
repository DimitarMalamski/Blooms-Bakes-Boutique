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

		//[Test]
		//public async Task CreatedPatissier_ShouldWorkCorrectly()
		//{
		//	//Assert
		//	var patissiersCountBefore = _data.Patissiers.Count();

		//	//Act
		//	await patissierService.CreateAsync(Patissier.UserId, Patissier.MasterChefTitle);

		//	//Assert a correct id is returned
		//	var patissiersCountAfter = _data.Patissiers.Count();

		//	Assert.That(patissiersCountAfter, Is.EqualTo(patissiersCountBefore + 1));

		//	var newPatissierId = await patissierService.GetPatissierIdAsync(Patissier.UserId);
		//	var newPatissierIdDb = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries.Patissier>(newPatissierId);

		//	Assert.IsNotNull(newPatissierIdDb);
		//	Assert.That(newPatissierIdDb.UserId, Is.EqualTo(Patissier.UserId));
		//	Assert.That(newPatissierIdDb.MasterChefTitle, Is.EqualTo(Patissier.MasterChefTitle));
		//}

	}
}
