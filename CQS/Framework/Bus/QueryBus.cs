using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public class QueryBus : IQueryBus
    {
        public QueryBus(Dictionary<Type, IQueryBuilder> queryBuilders)
        {
            var queryType = typeof(IQuery);

            foreach (var queryBuilder in queryBuilders)
            {
                if (!queryType.IsAssignableFrom(queryBuilder.Key))
                {
                    throw new InvalidOperationException("Invalid event type");
                }
            }

            _queries = queryBuilders;
        }

        public TQuery Build<TQuery>(AppDispatcher appDispatcher, TQuery query) where TQuery : IQuery
        {
            IQueryBuilder queryBuilder = _GetQueryBuilder<TQuery>();

            queryBuilder.Build(appDispatcher, query);

            return query;
        }

        public Task<TQuery> BuildAsync<TQuery>(AppDispatcher appDispatcher, TQuery query) where TQuery : IQuery
        {
            return Task.Run(() => Build(appDispatcher, query));
        }
        
        private IQueryBuilder _GetQueryBuilder<TQuery>() where TQuery : IQuery
        {
            IQueryBuilder query;

            if (!_queries.TryGetValue(typeof(TQuery), out query))
            {
                throw new InvalidOperationException("No query builder registered for query");
            }

            return query;
        }

        private readonly Dictionary<Type, IQueryBuilder> _queries;
    }
}