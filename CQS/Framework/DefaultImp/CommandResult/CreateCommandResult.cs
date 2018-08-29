using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class CreateCommandResult : Command.CommandResult
    {
        public override bool WasSuccessed => true;

        public CreateCommandResult(ICommand command) : base(command)
        {
        }
    }
}