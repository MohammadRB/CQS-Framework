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
            uint numListeners = 0;
            var eventListeners = _serviceLocator.Get<TEvent, IEventListener>()
                .ToList();

            foreach (var eventListener in eventListeners)
            {
                eventListener.Handle(appDispatcher, @event);
                ++numListeners;
            }

            return numListeners;
        }

        public Task<uint> PublishAsync<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent
        {
            return Task.Run(() => Publish(appDispatcher, @event));
        }

        private readonly IServiceLocator _serviceLocator;
    }
}