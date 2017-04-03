using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Query
{
    public interface IQuery
    {
        void SetResult(object @object);
        void SetResult(IQueryResult queryResult);
        IQueryResult GetResult();
    }

    public interface IQuery<TEntity, TModel> : IQuery
        where TEntity : class 
        where TModel : class
    {
        void SetResult(TModel @object);
        void SetResult(IQueryResult<TEntity, TModel> queryResult);
        IQueryResult<TEntity, TModel> GetResult();
    }
}
