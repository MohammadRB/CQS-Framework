using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CQS.Framework.DefaultImp.QueryResult;

namespace CQS.Framework.Query
{
    public abstract class QueryResult<TModel> : IQueryResult<TModel>
        where TModel : class
    {
        object IQueryResult.Single()
        {
            return Single();
        }

        object IQueryResult.SingleOrDefault()
        {
            return SingleOrDefault();
        }

        List<object> IQueryResult.ToList()
        {
            return ToList().Cast<object>().ToList();
        }

        public abstract TModel Single();

        public abstract TModel SingleOrDefault();

        public abstract List<TModel> ToList();

        public static QueryableQueryResult<TModel> FromQueryable(IQueryable<TModel> query)
        {
            return new QueryableQueryResult<TModel>(query);
        }

        public static ListQueryResult<TModel> FromList(IList<TModel> list)
        {
            return new ListQueryResult<TModel>(list);
        }
        
        public static FromResultQueryResult<TModel> FromResult(TModel @object)
        {
            return new FromResultQueryResult<TModel>(@object);
        }

        public static FromResultQueryResult<TModel> FromEmptyResult()
        {
            return new FromResultQueryResult<TModel>(null);
        }
    }
}