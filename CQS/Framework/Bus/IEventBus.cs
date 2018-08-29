using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Event;

namespace CQS.Framework.Bus
{
    public interface IEventBus
    {
        uint Publish<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent;

        Task<uint> PublishAsync<TEvent>(AppDispatcher appDispatcher, TEvent @event)
            where TEvent : IEvent;
    }
}