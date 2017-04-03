namespace CQS.Framework.Command
{
    public class Command : ICommand
    {
        public string Name { get { return _name; } }

        public Command()
        {
            _name = this.GetType().Name;
        }

        public Command(string name)
        {
            _name = name;
        }

        private readonly string _name;
    }
}
