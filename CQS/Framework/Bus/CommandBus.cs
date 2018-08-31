using System;
using System.Linq;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Command;
using CQS.Framework.DefaultImp.CommandResult;

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
            ICommandResult result = null;
            ICommandHandler handler = _GetHandler<TCommand>();

            try
            {
                result = handler.Execute(appDispatcher, command);
            }
            catch (Exception ex)
            {
                result = new ExceptionCommandResult(command, ex);
            }
            
            return result;
        }

        public Task<ICommandResult> SendAsync<TCommand>(AppDispatcher appDispatcher, TCommand command)
            where TCommand : ICommand
        {
            return Task.Run(() => Send(appDispatcher, command));
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