using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Models.Actions
{
	public class TasteServiceModel
	{
		public string PastryTitle { get; set; } = string.Empty;
		public string PastryImageUrl { get; set; } = string.Empty;
		public string PatissierFullName { get; set; } = string.Empty;
		public string PatissierEmail { get; set; } = string.Empty;
		public string TasterFullName { get; set; } = string.Empty;
        public string TasterEmail { get; set; } = string.Empty;
    }
}
