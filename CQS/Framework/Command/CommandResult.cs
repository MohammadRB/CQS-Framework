namespace CQS.Framework.Command
{
    public abstract class CommandResult : ICommandResult
    {
        public ICommand Command { get; }

        protected CommandResult(ICommand command)
        {
            Command = command;
        }
    }
}