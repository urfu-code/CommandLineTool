using System;
using System.IO;
using Ninject;
using Ninject.Extensions.Conventions;

namespace CommandLineTool
{
    public class Program
    {
        private static ICommandsExecutor CreateExecutor()
        {
            var container = new StandardKernel();

            #region Варианты биндинга CommandExecutor-а
            /*
            container.Bind<ICommandsExecutor>().To<CommandsExecutor>().InSingletonScope();
            */

            /*
            container.Bind<ICommandsExecutor>().To<CommandsExecutor>()
                .InSingletonScope()
                .WithConstructorArgument((TextWriter)new RedTextConsoleWriter());
            */

            /*
            container.Bind<ICommandsExecutor>().To<CommandsExecutor>()
                .InSingletonScope()
                //"При обращении к аргументу конструктора TextWriter присвой пожалуйста следующий тип"
                .WithConstructorArgument(typeof(TextWriter), c => c.Kernel.Get<RedTextConsoleWriter>());
            */

            // /*
            container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
            // */
            #endregion

            #region Варианты биндинга комманд
            /*
            container.Bind<ConsoleCommand>().To<PrintTimeCommand>();
            container.Bind<ConsoleCommand>().To<TimerCommand>();
            container.Bind<ConsoleCommand>().To<HelpCommand>();
            container.Bind<ConsoleCommand>().To<DetailedHelpCommand>();
            */

            // /*
            container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses());
            // */
            #endregion

            #region Варианты биндинга TextWriter-ов
            /*
            //Единый TextWriter
            container.Bind<TextWriter>().ToConstant(Console.Out);
            */

            //TextWriter для консольных команд
            container.Bind<TextWriter>().To<PromptConsoleWriter>()
                .WhenInjectedInto<ConsoleCommand>();

            // /*
            //TextWriter для Executor-а
            container.Bind<TextWriter>().To<RedTextConsoleWriter>()
                .WhenInjectedInto<ICommandsExecutor>();
            // */

            /*
            //Биндинг с использование атрибута Named.
            container.Bind<TextWriter>().To<RedTextConsoleWriter>().Named("error");
            */
            #endregion

            return container.Get<ICommandsExecutor>();
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
                if (line == null || line == "exit") return;
                executor.Execute(line.Split(' '));
            }
        }
    }
}