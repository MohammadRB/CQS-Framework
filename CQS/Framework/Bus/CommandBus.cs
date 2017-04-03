using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Bus;
using CQS.Framework.Command;
using CQS.Framework.DefaultImp;

namespace CQS.Framework.Bus
{
    public class CommandBus : ICommandBus
    {
        public CommandBus(Dictionary<Type, ICommandHandler> commandHandlers)
        {
            var commandType = typeof(ICommand);

            foreach (var commandHandler in commandHandlers)
            {
                if (!commandType.IsAssignableFrom(commandHandler.Key))
                {
                    throw new InvalidOperationException("Invalid command type");
                }
            }

            _commandHandlers = commandHandlers;
        }

        public ICommandResult Send<TBoundedContext, TCommand>(TBoundedContext appBoundedContext, TCommand command)
            where TBoundedContext : IAppBoundedContext
            where TCommand : ICommand
        {
            ICommandResult result = null;
            ICommandHandler handler = _GetHandler<TCommand>();

            try
            {
                result = handler.Execute(appBoundedContext, command);
            }
            catch (Exception ex)
            {
                result = new ExceptionCommandResult(command, ex);
            }
            
            return result;
        }

        public Task<ICommandResult> SendAsync<TBoundedContext, TCommand>(TBoundedContext appBoundedContext, TCommand command)
            where TBoundedContext : IAppBoundedContext
            where TCommand : ICommand
        {
            return Task.Run(() => Send(appBoundedContext, command));
        }

        public IDeferedCommandResult SendDeferred<TBoundedContext, TCommand>(TBoundedContext appBoundedContext, TCommand command)
            where TBoundedContext : IAppBoundedContext
            where TCommand : ICommand
        {
            ICommandHandler handler = _GetHandler<TCommand>();

            return handler.DeferredExecute(appBoundedContext, command);
        }

        private ICommandHandler _GetHandler<TCommand>() where TCommand : ICommand
        {
            ICommandHandler handler;

            if (!_commandHandlers.TryGetValue(typeof(TCommand), out handler))
            {
                throw new InvalidOperationException("No handler registered for command");
            }

            return handler;
        }

        private readonly Dictionary<Type, ICommandHandler> _commandHandlers;
    }
}
