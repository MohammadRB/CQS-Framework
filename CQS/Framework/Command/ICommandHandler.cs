using CQS.Framework.App;

namespace CQS.Framework.Command
{
    public interface ICommandHandler
    {
        ICommandResult Execute(AppDispatcher appDispatcher, ICommand command);
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler 
        where TCommand : class, ICommand
    {
        ICommandResult Execute(AppDispatcher appDispatcher, TCommand command);
    }
}