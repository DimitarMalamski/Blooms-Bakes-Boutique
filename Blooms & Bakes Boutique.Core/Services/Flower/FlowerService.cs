using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Core.Services.Flower
{
    public class FlowerService : IFlowerService
    {
        private readonly IRepository repository;

        public FlowerService(IRepository _repository)
        {
            repository = _repository;
        }
    }
}
