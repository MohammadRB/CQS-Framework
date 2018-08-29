using CQS.Framework.Event;

namespace CQS.Framework.App
{
    public interface IExternalEventPublisher
    {
        uint PublishEvent< TEvent >(AppDispatcher appDispatcher, TEvent @event) where TEvent : IEvent;
    }
}