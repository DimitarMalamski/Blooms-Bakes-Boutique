using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.ApplicationUser
{
	public class ApplicationUserServiceModel
	{
		public string Email { get; set; } = null!;
		public string FullName { get; set; } = null!;
		public string MasterChefTitle { get; set; } = null!;
		public string FlowerMasterTitle { get; set; } = null!;

        public bool IsPatissier { get; set; }
        public bool IsFlorist { get; set; }
    }
}
