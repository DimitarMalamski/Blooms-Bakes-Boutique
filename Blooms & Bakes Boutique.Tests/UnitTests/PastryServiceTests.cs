using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Blooms___Bakes_Boutique.Core.Services.ApplicationUser;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Models.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Pastry;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Microsoft.EntityFrameworkCore;
using static Blooms___Bakes_Boutique.Infrastructure.Constants.DataConstants.Pastries;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	[TestFixture]
	public class PastryServiceTests : UnitTestsBase
	{
		private IPastryService pastryService;
		private IApplicationUserService applicationUserService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			pastryService = new PastryService(repository);
			applicationUserService = new ApplicationUserService(repository);
		}

		[Test]

		public async Task AllPastryCategoryNames_ShouldReturnCorrectResult()
		{
			var result = await pastryService.AllPastryCategoriesNamesAsync();

			var dbPastryCategories = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.PastryCategory>()
				.ToList();

			Assert.That(result.Count(), Is.EqualTo(dbPastryCategories.Count()));

			var pastryCategoryNames = dbPastryCategories.Select(pc => pc.Name);

			Assert.That(pastryCategoryNames.Contains(result.FirstOrDefault()));
		}

		[Test]

		public async Task AllPastriesByPatissierId_ShouldReturnCorrectPastries()
		{
			var patissierId = Patissier.Id;

			var result = await pastryService.AllPastriesByPatissierIdAsync(patissierId);

			Assert.IsNotNull(result);

			var pastriesInDb = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.Pastry>()
				.Where(p => p.PatissierId == patissierId);

			Assert.That(result.Count(), Is.EqualTo(pastriesInDb.Count()));
		}

		[Test]

		public async Task AllPastriesByUserId_ShouldReturnCorrectPastries()
		{
			var tasterId = Taster.Id;

			var result = await pastryService.AllPastriesByUserId(tasterId);

			Assert.IsNotNull(result);

			var pastriesInDb = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.Pastry>()
				.Where(p => p.TasterId == tasterId);

			Assert.That(result.Count(), Is.EqualTo(pastriesInDb.Count()));
		}

		[Test]

		public async Task PastryExists_ShouldReturnCorrectTrue_WithValidId()
		{
			var pastryId = TastedPastry.Id;

			var result = await pastryService.ExistsAsync(pastryId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task PastryDetailsById_ShouldReturnCorrectPastryData()
		{
			var pastryId = TastedPastry.Id;

			var result = await pastryService.PastryDetailsByIdAsync(pastryId);

			Assert.IsNotNull(result);

			var pastryInDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Pastries.Pastry>(pastryId);

			Assert.That(result.Id, Is.EqualTo(pastryInDb.Id));
			Assert.That(result.Title, Is.EqualTo(pastryInDb.Title));
		}

		[Test]
		public async Task AllPastryCategories_ShouldReturnCorrectPastryCategories()
		{
			var result = await pastryService.AllPastryCategoriesAsync();

			var dbPastryCategories = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.PastryCategory>()
				.ToList();

			Assert.That(result.Count(), Is.EqualTo(dbPastryCategories.Count()));

			var pastryCategoryNames = dbPastryCategories
				.Select(pc => pc.Name);

			Assert.That(pastryCategoryNames.Contains(result.FirstOrDefault().Name));
		}

		[Test]

		public async Task CreatePastry_ShouldCreatePastry()
		{
			var pastriesInDbBefore = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.Pastry>()
				.Count();

			var newPastry = new Infrastructure.Data.Models.Pastries.Pastry()
			{
				Title = "New Pastry",
				Description = "The sweetest of them all...",
				Recipe = "Made of sweet chocolate, almond milk and lots of more goodies",
				ImageUrl = "https://preppykitchen.com/wp-content/uploads/2022/05/Naked-Cake-Recipe-Card.jpg"
			};

			var newPastryId = await pastryService.CreateAsync(new PastryFormModel()
				{
					Title = newPastry.Title,
					Description = newPastry.Description,
					Recipe = newPastry.Recipe,
					ImageUrl = newPastry.ImageUrl,
					CategoryId = 1,
					Price = 10.00M,
				},
				Patissier.Id);

			var pastriesInDbAfter = repository.AllReadOnly<Infrastructure.Data.Models.Pastries.Pastry>()
				.Count();

			Assert.That(pastriesInDbAfter, Is.EqualTo(pastriesInDbBefore + 1));

			var newPastryinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Pastries.Pastry>(newPastryId);

			Assert.That(newPastryinDb.Title, Is.EqualTo(newPastry.Title));
		}

		[Test]
		public async Task HasPatissiesWithId_ShouldReturnTrue_WithValidId()
		{
			var pastryId = TastedPastry.Id;

			var userId = TastedPastry.Patissier.User.Id;

			var result = await pastryService.HasPatissierWithIdAsync(pastryId, userId);

			Assert.IsTrue(result);
		}

		[Test]

		public async Task EditPastry_ShouldEditPastry()
		{
			var pastry = new Infrastructure.Data.Models.Pastries.Pastry()
			{
				Title = "New Pastry",
				Description = "The sweetest of them all...",
				Recipe = "Made of sweet chocolate, almond milk and lots of more goodies",
				ImageUrl = "https://preppykitchen.com/wp-content/uploads/2022/05/Naked-Cake-Recipe-Card.jpg"
			};

			await repository.AddAsync(pastry);
			await repository.SaveChangesAsync();

			var changedDescription = "This is a new one!";

			await pastryService.EditAsync(pastry.Id, new PastryFormModel()
				{
					Title = pastry.Title,
					Description = changedDescription,
					Recipe = pastry.Recipe,
					ImageUrl = pastry.ImageUrl,
					CategoryId = pastry.CategoryId,
					Price = pastry.Price,
				});

			var newPastryinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Pastries.Pastry>(pastry.Id);

			Assert.IsNotNull(newPastryinDb);
			Assert.That(newPastryinDb.Title, Is.EqualTo(pastry.Title));		
			Assert.That(newPastryinDb.Description, Is.EqualTo(changedDescription));
		}

		[Test]
		public async Task IsTasted_ShouldReturnCorrectTrue_WithValidId()
		{
			var pastryId = TastedPastry.Id;

			var result = await pastryService.IsTastedAsync(pastryId);

			Assert.IsTrue(result);
		}

		[Test]

		public async Task Taste_ShouldTastePastrySuccessfully()
		{
			var pastry = new Infrastructure.Data.Models.Pastries.Pastry()
			{
				Title = "New Pastry",
				Description = "The sweetest of them all...",
				Recipe = "Made of sweet chocolate, almond milk and lots of more goodies",
				ImageUrl = "https://preppykitchen.com/wp-content/uploads/2022/05/Naked-Cake-Recipe-Card.jpg"
			};

			await repository.AddAsync(pastry);
			await repository.SaveChangesAsync();

			var tasterId = Taster.Id;

			await pastryService.TasteAsync(pastry.Id, tasterId);	

			var newPastryinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Pastries.Pastry>(pastry.Id);

			Assert.IsNotNull(newPastryinDb);
			Assert.That(tasterId, Is.EqualTo(pastry.TasterId));
		}

		[Test]

		public async Task Untaste_ShouldUntastePastrySuccessfully()
		{
			//var userId = TastedPastry.Taster.Id;

			var pastry = new Infrastructure.Data.Models.Pastries.Pastry()
			{
				Title = "New Pastry",
				TasterId = "TasterId",
				Description = "The sweetest of them all...",
				Recipe = "Made of sweet chocolate, almond milk and lots of more goodies",
				ImageUrl = "https://preppykitchen.com/wp-content/uploads/2022/05/Naked-Cake-Recipe-Card.jpg"
			};

			await repository.AddAsync(pastry);
			await repository.SaveChangesAsync();

			var userId = pastry.TasterId;

			await pastryService.UntasteAsync(pastry.Id, userId);

			Assert.IsNull(pastry.TasterId);

			var newPastryinDb = await repository.GetByIdAsync<Infrastructure.Data.Models.Pastries.Pastry>(pastry.Id);

			Assert.IsNotNull(newPastryinDb);
			Assert.IsNull(newPastryinDb.TasterId);
		}

		[Test]

		public async Task DoesPastry_Categoryexists_Seccessfully()
		{
			var pastryCategoryId = TastedPastry.PastryCategory.Id;

			var result = await pastryService.PastryCategoryExistsAsync(pastryCategoryId);

			Assert.IsTrue(result);
		}

	}
}
