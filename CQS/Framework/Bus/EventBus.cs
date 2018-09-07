using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public class EventBus : IEventBus
    {
        public EventBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public uint Publish<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent
        {
            return Task.Run(() => PublishAsync(appDispatcher, @event)).Result;
        }

        public Task<uint> PublishAsync<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent
        {
            uint numListeners = 0;
            var eventListeners = _serviceLocator.Get<TEvent, IEventListener>()
                .ToList();
            var tasks = new List<Task>(eventListeners.Count);

            foreach (var eventListener in eventListeners)
            {
                tasks.Add(eventListener.HandleAsync(appDispatcher, @event));
                ++numListeners;
            }

            return Task.WhenAll(tasks).ContinueWith(t => numListeners);
        }

        private readonly IServiceLocator _serviceLocator;
    }
}