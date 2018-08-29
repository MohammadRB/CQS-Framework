using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class UpdateCommandResult : Command.CommandResult
    {
        public override bool WasSuccessed { get { return true; } }

        public UpdateCommandResult(ICommand command) : base(command)
        {
        }
    }
}