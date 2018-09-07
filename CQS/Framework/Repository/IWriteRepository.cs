using System;
using System.Threading.Tasks;
using CQS.Framework.Domain;

namespace CQS.Framework.Repository
{
    public interface IWriteRepository<TAroot> : IDisposable where TAroot : IAggregateRoot
    {
        Task<TAroot> Find(Object id);
    }
}