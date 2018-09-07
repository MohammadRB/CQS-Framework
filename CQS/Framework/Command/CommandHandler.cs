using System;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Command
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : class, ICommand
    {
        public virtual Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand targetCommand)
            {
                return ExecuteAsync(appDispatcher, targetCommand);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public abstract Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, TCommand command);
    }

    public abstract class CommandHandler<TCommand1, TCommand2>
        : CommandHandler<TCommand1>,
        ICommandHandler<TCommand2>
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand
    {
        public override Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand1 targetCommand1)
            {
                return ExecuteAsync(appDispatcher, targetCommand1);
            }

            if (command is TCommand2 targetCommand2)
            {
                return ExecuteAsync(appDispatcher, targetCommand2);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }
        
        public abstract Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, TCommand2 command);
    }

    public abstract class CommandHandler<TCommand1, TCommand2, TCommand3>
        : CommandHandler<TCommand1, TCommand2>,
        ICommandHandler<TCommand3>
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand 
        where TCommand3 : class, ICommand
    {
        public override Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand1 targetCommand1)
            {
                return ExecuteAsync(appDispatcher, targetCommand1);
            }

            if (command is TCommand2 targetCommand2)
            {
                return ExecuteAsync(appDispatcher, targetCommand2);
            }

            if (command is TCommand3 targetCommand3)
            {
                return ExecuteAsync(appDispatcher, targetCommand3);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }
        
        public abstract Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, TCommand3 command);
    }

    public abstract class CommandHandler<TCommand1, TCommand2, TCommand3, TCommand4>
        : CommandHandler<TCommand1, TCommand2, TCommand3>,
        ICommandHandler<TCommand4>
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand
        where TCommand3 : class, ICommand
        where TCommand4 : class, ICommand
    {
        public override Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand1 targetCommand1)
            {
                return ExecuteAsync(appDispatcher, targetCommand1);
            }

            if (command is TCommand2 targetCommand2)
            {
                return ExecuteAsync(appDispatcher, targetCommand2);
            }

            if (command is TCommand3 targetCommand3)
            {
                return ExecuteAsync(appDispatcher, targetCommand3);
            }

            if (command is TCommand4 targetCommand4)
            {
                return ExecuteAsync(appDispatcher, targetCommand4);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }
        
        public abstract Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, TCommand4 command);
    }
}