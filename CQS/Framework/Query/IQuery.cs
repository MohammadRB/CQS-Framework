using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CQS.Framework.Query
{
    public interface IQuery
    {
        void SetResult(Object @object);
        void SetResult(List<Object> list);
        void SetResult(IQueryable queryable);
        void SetResult(IQueryResult queryResult);
        IQueryResult GetResult();
    }

    public interface IQuery<TModel> : IQuery
        where TModel : class
    {
        void SetResult(TModel @object);
        void SetResult(List<TModel> list);
        void SetResult(IQueryable<TModel> queryable);
        void SetResult(IQueryResult<TModel> queryResult);
        new IQueryResult<TModel> GetResult();
    }
}