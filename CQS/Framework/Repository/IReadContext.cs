using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.Repository
{
    public interface IReadContext : IDisposable
    {
        //IReadRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
