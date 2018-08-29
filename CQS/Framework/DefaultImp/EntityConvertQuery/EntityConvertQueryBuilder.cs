// [07/21/2016 MRB]

using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.EntityConvertQuery
{
    public abstract class EntityConvertQueryBuilder<TFrom, TTo> : QueryBuilder<EntityConvertQuery<TFrom, TTo>>
        where TFrom : class
        where TTo : class
    {
        public override void Build(AppDispatcher appDispatcher, EntityConvertQuery<TFrom, TTo> query)
        {
            var toObject = Convert(appDispatcher, query.Object);

            var queryResult = QueryResult<TTo>.FromResult(toObject);         

            query.SetResult(queryResult);
        }

        public abstract TTo Convert(AppDispatcher appDispatcher, TFrom entity);
    }
}