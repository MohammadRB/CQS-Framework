using System;
using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public abstract class QueryBuilder<TQuery> : IQueryBuilder<TQuery>
        where TQuery : class, IQuery
    {
        public void Build(AppDispatcher appDispatcher, IQuery query)
        {
            TQuery targetQuery = query as TQuery;

            if (targetQuery == null)
            {
                throw new InvalidOperationException("Invalid query parameter");
            }

            Build(appDispatcher, targetQuery);
        }

        public abstract void Build(AppDispatcher appDispatcher, TQuery query);
    }
}