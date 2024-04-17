using AutoMapper;
using Blooms___Bakes_Boutique.Infrastructure.Data;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Flowers;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.Pastries;
using Blooms___Bakes_Boutique.Infrastructure.Data.Models.User;
using Blooms___Bakes_Boutique.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Tests.UnitTests
{
	public class UnitTestsBase
	{
		protected BloomsAndBakesDbContext _data;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			_data = DatabaseMock.Instanse;
			SeedPastryDb();
			SeedFlowerDb();
		}

		public ApplicationUser Taster { get; private set; }
		public ApplicationUser Gatherer { get; private set; }

		public Patissier Patissier { get; private set; }
        public Florist Florist { get; private set; }

        public Pastry TastedPastry { get; private set; }
        public Flower GatheredFlower { get; set; }

        private void SeedPastryDb()
		{
			Taster = new ApplicationUser()
			{
				Id = "TasterUserId",
				Email = "taster@mail.com",
				FirstName = "Taster",
				LastName = "User"
			};

			_data.Users.Add(Taster);

			Patissier = new Patissier()
			{
				MasterChefTitle = "Master of cakes",
				User = new ApplicationUser()
				{
					Id = "TestUserId",
					Email = "test@mail.com",
					FirstName = "Test",
					LastName = "Tester"
				}
			};

			_data.Patissiers.Add(Patissier);

			TastedPastry = new Pastry()
			{
				Title = "First test pastry",
				Description = "test, 201 test",
				Recipe = "This is a test recipe, this is a test recipe, this is a test recipe.",
				ImageUrl = "https://handletheheat.com/wp-content/uploads/2015/03/Best-Birthday-Cake-with-milk-chocolate-buttercream-SQUARE.jpg",
				Taster = Taster,
				Patissier = Patissier,
				PastryCategory = new PastryCategory() { Name = "Cake" }
			};

			_data.Pastries.Add(TastedPastry);

			var nonTastedPastry = new Pastry()
			{
				Title = "Second test pastry",
				Description = "test, 204 test",
				Recipe = "This is a new test recipe, this is a new test recipe, this is a new test recipe.",
				ImageUrl = "https://www.icecream.com/content/dam/dreyersgrandicecreaminc/us/en/edy%27s/products/classics/Edys-48oz-3D-CnC.png/_jcr_content/renditions/featurecard.png",
				Taster = Taster,
				Patissier = Patissier,
				PastryCategory = new PastryCategory() { Name = "Ice-cream" }
			};

			_data.Pastries.Add(nonTastedPastry);
			_data.SaveChanges();
		}

		private void SeedFlowerDb()
		{
			Gatherer = new ApplicationUser()
			{
				Id = "GathererUserId",
				Email = "gatherer@mail.com",
				FirstName = "Gatherer",
				LastName = "User"
			};

			_data.Users.Add(Gatherer);

			Florist = new Florist()
			{
				FlowerMasterTitle = "Master of flowers",
				User = new ApplicationUser()
				{
					Id = "Gatherer1UserId",
					Email = "gatherer@mail.com",
					FirstName = "Gatherer",
					LastName = "Gatherer"
				}
			};

			_data.Florists.Add(Florist);

			GatheredFlower = new Flower()
			{
				Title = "First test flower",
				Colour = "test red",
				Description = "This is a test Description, this is a test Description, this is a test Description.",
				ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaXKQetmWpHV2k1x7LAO0XDV2OCSRnB47W9rCBWqyhkQ&s",
				Gatherer = Gatherer,
				Florist = Florist,
				FlowerCategory = new FlowerCategory() { Name = "Annual" }
			};

			_data.Flowers.Add(GatheredFlower);

			var nonGatheredFlower = new Flower()
			{
				Title = "Second test flower",
				Colour = "test yellow",
				Description = "This is a test Description, this is a test Description, this is a test Description.",
				ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/49/Iris_germanica_%28Purple_bearded_Iris%29%2C_Wakehurst_Place%2C_UK_-_Diliff.jpg",
				Gatherer = Gatherer,
				Florist = Florist,
				FlowerCategory = new FlowerCategory() { Name = "Perennials" }
			};

			_data.Flowers.Add(nonGatheredFlower);
			_data.SaveChanges();
		}

		[OneTimeTearDown]
		public void TearDownBase() => _data.Dispose();
    }
}
