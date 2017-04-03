using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.DefaultImp;

namespace CQS.Framework.Query
{
    public abstract class Query<TEntity, TModel> : IQuery<TEntity, TModel> 
        where TEntity : class 
        where TModel : class
    {
        public void SetResult(object @object)
        {
            SetResult((TEntity) @object);
        }

        void IQuery.SetResult(IQueryResult queryResult)
        {
            SetResult((IQueryResult<TEntity, TModel>) queryResult);
        }

        IQueryResult IQuery.GetResult()
        {
            return GetResult();
        }

        // Set empty or null result
        public void SetResult()
        {
            Result = QueryResult<TEntity, TModel>.FromEmptyResult();
        }

        // Set single result
        public void SetResult(TModel @object)
        {
            Result = QueryResult<TEntity, TModel>.FromResult(@object);
        }

        // Set query result
        public void SetResult(IQueryResult<TEntity, TModel> queryResult)
        {
            Result = queryResult;
        }

        public IQueryResult<TEntity, TModel> GetResult()
        {
            return Result;
        }


        protected IQueryResult<TEntity, TModel> Result;
    }
}
