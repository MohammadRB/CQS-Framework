// [07/21/2016 MRB]

using System;
using System.Collections.Generic;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.QueryResult
{
    public class FromResultQueryResult<TModel> : QueryResult<TModel>
        where TModel : class
    {
        public TModel Object { get; private set; }

        public FromResultQueryResult(TModel @object)
        {
            Object = @object;
        }

        public override TModel Single()
        {
            if (Object == null)
            {
                throw new InvalidOperationException();
            }

            return Object;
        }

        public override TModel SingleOrDefault()
        {
            return Object;
        }

        public override List<TModel> ToList()
        {
            return new List<TModel>()
            {
                Object
            };
        }
    }
}