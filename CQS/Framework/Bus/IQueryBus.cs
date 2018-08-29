using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public interface IQueryBus
    {
        TQuery Build<TQuery>(AppDispatcher appDispatcher, TQuery query)
            where TQuery : IQuery;
        Task<TQuery> BuildAsync<TQuery>(AppDispatcher appDispatcher, TQuery query)
            where TQuery : IQuery;
    }
}