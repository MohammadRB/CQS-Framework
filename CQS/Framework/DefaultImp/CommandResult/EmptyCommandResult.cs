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
