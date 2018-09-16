using System.Collections.Generic;

namespace CQS.Framework.Query
{
    public interface IQueryResult
    {
        object Single();

        object SingleOrDefault();

        List<object> ToList();
    }

    public interface IQueryResult<TModel> : IQueryResult
        where TModel : class
    {
        new TModel Single();

        new TModel SingleOrDefault();

        new List<TModel> ToList();
    }
}