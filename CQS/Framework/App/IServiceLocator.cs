using System.Collections.Generic;

namespace CQS.Framework.App
{
    public interface IServiceLocator
    {
        IEnumerable<TConcrete> Get<TType, TConcrete>();
    }
}