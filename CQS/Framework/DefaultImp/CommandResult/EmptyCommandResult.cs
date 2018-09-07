using System;
using System.Collections.Generic;
using System.Text;
using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class EmptyCommandResult : Command.CommandResult
    {
        public EmptyCommandResult(ICommand command) : base(command)
        {
        }
    }
}
