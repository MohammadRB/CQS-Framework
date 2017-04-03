using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Command;
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

        public TQuery Build<TQuery>(IAppBoundedContext appBoundedContext, TQuery query) where TQuery : IQuery
        {
            IQueryBuilder queryBuilder = _GetQueryBuilder<TQuery>();

            queryBuilder.Build(appBoundedContext, query);

            return query;
        }

        public Task<TQuery> BuildAsync<TQuery>(IAppBoundedContext appBoundedContext, TQuery query) where TQuery : IQuery
        {
            return Task.Run(() => Build(appBoundedContext, query));
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