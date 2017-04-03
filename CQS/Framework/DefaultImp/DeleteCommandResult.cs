using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp
{
    public class DeleteCommandResult : CommandResult
    {
        public override bool WasSuccessed { get { return true; } }

        public DeleteCommandResult(ICommand command) : base(command)
        {
        }
    }
}
