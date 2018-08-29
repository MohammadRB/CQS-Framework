using CQS.Framework.App;

namespace CQS.Framework.Event
{
    public interface IEventListener
    {
        void Handle(AppDispatcher appDispatcher, IEvent @event);
    }

    public interface IEventListener<in TEvent> : IEventListener
        where TEvent : class, IEvent
    {
        void Handle(AppDispatcher appDispatcher, TEvent @event);
    }
}