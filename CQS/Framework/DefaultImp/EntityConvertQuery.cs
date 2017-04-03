// [07/21/2016 MRB]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Query;

namespace CQS.Framework.DefaultImp
{
    public class EntityConvertQuery<TFrom, TTo> : Query<TFrom, TTo> 
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
