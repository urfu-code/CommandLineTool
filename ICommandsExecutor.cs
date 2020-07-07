namespace CommandLineTool
{
    public interface ICommandsExecutor
    {
        string[] GetAvailableCommandName();
        void Execute(string[] args);
    }
}