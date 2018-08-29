using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class DeleteCommandResult : Command.CommandResult
    {
        public override bool WasSuccessed => true;

        public DeleteCommandResult(ICommand command) : base(command)
        {
        }
    }
}