using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public interface IQueryBuilder
    {
        void Build(IAppBoundedContext appBoundedContext, IQuery query);
    }

    public interface IQueryBuilder<in TBoundedContext, in TQuery> : IQueryBuilder 
        where TBoundedContext : IAppBoundedContext
        where TQuery : IQuery
    {
        void Build(TBoundedContext appBoundedContext, TQuery query);
    }
}