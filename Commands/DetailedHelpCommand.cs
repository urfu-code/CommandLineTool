using System;
using System.IO;

namespace CommandLineTool
{
    public class DetailedHelpCommand : ConsoleCommand
    {
        private readonly Func<string, ConsoleCommand> findCommand;

        public DetailedHelpCommand(Func<string, ConsoleCommand> findCommand)
            : base("help", "help <command>      # prints help for <command>")
        {
            this.findCommand = findCommand;
        }

        public override void Execute(string[] args, TextWriter writer)
        {
            var cmd = findCommand(args[1]);
            if (cmd == null)
                writer.WriteLine("Sorry. Unknown command {0}", args[1]);
            else
                writer.WriteLine(cmd.Help);
        }
    }
}