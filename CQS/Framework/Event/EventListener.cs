using System;
using CQS.Framework.App;

namespace CQS.Framework.Event
{
    public abstract class EventListener<TBoundedContext, TEvent> : IEventListener<TBoundedContext, TEvent>
        where TBoundedContext : class, IAppBoundedContext
        where TEvent : class, IEvent
    {
        public void Handle(IAppBoundedContext appBoundedContext, IEvent @event)
        {
            TBoundedContext targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetEvent = @event as TEvent;

            if (targetEvent == null)
            {
                throw new InvalidOperationException("Invalid event parameter");
            }

            Handle(targetContext, targetEvent);
        }

        public abstract void Handle(TBoundedContext appContext, TEvent @event);
    }
}