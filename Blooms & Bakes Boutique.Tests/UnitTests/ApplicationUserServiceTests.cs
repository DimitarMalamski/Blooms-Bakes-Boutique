using Blooms___Bakes_Boutique.Core.Contracts.Actions;
using Blooms___Bakes_Boutique.Core.Services.Actions;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blooms___Bakes_Boutique.Core.Contracts.ApplicationUser;
using Blooms___Bakes_Boutique.Core.Services.ApplicationUser;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	[TestFixture]
	public class ApplicationUserServiceTests : UnitTestsBase
	{
		private IApplicationUserService applicationUserService;
		private IRepository repository;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			repository = new Repository(_data);
			applicationUserService = new ApplicationUserService(repository);
		}

		[Test]
		public async Task UserHasTastedPastries_ShouldReturnTrue_WithValidData()
		{
			var result = await applicationUserService.UserHasTastedPatriesAsync(Taster.Id);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task UserHasGatheredFlowers_ShouldReturnTrue_WithValidData()
		{
			var result = await applicationUserService.UserHasGatheredFlowersAsync(Gatherer.Id);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task UserTasterFullName_ShouldReturnCorrentResult()
		{
			var result = await applicationUserService.UserFullNameAsync(Taster.Id);

			var tasterFullName = Taster.FirstName + " " + Taster.LastName;

			Assert.That(result, Is.EqualTo(tasterFullName));
		}

		[Test]
		public async Task UserGathererFullName_ShouldReturnCorrentResult()
		{
			var result = await applicationUserService.UserFullNameAsync(Gatherer.Id);

			var gathererFullName = Gatherer.FirstName + " " + Gatherer.LastName;

			Assert.That(result, Is.EqualTo(gathererFullName));
		}

		[Test]

		public async Task All_ShouldReturnCorrectUsersAndPatissiers()
		{
			var result = await applicationUserService.AllAsync();

			var usersCount = repository.AllReadOnly<ApplicationUser>().Count();

			var resultUsers = result.ToList();

			Assert.That(resultUsers.Count(), Is.EqualTo(usersCount));

			var patissiersCount = repository.AllReadOnly<Patissier>().Count();
			var resultPatissiers = resultUsers
				.Where(us => us.MasterChefTitle != null);

			Assert.That(resultPatissiers.Count(), Is.EqualTo(patissiersCount));

			var patissierUser = resultPatissiers
				.FirstOrDefault(pu => pu.Email == Patissier.User.Email);

			Assert.IsNotNull(patissierUser);
			Assert.That(patissierUser.MasterChefTitle, Is.EqualTo(Patissier.MasterChefTitle));
		}

		[Test]

		public async Task All_ShouldReturnCorrectUsersAndFlorists()
		{
			var result = await applicationUserService.AllAsync();

			var usersCount = repository.AllReadOnly<ApplicationUser>().Count();

			var resultUsers = result.ToList();

			Assert.That(resultUsers.Count(), Is.EqualTo(usersCount));

			var floristsCount = repository.AllReadOnly<Florist>().Count();
			var resultFlorists = resultUsers
				.Where(us => us.FlowerMasterTitle != null);

			Assert.That(resultFlorists.Count(), Is.EqualTo(floristsCount));

			var floristUser = resultFlorists
				.FirstOrDefault(fu => fu.Email == Florist.User.Email);

			Assert.IsNotNull(floristUser);
			Assert.That(floristUser.FlowerMasterTitle, Is.EqualTo(Florist.FlowerMasterTitle));
		}
	}
}
