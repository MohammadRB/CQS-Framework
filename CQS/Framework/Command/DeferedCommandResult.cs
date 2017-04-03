using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.App;

namespace CQS.Framework.Command
{
    public class DeferedCommandResult : IDeferedCommandResult
    {
        public DeferedCommandResult(ICommandHandler handler, IAppBoundedContext boundedContext, ICommand command)
        {
            _handler = handler;
            _boundedContext = boundedContext;
            _command = command;
        }

        public ICommandResult Execute()
        {
            return _handler.Execute(_boundedContext, _command);
        }

        private readonly IAppBoundedContext _boundedContext;
        private readonly ICommandHandler _handler;
        private readonly ICommand _command;
    }
}
