// [07/21/2016 MRB]

using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp.EntityConvertQuery
{
    public class EntityConvertQuery<TFrom, TTo> : Query<TTo> 
        where TFrom : class 
        where TTo : class
    {
        public TFrom Object { get; private set; }

        public EntityConvertQuery(TFrom @object)
        {
            Object = @object;
        }
    }
}