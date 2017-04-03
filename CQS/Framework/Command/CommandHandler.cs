using System;
using CQS.Framework.App;
using CQS.Framework.DefaultImp;

namespace CQS.Framework.Command
{
    public abstract class CommandHandler<TBoundedContext, TCommand> : ICommandHandler<TBoundedContext, TCommand>
        where TBoundedContext : class, IAppBoundedContext
        where TCommand : class, ICommand
    {
        public virtual IDeferedCommandResult DeferredExecute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand = command as TCommand;

            if (targetCommand != null)
            {
                return DeferredExecute(targetContext, targetCommand);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public virtual ICommandResult Execute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand = command as TCommand;

            if (targetCommand != null)
            {
                return Execute(targetContext, targetCommand);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public virtual IDeferedCommandResult DeferredExecute(TBoundedContext appBoundedContext, TCommand command)
        {
            var result = new DeferedCommandResult(this, appBoundedContext, command);

            return result;
        }

        public abstract ICommandResult Execute(TBoundedContext appBoundedContext, TCommand command);
    }

    public abstract class CommandHandler<TBoundedContext, TCommand1, TCommand2>
        : CommandHandler<TBoundedContext, TCommand1>,
        ICommandHandler<TBoundedContext, TCommand2>
        where TBoundedContext : class, IAppBoundedContext
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand
    {
        public override IDeferedCommandResult DeferredExecute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand1 = command as TCommand1;

            if (targetCommand1 != null)
            {
                return DeferredExecute(targetContext, targetCommand1);
            }

            var targetCommand2 = command as TCommand2;

            if (targetCommand2 != null)
            {
                return DeferredExecute(targetContext, targetCommand2);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public override ICommandResult Execute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand1 = command as TCommand1;

            if (targetCommand1 != null)
            {
                return Execute(targetContext, targetCommand1);
            }

            var targetCommand2 = command as TCommand2;

            if (targetCommand2 != null)
            {
                return Execute(targetContext, targetCommand2);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public IDeferedCommandResult DeferredExecute(TBoundedContext appBoundedContext, TCommand2 command)
        {
            var result = new DeferedCommandResult(this, appBoundedContext, command);

            return result;
        }

        public abstract ICommandResult Execute(TBoundedContext appBoundedContext, TCommand2 command);
    }

    public abstract class CommandHandler<TBoundedContext, TCommand1, TCommand2, TCommand3>
        : CommandHandler<TBoundedContext, TCommand1, TCommand2>,
        ICommandHandler<TBoundedContext, TCommand3>
        where TBoundedContext : class, IAppBoundedContext
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand 
        where TCommand3 : class, ICommand
    {
        public override IDeferedCommandResult DeferredExecute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand1 = command as TCommand1;

            if (targetCommand1 != null)
            {
                return DeferredExecute(targetContext, targetCommand1);
            }

            var targetCommand2 = command as TCommand2;

            if (targetCommand2 != null)
            {
                return DeferredExecute(targetContext, targetCommand2);
            }

            var targetCommand3 = command as TCommand3;

            if (targetCommand3 != null)
            {
                return DeferredExecute(targetContext, targetCommand3);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public override ICommandResult Execute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            TBoundedContext targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand1 = command as TCommand1;

            if (targetCommand1 != null)
            {
                return Execute(targetContext, targetCommand1);
            }

            var targetCommand2 = command as TCommand2;

            if (targetCommand2 != null)
            {
                return Execute(targetContext, targetCommand2);
            }

            var targetCommand3 = command as TCommand3;

            if (targetCommand3 != null)
            {
                return Execute(targetContext, targetCommand3);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public IDeferedCommandResult DeferredExecute(TBoundedContext appBoundedContext, TCommand3 command)
        {
            DeferedCommandResult result = new DeferedCommandResult(this, appBoundedContext, command);

            return result;
        }

        public abstract ICommandResult Execute(TBoundedContext appBoundedContext, TCommand3 command);
    }

    public abstract class CommandHandler<TBoundedContext, TCommand1, TCommand2, TCommand3, TCommand4>
        : CommandHandler<TBoundedContext, TCommand1, TCommand2, TCommand3>,
        ICommandHandler<TBoundedContext, TCommand4>
        where TBoundedContext : class, IAppBoundedContext
        where TCommand1 : class, ICommand
        where TCommand2 : class, ICommand
        where TCommand3 : class, ICommand
        where TCommand4 : class, ICommand
    {
        public override IDeferedCommandResult DeferredExecute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand1 = command as TCommand1;

            if (targetCommand1 != null)
            {
                return DeferredExecute(targetContext, targetCommand1);
            }

            var targetCommand2 = command as TCommand2;

            if (targetCommand2 != null)
            {
                return DeferredExecute(targetContext, targetCommand2);
            }

            var targetCommand3 = command as TCommand3;

            if (targetCommand3 != null)
            {
                return DeferredExecute(targetContext, targetCommand3);
            }

            var targetCommand4 = command as TCommand4;

            if (targetCommand4 != null)
            {
                return DeferredExecute(targetContext, targetCommand4);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public override ICommandResult Execute(IAppBoundedContext appBoundedContext, ICommand command)
        {
            var targetContext = appBoundedContext as TBoundedContext;

            if (targetContext == null)
            {
                throw new InvalidOperationException("Invalid context parameter");
            }

            var targetCommand1 = command as TCommand1;

            if (targetCommand1 != null)
            {
                return Execute(targetContext, targetCommand1);
            }

            var targetCommand2 = command as TCommand2;

            if (targetCommand2 != null)
            {
                return Execute(targetContext, targetCommand2);
            }

            var targetCommand3 = command as TCommand3;

            if (targetCommand3 != null)
            {
                return Execute(targetContext, targetCommand3);
            }

            var targetCommand4 = command as TCommand4;

            if (targetCommand4 != null)
            {
                return Execute(targetContext, targetCommand4);
            }

            throw new InvalidOperationException("Invalid command parameter");
        }

        public IDeferedCommandResult DeferredExecute(TBoundedContext appBoundedContext, TCommand4 command)
        {
            var result = new DeferedCommandResult(this, appBoundedContext, command);

            return result;
        }

        public abstract ICommandResult Execute(TBoundedContext appBoundedContext, TCommand4 command);
    }
}