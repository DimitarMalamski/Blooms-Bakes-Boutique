using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blooms___Bakes_Boutique.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Blooms___Bakes_Boutique.Tests.IntegrationsTests
{
	public class HomeControllerTests
	{
		private HomeController homeController;

		[OneTimeSetUp]

		public void SetUp() => this.homeController = new HomeController(null);

		[Test]

		public void Error_ShouldReturnCorrectView()
		{
			var statusCode = 500;

			var result = this.homeController.Error(statusCode);

			Assert.IsNotNull(result);

			var viewResult = result as ViewResult;
			Assert.IsNotNull(viewResult);
		}
	}
}
