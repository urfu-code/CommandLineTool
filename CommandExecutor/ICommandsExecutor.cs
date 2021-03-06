﻿namespace CommandLineTool
{
    public interface ICommandsExecutor
    {
        ConsoleCommand FindCommandByName(string name);
        string[] GetAvailableCommandName();
        void Execute(string[] args);
    }
}