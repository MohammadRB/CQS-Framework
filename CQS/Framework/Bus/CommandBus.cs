using System;
using System.Linq;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Command;

namespace CQS.Framework.Bus
{
    public class CommandBus : ICommandBus
    {
        public CommandBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public ICommandResult Send<TCommand>(AppDispatcher appDispatcher, TCommand command)
            where TCommand : ICommand
        {
            return Task.Run(() => SendAsync(appDispatcher, command)).Result;
        }

        public Task<ICommandResult> SendAsync<TCommand>(AppDispatcher appDispatcher, TCommand command)
            where TCommand : ICommand
        {
            Task<ICommandResult> result = null;
            ICommandHandler handler = _GetHandler<TCommand>();

            result = handler.ExecuteAsync(appDispatcher, command);

            return result;
        }

        private ICommandHandler _GetHandler<TCommand>() where TCommand : ICommand
        {
            var handler = _serviceLocator.Get<TCommand, ICommandHandler>().FirstOrDefault();
            if (handler == null)
            {
                throw new InvalidOperationException("No handler registered for command");
            }

            return handler;
        }

        private readonly IServiceLocator _serviceLocator;
    }
}