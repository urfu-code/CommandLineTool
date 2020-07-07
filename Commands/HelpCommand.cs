using System.IO;

namespace CommandLineTool
{
    internal class HelpCommand : ConsoleCommand
    {
        private readonly ICommandsExecutor executor;

        //Также можно еще из конструктора получать делегат и использовать его для получения команд.
        //private readonly Func<string[]> getAvailableCommands;

        public HelpCommand(ICommandsExecutor executor)
            : base("h", "h      # prints available commands list")
        {
            this.executor = executor;
        }

        public override void Execute(string[] args, TextWriter writer)
        {
            writer.WriteLine("Available commands: " + string.Join(", ", executor.GetAvailableCommandName()));
        }
    }
}