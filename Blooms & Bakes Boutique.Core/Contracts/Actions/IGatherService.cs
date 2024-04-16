using Blooms___Bakes_Boutique.Core.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Contracts.Actions
{
	public interface IGatherService
	{
		Task<IEnumerable<GatherServiceModel>> AllAsync();
	}
}
