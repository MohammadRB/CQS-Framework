using System.Collections.Generic;
using System.Linq;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.QueryResult
{
    public class ListQueryResult<TModel> : QueryResult<TModel> where TModel : class
    {
        public ListQueryResult(IList<TModel> result)
        {
            _result = result;
        }

        public override TModel Single()
        {
            return _result.Single();
        }

        public override TModel SingleOrDefault()
        {
            return _result.SingleOrDefault();
        }

        public override List<TModel> ToList()
        {
            return _result.ToList();
        }

        private readonly IList<TModel> _result;
    }
}