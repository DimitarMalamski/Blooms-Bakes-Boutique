using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Services.Pastry
{
    public class PastryService : IPastryService
    {
        private readonly IRepository repository;

        public PastryService(IRepository _repository)
        {
            repository = _repository;
        }
    }
}
