using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Command
{
    public interface ICommandHandler
    {
        Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, ICommand command);
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler 
        where TCommand : class, ICommand
    {
        Task<ICommandResult> ExecuteAsync(AppDispatcher appDispatcher, TCommand command);
    }
}