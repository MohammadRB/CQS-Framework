namespace CQS.Framework.Command
{
    public class Command : ICommand
    {
        public string Name { get; }

        public Command()
        {
            Name = this.GetType().Name;
        }

        public Command(string name)
        {
            Name = name;
        }
    }
}