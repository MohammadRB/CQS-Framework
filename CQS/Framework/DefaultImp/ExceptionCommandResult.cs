using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp
{
    public class ExceptionCommandResult : CommandResult
    {
        public override bool WasSuccessed { get { return false; } }

        public Exception Exception { get { return _exception;; } }

        public ExceptionCommandResult(ICommand command, Exception exception) : base(command)
        {
            _exception = exception;
        }

        private readonly Exception _exception;
    }
}
