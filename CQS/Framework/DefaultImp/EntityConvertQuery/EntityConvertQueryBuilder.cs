// [07/21/2016 MRB]

using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.EntityConvertQuery
{
    public abstract class EntityConvertQueryBuilder<TFrom, TTo> : QueryBuilder<EntityConvertQuery<TFrom, TTo>>
        where TFrom : class
        where TTo : class
    {
        public override Task BuildAsync(AppDispatcher appDispatcher, EntityConvertQuery<TFrom, TTo> query)
        {
            var toObject = ConvertAsync(appDispatcher, query.Object);

            var resultTask = toObject.ContinueWith(t =>
            {
                var result = QueryResult<TTo>.FromResult(t.Result);
                return result;
            });

            return resultTask;
        }

        public abstract Task<TTo> ConvertAsync(AppDispatcher appDispatcher, TFrom entity);
    }
}