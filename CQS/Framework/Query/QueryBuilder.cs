using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public abstract class QueryBuilder<TBoundedContext, TQuery> : IQueryBuilder<TBoundedContext, TQuery>
        where TBoundedContext : class, IAppBoundedContext
        where TQuery : class, IQuery
    {
        public void Build(IAppBoundedContext appBoundedContext, IQuery query)
        {
            TBoundedContext targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            TQuery targetQuery = query as TQuery;

            if (targetQuery == null)
            {
                throw new InvalidOperationException("Invalid query parameter");
            }

            Build(targetContext, targetQuery);
        }

        public abstract void Build(TBoundedContext appBoundedContext, TQuery query);
    }
}
