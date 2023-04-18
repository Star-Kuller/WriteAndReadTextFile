using System.Diagnostics;

namespace WriteAndReadTextFile;

public class CloseCommand : ICommand
{
    private IWriter _writer;

    public CloseCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        _writer.Write($"Program closed");
        Process.GetCurrentProcess().Kill();;
    }
}