using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp
{
    public class EntityNotExistCommandResult : CommandResult
    {
        public override bool WasSuccessed { get { return false; } }

        public EntityNotExistCommandResult(ICommand command) : base(command)
        {
        }
    }
}
