using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Event
{
    public interface IEventListener
    {
        void Handle(IAppBoundedContext appBoundedContext, IEvent @event);
    }

    public interface IEventListener<in TBoundedContext, in TEvent> : IEventListener 
        where TBoundedContext : class, IAppBoundedContext
        where TEvent : class, IEvent
    {
        void Handle(TBoundedContext appBoundedContext, TEvent @event);
    }
}