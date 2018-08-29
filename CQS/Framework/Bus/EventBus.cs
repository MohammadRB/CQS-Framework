using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public class EventBus : IEventBus
    {
        public static EventBus Instance { get; set; }

        public EventBus(Dictionary<Type, List<IEventListener>> eventListeners)
        {
            var eventType = typeof(IEvent);

            foreach (var eventListener in eventListeners)
            {
                if (!eventType.IsAssignableFrom(eventListener.Key))
                {
                    throw new InvalidOperationException("Invalid event type");
                }
            }

            _eventHandlers = eventListeners;
        }

        public uint Publish<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent
        {
            uint numListeners = 0;
            List<IEventListener> eventListeners;

            if (_eventHandlers.TryGetValue(typeof (TEvent), out eventListeners))
            {
                foreach (var eventListener in eventListeners)
                {
                    eventListener.Handle(appDispatcher, @event);

                    ++numListeners;
                }
            }

            return numListeners;
        }

        public Task<uint> PublishAsync<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent
        {
            return Task.Run(() => Publish(appDispatcher, @event));
        }

        private readonly Dictionary<Type, List<IEventListener>> _eventHandlers;
    }
}