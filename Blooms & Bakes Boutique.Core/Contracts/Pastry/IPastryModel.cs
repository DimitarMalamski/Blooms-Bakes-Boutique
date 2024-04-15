using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Contracts.Pastry
{
	public interface IPastryModel
	{
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
