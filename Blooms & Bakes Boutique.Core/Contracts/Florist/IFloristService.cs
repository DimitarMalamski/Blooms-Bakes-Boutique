using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Contracts.Florist
{
    public interface IFloristService
    {
        Task<bool> ExistById(string userId);
    }
}
