namespace CommandLineTool
{
    public abstract class ConsoleCommand
    {
        protected readonly IServiceLocator locator;
        protected ConsoleCommand(string name, string help, IServiceLocator locator)
        {
            Name = name;
            Help = help;
            this.locator = locator;
        }

        public string Name { get; }
        public string Help { get; }
        public abstract void Execute(string[] args);
    }
}