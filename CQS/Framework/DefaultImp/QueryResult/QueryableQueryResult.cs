// [07/22/2016 MRB]

using System.Collections.Generic;
using System.Linq;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.QueryResult
{
    public class QueryableQueryResult<TModel> : QueryResult<TModel>
        where TModel : class
    {
        public QueryableQueryResult(IQueryable<TModel> query)
        {
            _currentQuery = query;
        }
        
        public override TModel Single()
        {
            var model = _currentQuery.Single();
            return model;
        }

        public override TModel SingleOrDefault()
        {
            var model = _currentQuery.FirstOrDefault();
            return model;
        }

        public override List<TModel> ToList()
        {
            return _currentQuery.ToList();
        }

        private readonly IQueryable<TModel> _currentQuery;
    }
}