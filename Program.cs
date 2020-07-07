using System;

namespace CommandLineTool
{
    public class Program
    {
        private static ICommandsExecutor CreateExecutor()
        {
            // Регистрация сервисов в локаторе.
            // Заметьте, как почти все сервисы зависят от локатора, 
            // скрывая от программиста настоящие зависимости, которые ранее были видны.
            var locator = new ServiceLocator();
            locator.Register(Console.Out);
            locator.Register<ConsoleCommand>(new PrintTimeCommand(locator));
            locator.Register<ConsoleCommand>(new TimerCommand(locator));
            locator.Register<ConsoleCommand>(new HelpCommand(locator));
            locator.Register<ConsoleCommand>(new DetailedHelpCommand(locator));
            locator.Register<ICommandsExecutor>(new CommandsExecutor(locator));
            return locator.Get<ICommandsExecutor>();
        }

        static void Main(string[] args)
        {
            ICommandsExecutor executor = CreateExecutor();
            if (args.Length > 0)
                executor.Execute(args);
            else
                RunInteractiveMode(executor);
        }

        public static void RunInteractiveMode(ICommandsExecutor executor)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (line == null || line == "exit") 
                    return;
                executor.Execute(line.Split(' '));
            }
        }
    }
}