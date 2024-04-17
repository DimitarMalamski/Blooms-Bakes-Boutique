using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Models.Flower;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Core.Services.ApplicationUser;
using Blooms___Bakes_Boutique.Core.Services.Flower;
using Blooms___Bakes_Boutique.Core.Services.Pastry;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	[TestFixture]
	public class FlowerServiceTests : UnitTestsBase
	{
		private IFlowerService flowerService;
		private IApplicationUserService applicationUserService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			flowerService = new FlowerService(repository);
			applicationUserService = new ApplicationUserService(repository);
		}

		[Test]

		public async Task AllFlowerCategoryNames_ShouldReturnCorrectResult()
		{
			var result = await flowerService.AllFlowerCategoriesNamesAsync();

			var dbFlowerCategories = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.FlowerCategory>()
				.ToList();

			Assert.That(result.Count(), Is.EqualTo(dbFlowerCategories.Count()));

			var flowerCategoryNames = dbFlowerCategories.Select(fc => fc.Name);

			Assert.That(flowerCategoryNames.Contains(result.FirstOrDefault()));
		}

		[Test]

		public async Task AllFlowersByFloristId_ShouldReturnCorrectFlowers()
		{
			var floristId = Florist.Id;

			var result = await flowerService.AllFlowersByFloristIdAsync(floristId);

			Assert.IsNotNull(result);

			var flowersInDb = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.Flower>()
				.Where(p => p.FloristId == floristId);

			Assert.That(result.Count(), Is.EqualTo(flowersInDb.Count()));
		}

		[Test]

		public async Task AllFlowersByUserId_ShouldReturnCorrectFlowers()
		{
			var gathererId = Gatherer.Id;

			var result = await flowerService.AllFlowersByUserId(gathererId);

			Assert.IsNotNull(result);

			var flowersInDb = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.Flower>()
				.Where(p => p.GathererId == gathererId);

			Assert.That(result.Count(), Is.EqualTo(flowersInDb.Count()));
		}

		[Test]

		public async Task FlowerExists_ShouldReturnCorrectTrue_WithValidId()
		{
			var flowerId = GatheredFlower.Id;

			var result = await flowerService.ExistsAsync(flowerId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task FlowerDetailsById_ShouldReturnCorrectFlowerData()
		{
			var flowerId = GatheredFlower.Id;

			var result = await flowerService.FlowerDetailsByIdAsync(flowerId);

			Assert.IsNotNull(result);

			var flowerInDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Flowers.Flower>(flowerId);

			Assert.That(result.Id, Is.EqualTo(flowerInDb.Id));
			Assert.That(result.Title, Is.EqualTo(flowerInDb.Title));
		}

		[Test]
		public async Task AllFlowerCategories_ShouldReturnCorrectFlowerCategories()
		{
			var result = await flowerService.AllFlowerCategoriesAsync();

			var dbFlowerCategories = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.FlowerCategory>()
				.ToList();

			Assert.That(result.Count(), Is.EqualTo(dbFlowerCategories.Count()));

			var flowerCategoryNames = dbFlowerCategories
				.Select(fc => fc.Name);

			Assert.That(flowerCategoryNames.Contains(result.FirstOrDefault().Name));
		}

		[Test]

		public async Task CreateFlower_ShouldCreateFlower()
		{
			var flowersInDbBefore = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.Flower>()
				.Count();

			var newFlower = new Infrastructure.Data.Models.Flowers.Flower()
			{
				Title = "New Flower",
				Description = "The cutest of them all...",
				Colour = "Red",
				ImageUrl = "https://www.floraldesigninstitute.com/cdn/shop/articles/Tulip-Single-Rounded-299x315.jpg?v=1651708280"
			};

			var newFlowerId = await flowerService.CreateAsync(new FlowerFormModel()
			{
				Title = newFlower.Title,
				Description = newFlower.Description,
				Colour = newFlower.Colour,
				ImageUrl = newFlower.ImageUrl,
				CategoryId = 1,
				PricePerBouquet = 5.00M,
			},
				Florist.Id);

			var flowersInDbAfter = repository.AllReadOnly<Infrastructure.Data.Models.Flowers.Flower>()
				.Count();

			Assert.That(flowersInDbAfter, Is.EqualTo(flowersInDbBefore + 1));

			var newFlowerinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Flowers.Flower>(newFlowerId);

			Assert.That(newFlowerinDb.Title, Is.EqualTo(newFlower.Title));
		}

		[Test]
		public async Task HasFloristsWithId_ShouldReturnTrue_WithValidId()
		{
			var flowerId = GatheredFlower.Id;

			var userId = GatheredFlower.Florist.User.Id;

			var result = await flowerService.HasFloristWithIdAsync(flowerId, userId);

			Assert.IsTrue(result);
		}

		[Test]

		public async Task EditFlower_ShouldEditFlower()
		{
			var flower = new Infrastructure.Data.Models.Flowers.Flower()
			{
				Title = "New Flower",
				Description = "The cutest of them all...",
				Colour = "Red",
				ImageUrl = "https://www.floraldesigninstitute.com/cdn/shop/articles/Tulip-Single-Rounded-299x315.jpg?v=1651708280"
			};

			await repository.AddAsync(flower);
			await repository.SaveChangesAsync();

			var changedDescription = "This is a new one!";

			await flowerService.EditAsync(flower.Id, new FlowerFormModel()
			{
				Title = flower.Title,
				Description = changedDescription,
				Colour = flower.Colour,
				ImageUrl = flower.ImageUrl,
				CategoryId = flower.CategoryId,
				PricePerBouquet = flower.PricePerBouquet,
			});

			var newFlowerinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Flowers.Flower>(flower.Id);

			Assert.IsNotNull(newFlowerinDb);
			Assert.That(newFlowerinDb.Title, Is.EqualTo(flower.Title));
			Assert.That(newFlowerinDb.Description, Is.EqualTo(changedDescription));
		}

		[Test]
		public async Task IsGathered_ShouldReturnCorrectTrue_WithValidId()
		{
			var flowerId = GatheredFlower.Id;

			var result = await flowerService.IsGatheredAsync(flowerId);

			Assert.IsTrue(result);
		}

		[Test]

		public async Task Gather_ShouldGatherFlowerSuccessfully()
		{
			var flower = new Infrastructure.Data.Models.Flowers.Flower()
			{
				Title = "New Flower",
				Description = "The cutest of them all...",
				Colour = "Red",
				ImageUrl = "https://www.floraldesigninstitute.com/cdn/shop/articles/Tulip-Single-Rounded-299x315.jpg?v=1651708280"
			};

			await repository.AddAsync(flower);
			await repository.SaveChangesAsync();

			var gathererId = Gatherer.Id;

			await flowerService.GatherAsync(flower.Id, gathererId);

			var newFlowerinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Flowers.Flower>(flower.Id);

			Assert.IsNotNull(newFlowerinDb);
			Assert.That(gathererId, Is.EqualTo(flower.GathererId));
		}

		[Test]

		public async Task Ungather_ShouldUngatherFlowerSuccessfully()
		{
			//var userId = TastedPastry.Taster.Id;

			var flower = new Infrastructure.Data.Models.Flowers.Flower()
			{
				Title = "New Flower",
				GathererId = "GathererId",
				Description = "The cutest of them all...",
				Colour = "Red",
				ImageUrl = "https://www.floraldesigninstitute.com/cdn/shop/articles/Tulip-Single-Rounded-299x315.jpg?v=1651708280"
			};

			await repository.AddAsync(flower);
			await repository.SaveChangesAsync();

			var userId = flower.GathererId;

			await flowerService.UngatherAsync(flower.Id, userId);

			Assert.IsNull(flower.GathererId);

			var newFlowerinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Flowers.Flower>(flower.Id);

			Assert.IsNotNull(newFlowerinDb);
			Assert.IsNull(newFlowerinDb.GathererId);
		}

		[Test]
		public async Task DoesFlower_Categoryexists_Seccessfully()
		{
			var flowerCategoryId = GatheredFlower.FlowerCategory.Id;

			var result = await flowerService.FlowerCategoryExistsAsync(flowerCategoryId);

			Assert.IsTrue(result);
		}
	}
}
