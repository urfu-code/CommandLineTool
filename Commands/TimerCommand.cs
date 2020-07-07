using System;
using System.IO;
using System.Threading;

namespace CommandLineTool
{
    public class TimerCommand : ConsoleCommand
    {
        public TimerCommand() : base("timer", "timer <ms>      # starts timer for <ms> milliseconds") 
        { }

        public override void Execute(string[] args, TextWriter writer)
        {
            if (args.Length != 2)
            {
                writer.WriteLine("Error!");
                return;
            }
            var timeout = TimeSpan.FromMilliseconds(int.Parse(args[1]));
            writer.WriteLine("Waiting for " + timeout);
            Thread.Sleep(timeout);
            writer.WriteLine("Done!");
        }
    }
}