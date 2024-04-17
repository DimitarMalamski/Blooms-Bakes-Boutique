using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Services.Florist;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	public class FloristServiceClass : UnitTestsBase
	{
		private IFloristService floristService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			floristService = new FloristService(repository);
		}
		[Test]
		public async Task GetFloristId_ShoudReturnCorrectUserId()
		{
			//Assert

			//Act
			var resultFlorsitId = await floristService.GetFloristIdAsync(Florist.UserId);

			//Assert a correct id is returned
			Assert.That(Convert.ToInt32(resultFlorsitId), Is.EqualTo(Patissier.Id));
		}

		[Test]
		public async Task ExistById_ShouldReturnTrue_WithValidIdAsync()
		{
			//Assert

			//Act
			var result = await floristService.ExistByIdAsync(Florist.UserId);

			//Assert a correct id is returned
			Assert.IsTrue(result);
		}

		[Test]
		public async Task FloristWithFlowerMasterTitleExists_ShouldReturnTrue_WithValidData()
		{
			//Assert

			//Act
			var result = await floristService.FloristWithFlowerMasterTitleExistsAsync(Florist.FlowerMasterTitle);

			//Assert a correct id is returned
			Assert.IsTrue(result);
		}
		[Test]
		public async Task CreatedFlorist_ShouldWorkCorrectly()
		{
			var newFloristId = await floristService.GetFloristIdAsync(Florist.UserId);
			var newFloristIdDb = await repository.GetByIdAsync<Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers.Florist>(newFloristId);

			Assert.IsNotNull(newFloristIdDb);
			Assert.That(newFloristIdDb.UserId, Is.EqualTo(Florist.UserId));
			Assert.That(newFloristIdDb.FlowerMasterTitle, Is.EqualTo(Florist.FlowerMasterTitle));
		}

	}
}
