using System;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Event
{
    public abstract class EventListener<TEvent> : IEventListener<TEvent>
        where TEvent : class, IEvent
    {
        public Task HandleAsync(AppDispatcher appDispatcher, IEvent @event)
        {
            if (!(@event is TEvent targetEvent))
            {
                throw new InvalidOperationException("Invalid event parameter");
            }

            return HandleAsync(appDispatcher, targetEvent);
        }

        public abstract Task HandleAsync(AppDispatcher appDispatcher, TEvent @event);
    }
}