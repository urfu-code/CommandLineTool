using System.IO;

namespace CommandLineTool
{
    public class DetailedHelpCommand : ConsoleCommand
    {
        public DetailedHelpCommand(IServiceLocator locator)
            : base("help", "help <command>      # prints help for <command>", locator)
        { }

        public override void Execute(string[] args)
        {
            var commandName = args[1];
            var command = locator.Get<ICommandsExecutor>().FindCommandByName(commandName);
            var writer = locator.Get<TextWriter>();
            if (command == null)
                writer.WriteLine("Not a command " + commandName);
            else
                writer.WriteLine(command.Help);
        }
    }
}