using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQS.Framework.Command
{
    public abstract class CommandResult : ICommandResult
    {
        public abstract bool WasSuccessed { get; }

        public ICommand Command { get { return _command; } }

        protected CommandResult(ICommand command)
        {
            _command = command;
        }

        private readonly ICommand _command;
    }
}
