using System;
using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class ExceptionCommandResult : Command.CommandResult
    {
        public override bool WasSuccessed => false;

        public Exception Exception => _exception;

        public ExceptionCommandResult(ICommand command, Exception exception) : base(command)
        {
            _exception = exception;
        }

        private readonly Exception _exception;
    }
}