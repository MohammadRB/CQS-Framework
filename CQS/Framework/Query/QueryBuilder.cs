using System;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public abstract class QueryBuilder<TQuery> : IQueryBuilder<TQuery>
        where TQuery : class, IQuery
    {
        public Task BuildAsync(AppDispatcher appDispatcher, IQuery query)
        {
            TQuery targetQuery = query as TQuery;

            if (targetQuery == null)
            {
                throw new InvalidOperationException("Invalid query parameter");
            }

            return BuildAsync(appDispatcher, targetQuery);
        }

        public abstract Task BuildAsync(AppDispatcher appDispatcher, TQuery query);
    }
}