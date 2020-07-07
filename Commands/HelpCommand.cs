using System.IO;

namespace CommandLineTool
{
    public class HelpCommand : ConsoleCommand
    {
        public HelpCommand(IServiceLocator locator)
            : base("h", "h      # prints available commands list", locator)
        { }

        public override void Execute(string[] args)
        {
            var writer = locator.Get<TextWriter>();
            writer.WriteLine("Available commands: " + string.Join(", ", locator.Get<ICommandsExecutor>().GetAvailableCommandName()));
        }
    }
}