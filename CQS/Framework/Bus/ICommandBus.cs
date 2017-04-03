using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;
using CQS.Framework.Command;

namespace CQS.Framework.Bus
{
    public interface ICommandBus
    {
        ICommandResult Send<TBoundedContext, TCommand>(TBoundedContext appBoundedContext, TCommand command)
            where TBoundedContext : IAppBoundedContext
            where TCommand : ICommand;

        Task<ICommandResult> SendAsync<TBoundedContext, TCommand>(TBoundedContext appBoundedContext, TCommand command)
            where TBoundedContext : IAppBoundedContext
            where TCommand : ICommand;

        IDeferedCommandResult SendDeferred<TBoundedContext, TCommand>(TBoundedContext appBoundedContext, TCommand command)
            where TBoundedContext : IAppBoundedContext
            where TCommand : ICommand;
    }
}