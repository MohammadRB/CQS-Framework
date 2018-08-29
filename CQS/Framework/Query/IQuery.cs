namespace CQS.Framework.Query
{
    public interface IQuery
    {
        void SetResult(object @object);
        void SetResult(IQueryResult queryResult);
        IQueryResult GetResult();
    }

    public interface IQuery<TModel> : IQuery
        where TModel : class
    {
        void SetResult(TModel @object);
        void SetResult(IQueryResult<TModel> queryResult);
        IQueryResult<TModel> GetResult();
    }
}