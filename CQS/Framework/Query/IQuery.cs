using System.Linq;

namespace CQS.Framework.Query
{
    public interface IQuery
    {
        void SetResult(object @object);
        void SetResult(IQueryable queryable);
        void SetResult(IQueryResult queryResult);
        IQueryResult GetResult();
    }

    public interface IQuery<TModel> : IQuery
        where TModel : class
    {
        void SetResult(TModel @object);
        void SetResult(IQueryable<TModel> queryable);
        void SetResult(IQueryResult<TModel> queryResult);
        new IQueryResult<TModel> GetResult();
    }
}