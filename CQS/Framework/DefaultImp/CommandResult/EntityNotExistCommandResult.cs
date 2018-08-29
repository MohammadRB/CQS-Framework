using CQS.Framework.Command;

namespace CQS.Framework.DefaultImp.CommandResult
{
    public class EntityNotExistCommandResult : Command.CommandResult
    {
        public override bool WasSuccessed => false;

        public EntityNotExistCommandResult(ICommand command) : base(command)
        {
        }
    }
}