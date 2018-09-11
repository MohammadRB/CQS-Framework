using System.Collections.Generic;

namespace CQS.Framework.App
{
    public interface IServiceLocator
    {
        IEnumerable<TTyp> Get<TTyp>();
    }
}