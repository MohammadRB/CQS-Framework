using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public interface IQueryBuilder
    {
        void Build(AppDispatcher appDispatcher, IQuery query);
    }

    public interface IQueryBuilder<in TQuery> : IQueryBuilder
        where TQuery : IQuery
    {
        void Build(AppDispatcher appDispatcher, TQuery query);
    }
}