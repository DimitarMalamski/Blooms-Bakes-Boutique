using Blooms___Bakes_Boutique.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Tests.Mocks
{
	public static class DatabaseMock
	{
		public static BloomsAndBakesDbContext Instanse
		{
			get
			{
				var DbContextOptions = new DbContextOptionsBuilder<BloomsAndBakesDbContext>()
					.UseInMemoryDatabase("BloomsAndBakesInMemoryDb"
						+ DateTime.Now.Ticks.ToString())
				.Options;

				return new BloomsAndBakesDbContext(DbContextOptions, false);
			}
		}
    }
}
