using System.Linq;

namespace CQS.Framework.Query
{
    public abstract class Query<TModel> : IQuery<TModel> 
        where TModel : class
    {
        public void SetResult(object @object)
        {
            SetResult((TModel) @object);
        }

        public void SetResult(IQueryable queryable)
        {
            SetResult((IQueryable<TModel>)queryable);
        }

        void IQuery.SetResult(IQueryResult queryResult)
        {
            SetResult((IQueryResult<TModel>) queryResult);
        }

        IQueryResult IQuery.GetResult()
        {
            return GetResult();
        }

        /// <summary>
        /// Set empty or null result
        /// </summary>
        public void SetResult()
        {
            Result = QueryResult<TModel>.FromEmptyResult();
        }

        /// <summary>
        /// Set single result
        /// </summary>
        /// <param name="object"></param>
        public void SetResult(TModel @object)
        {
            Result = QueryResult<TModel>.FromResult(@object);
        }

        /// <summary>
        /// Set queryable result
        /// </summary>
        /// <param name="queryable"></param>
        public void SetResult(IQueryable<TModel> queryable)
        {
            Result = QueryResult<TModel>.FromQueryable(queryable);
        }

        /// <summary>
        /// Set query result
        /// </summary>
        /// <param name="queryResult"></param>
        public void SetResult(IQueryResult<TModel> queryResult)
        {
            Result = queryResult;
        }

        public IQueryResult<TModel> GetResult()
        {
            return Result;
        }
        
        protected IQueryResult<TModel> Result;
    }
}