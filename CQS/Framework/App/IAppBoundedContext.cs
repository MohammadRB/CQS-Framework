using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Bus;
using CQS.Framework.Command;
using CQS.Framework.Event;
using CQS.Framework.Query;
using CQS.Framework.Repository;

namespace CQS.Framework.App
{
    public interface IAppBoundedContext : IDisposable
    {
        IWriteContext WriteContext { get; }
        IReadContext ReadContext { get; }

        ICommandBus CommandBus { get; }
        IQueryBus QueryBus { get; }
        IEventBus EventBus { get; }

        ICommandResult SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
        Task<ICommandResult> SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
        IDeferedCommandResult SendDeferedCommand<TCommand>(TCommand command) where TCommand : ICommand;
        TQuery BuildQuery<TQuery>(TQuery query) where TQuery : IQuery;
        Task<TQuery> BuildQueryAsync<TQuery>(TQuery query) where TQuery : IQuery;
        uint PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
        uint PublishExternalEvent<TEvent>(TEvent @event) where TEvent : IEvent;
        Task<uint> PublishEventAsync<TEvent>(TEvent @event) where TEvent : IEvent;
        TTo ConvertEntity<TFrom, TTo>(TFrom entity) where TFrom : class where TTo : class;
    }
}
