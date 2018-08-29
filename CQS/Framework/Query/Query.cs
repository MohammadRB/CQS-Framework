namespace CQS.Framework.Query
{
    public abstract class Query<TModel> : IQuery<TModel> 
        where TModel : class
    {
        public void SetResult(object @object)
        {
            SetResult((TModel) @object);
        }

        void IQuery.SetResult(IQueryResult queryResult)
        {
            SetResult((IQueryResult<TModel>) queryResult);
        }

        IQueryResult IQuery.GetResult()
        {
            return GetResult();
        }

        // Set empty or null result
        public void SetResult()
        {
            Result = QueryResult<TModel>.FromEmptyResult();
        }

        // Set single result
        public void SetResult(TModel @object)
        {
            Result = QueryResult<TModel>.FromResult(@object);
        }

        // Set query result
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
