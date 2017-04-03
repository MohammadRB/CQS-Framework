using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Bus;
using CQS.Framework.Command;
using CQS.Framework.DefaultImp;
using CQS.Framework.Event;
using CQS.Framework.Query;
using CQS.Framework.Repository;

namespace CQS.Framework.App
{
    public abstract class AppBoundedContext<TReadContext, TWriteContext> : IAppBoundedContext
        where TReadContext : IReadContext
        where TWriteContext : IWriteContext
    {
        IReadContext IAppBoundedContext.ReadContext { get { return ReadContext; } }

        IWriteContext IAppBoundedContext.WriteContext { get { return WriteContext; } }

        public abstract TReadContext ReadContext { get; }

        public abstract TWriteContext WriteContext { get; }

        public ICommandBus CommandBus { get { return _commandBus; } }

        public IQueryBus QueryBus { get{ return _queryBus; } }

        public IEventBus EventBus { get { return _eventBus; } }

        protected AppBoundedContext(ICommandBus commandBus, IQueryBus queryBus, IEventBus eventBus, IExternalEventPublisher externalEventPublisher)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _eventBus = eventBus;
            _externalEventPublisher = externalEventPublisher;
        }

        public ICommandResult SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            return CommandBus.Send(this, command);
        }

        public Task<ICommandResult> SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            return CommandBus.SendAsync(this, command);
        }

        public IDeferedCommandResult SendDeferedCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            return CommandBus.SendDeferred(this, command);
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

        public uint PublishExternalEvent< TEvent >(TEvent @event) where TEvent : IEvent
        {
            return _externalEventPublisher.PublishEvent(this, @event);
        }

        public Task<uint> PublishEventAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return EventBus.PublishAsync(this, @event);
        }

        public TTo ConvertEntity< TFrom, TTo >(TFrom entity) where TFrom : class where TTo : class
        {
            return BuildQuery(new EntityConvertQuery< TFrom, TTo >(entity)).GetResult().Single();
        }

        public abstract void Dispose();

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IEventBus _eventBus;
        private readonly IExternalEventPublisher _externalEventPublisher;
    }
}
