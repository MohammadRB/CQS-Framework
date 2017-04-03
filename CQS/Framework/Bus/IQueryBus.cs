using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Query;

namespace CQS.Framework.Bus
{
    public interface IQueryBus
    {
        TQuery Build<TBoundedContext, TQuery>(TBoundedContext appBoundedContext, TQuery query)
            where TBoundedContext : IAppBoundedContext
            where TQuery : IQuery;
        Task<TQuery> BuildAsync<TBoundedContext, TQuery>(TBoundedContext appBoundedContext, TQuery query)
            where TBoundedContext : IAppBoundedContext
            where TQuery : IQuery;
    }
}