using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.Repository
{
    public interface IReadRepository<out TEntity>
    {
        IQueryable<TEntity> All();
    }
}
