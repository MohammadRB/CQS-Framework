using System;
using System.Linq;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public class QueryBus : IQueryBus
    {
        public QueryBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public TQuery Build<TQuery>(AppDispatcher appDispatcher, TQuery query) 
            where TQuery : IQuery
        {
            return Task.Run(() => BuildAsync(appDispatcher, query)).Result;
        }

        public Task<TQuery> BuildAsync<TQuery>(AppDispatcher appDispatcher, TQuery query) 
            where TQuery : IQuery
        {
            IQueryBuilder queryBuilder = _GetQueryBuilder<TQuery>();

            var result = queryBuilder.BuildAsync(appDispatcher, query).ContinueWith(t => query);

            return result;
        }
        
        private IQueryBuilder _GetQueryBuilder<TQuery>() 
            where TQuery : IQuery
        {
            var query = _serviceLocator.Get<TQuery, IQueryBuilder>().FirstOrDefault();
            if (query == null)
            {
                throw new InvalidOperationException("No query builder registered for query");
            }

            return query;
        }

        private readonly IServiceLocator _serviceLocator;
    }
}