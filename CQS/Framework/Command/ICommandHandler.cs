using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Command
{
    public interface ICommandHandler
    {
        IDeferedCommandResult DeferredExecute(IAppBoundedContext appBoundedContext, ICommand command);
        ICommandResult Execute(IAppBoundedContext appBoundedContext, ICommand command);
    }

    public interface ICommandHandler<in TBoundedContext, in TCommand> : ICommandHandler 
        where TBoundedContext : class, IAppBoundedContext
        where TCommand : class, ICommand
    {
        IDeferedCommandResult DeferredExecute(TBoundedContext appBoundedContext, TCommand command);
        ICommandResult Execute(TBoundedContext appBoundedContext, TCommand command);
    }
}