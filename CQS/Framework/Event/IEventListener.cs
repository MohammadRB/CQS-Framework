using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Event
{
    public interface IEventListener
    {
        Task HandleAsync(AppDispatcher appDispatcher, IEvent @event);
    }

    public interface IEventListener<in TEvent> : IEventListener
        where TEvent : IEvent
    {
        Task HandleAsync(AppDispatcher appDispatcher, TEvent @event);
    }
}