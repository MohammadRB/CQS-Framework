using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public interface IQueryBuilder
    {
        Task BuildAsync(AppDispatcher appDispatcher, IQuery query);
    }

    public interface IQueryBuilder<in TQuery> : IQueryBuilder
        where TQuery : IQuery
    {
        Task BuildAsync(AppDispatcher appDispatcher, TQuery query);
    }
}