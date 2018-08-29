using System;
using CQS.Framework.App;

namespace CQS.Framework.Command
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : class, ICommand
    {
        public virtual ICommandResult Execute(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand targetCommand)
            {
                return Execute(appDispatcher, targetCommand);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public abstract ICommandResult Execute(AppDispatcher appDispatcher, TCommand command);
    }

    public abstract class CommandHandler<TCommand1, TCommand2>
        : CommandHandler<TCommand1>,
        ICommandHandler<TCommand2>
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand
    {
        public override ICommandResult Execute(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand1 targetCommand1)
            {
                return Execute(appDispatcher, targetCommand1);
            }

            if (command is TCommand2 targetCommand2)
            {
                return Execute(appDispatcher, targetCommand2);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }
        
        public abstract ICommandResult Execute(AppDispatcher appDispatcher, TCommand2 command);
    }

    public abstract class CommandHandler<TCommand1, TCommand2, TCommand3>
        : CommandHandler<TCommand1, TCommand2>,
        ICommandHandler<TCommand3>
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand 
        where TCommand3 : class, ICommand
    {
        public override ICommandResult Execute(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand1 targetCommand1)
            {
                return Execute(appDispatcher, targetCommand1);
            }

            if (command is TCommand2 targetCommand2)
            {
                return Execute(appDispatcher, targetCommand2);
            }

            if (command is TCommand3 targetCommand3)
            {
                return Execute(appDispatcher, targetCommand3);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }
        
        public abstract ICommandResult Execute(AppDispatcher appDispatcher, TCommand3 command);
    }

    public abstract class CommandHandler<TCommand1, TCommand2, TCommand3, TCommand4>
        : CommandHandler<TCommand1, TCommand2, TCommand3>,
        ICommandHandler<TCommand4>
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand
        where TCommand3 : class, ICommand
        where TCommand4 : class, ICommand
    {
        public override ICommandResult Execute(AppDispatcher appDispatcher, ICommand command)
        {
            if (command is TCommand1 targetCommand1)
            {
                return Execute(appDispatcher, targetCommand1);
            }

            if (command is TCommand2 targetCommand2)
            {
                return Execute(appDispatcher, targetCommand2);
            }

            if (command is TCommand3 targetCommand3)
            {
                return Execute(appDispatcher, targetCommand3);
            }

            if (command is TCommand4 targetCommand4)
            {
                return Execute(appDispatcher, targetCommand4);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }
        
        public abstract ICommandResult Execute(AppDispatcher appDispatcher, TCommand4 command);
    }
}