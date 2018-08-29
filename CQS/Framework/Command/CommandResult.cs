namespace CQS.Framework.Command
{
    public abstract class CommandResult : ICommandResult
    {
        public abstract bool WasSuccessed { get; }

        public ICommand Command { get; }

        protected CommandResult(ICommand command)
        {
            Command = command;
        }
    }
}