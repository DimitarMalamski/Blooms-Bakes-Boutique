using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(BloomsAndBakesDbContext _context)
        {
            context = _context;
        }
        public IQueryable<T> All<T>()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AllReadOnly<T>()
        {
            throw new NotImplementedException();
        }
    }
}
