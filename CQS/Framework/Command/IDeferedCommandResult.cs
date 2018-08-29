namespace CQS.Framework.Command
{
    public interface IDeferedCommandResult
    {
        ICommandResult Execute();
    }
}