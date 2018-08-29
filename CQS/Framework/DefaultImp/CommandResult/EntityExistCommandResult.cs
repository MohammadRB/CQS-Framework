using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class EntityExistCommandResult : Command.CommandResult
    {
        public override bool WasSuccessed => false;

        public EntityExistCommandResult(ICommand command) : base(command)
        {

        }
    }
}