using System;
using System.IO;

namespace CommandLineTool
{
    public class PrintTimeCommand : ConsoleCommand
    {
        private readonly TextWriter writer;

        public PrintTimeCommand(TextWriter writer) 
            : base("printtime", "printtime      # prints current time")
        {
            this.writer = writer;
        }

        public override void Execute(string[] args)
        {
            writer.WriteLine(DateTime.Now);
        }
    }
}