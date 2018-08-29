using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Command;

namespace CQS.Framework.Bus
{
    public interface ICommandBus
    {
        ICommandResult Send<TCommand>(AppDispatcher appDispatcher, TCommand command)
            where TCommand : ICommand;

        Task<ICommandResult> SendAsync<TCommand>(AppDispatcher appDispatcher, TCommand command)
            where TCommand : ICommand;
    }
}