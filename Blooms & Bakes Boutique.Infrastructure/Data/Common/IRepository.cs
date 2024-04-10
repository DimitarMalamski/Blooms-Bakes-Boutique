using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blooms___Bakes_Boutique.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>();

        IQueryable<T> AllReadOnly<T>();
    }
}
