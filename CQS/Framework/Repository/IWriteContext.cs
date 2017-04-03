using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.Repository
{
    public interface IWriteContext : IDisposable
    {
        int Save();

        Task<int> SaveAsync();

        //IWriteRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
