// [07/21/2016 MRB]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Query;
using CQS.Framework.Repository;

namespace CQS.Framework.DefaultImp
{
    public abstract class EntityConvertQueryBuilder<TContext, TFrom, TTo> :
        QueryBuilder<TContext, EntityConvertQuery<TFrom, TTo>>
        where TContext : class, IAppBoundedContext
        where TFrom : class
        where TTo : class
    {
        public override void Build(TContext appBoundedContext, EntityConvertQuery<TFrom, TTo> query)
        {
            var toObject = Convert(appBoundedContext, query.Object);

            var queryResult = QueryResult<TFrom, TTo>.FromResult(toObject);         

            query.SetResult(queryResult);
        }

        public abstract TTo Convert(TContext appBoundedContext, TFrom entity);
    }
}
