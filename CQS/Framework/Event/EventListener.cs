using System;
using CQS.Framework.App;

namespace CQS.Framework.Event
{
    public abstract class EventListener<TEvent> : IEventListener<TEvent>
        where TEvent : class, IEvent
    {
        public void Handle(AppDispatcher appDispatcher, IEvent @event)
        {
            if (!(@event is TEvent targetEvent))
            {
                throw new InvalidOperationException("Invalid event parameter");
            }

            Handle(appDispatcher, targetEvent);
        }

        public abstract void Handle(AppDispatcher appDispatcher, TEvent @event);
    }
}