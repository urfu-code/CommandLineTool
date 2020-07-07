using System;
using System.IO;

namespace CommandLineTool
{
    public class PrintTimeCommand : ConsoleCommand
    {
        public PrintTimeCommand(IServiceLocator locator)
            : base("printtime", "printtime      # prints current time", locator)
        { }

        public override void Execute(string[] args)
        {
            locator.Get<TextWriter>().WriteLine(DateTime.Now);
        }
    }
}