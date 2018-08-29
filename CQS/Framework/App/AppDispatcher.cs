using System.Threading.Tasks;
using CQS.Framework.Bus;
using CQS.Framework.Command;
using CQS.Framework.Event;
using CQS.Framework.Query;

namespace CQS.Framework.App
{
    public class AppDispatcher
    {
        public ICommandBus CommandBus { get; }
        public IQueryBus QueryBus { get; }
        public IEventBus EventBus { get; }

        public AppDispatcher(ICommandBus commandBus, IQueryBus queryBus, IEventBus eventBus)
        {
            CommandBus = commandBus;
            QueryBus = queryBus;
            EventBus = eventBus;
        }

        public ICommandResult SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            return CommandBus.Send(this, command);
        }

        public Task<ICommandResult> SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            return CommandBus.SendAsync(this, command);
        }

        public TQuery BuildQuery<TQuery>(TQuery query) where TQuery : IQuery
        {
            return QueryBus.Build(this, query);
        }

        public Task<TQuery> BuildQueryAsync<TQuery>(TQuery query) where TQuery : IQuery
        {
            return QueryBus.BuildAsync(this, query);
        }

        public uint PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return EventBus.Publish(this, @event);
        }

        public Task<uint> PublishEventAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return EventBus.PublishAsync(this, @event);
        }
    }
}