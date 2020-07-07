using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommandLineTool
{
    /// <summary>
    /// Знает про полный список команд и умеет выполнять их.
    /// </summary>
    public class CommandsExecutor : ICommandsExecutor
    {
        private readonly List<ConsoleCommand> commands = new List<ConsoleCommand>();
        private readonly IServiceLocator locator;

        public CommandsExecutor(IServiceLocator locator)
        {
            this.locator = locator;
            RegisterAllCommands();
        }

        private void RegisterAllCommands()
        {
            foreach (var command in locator.GetAll<ConsoleCommand>())
            {
                commands.Add(command);
            }
        }

        public string[] GetAvailableCommandName()
        {
            return commands.Select(c => c.Name).ToArray();
        }

        public ConsoleCommand FindCommandByName(string name)
        {
            return commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public void Execute(string[] args)
        {
            if (args[0].Length == 0)
            {
                Console.WriteLine("Please specify <command> as the first command line argument");
                return;
            }
            var writer = locator.Get<TextWriter>();
            var commandName = args[0];
            var cmd = FindCommandByName(commandName);
            if (cmd == null)
                writer.WriteLine("Sorry. Unknown command {0}", commandName);
            else
                cmd.Execute(args);
        }
    }
}