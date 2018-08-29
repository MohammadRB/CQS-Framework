namespace CQS.Framework.Command
{
    public interface ICommandResult
    {
        bool WasSuccessed { get; }

        ICommand Command { get; }
    }
}