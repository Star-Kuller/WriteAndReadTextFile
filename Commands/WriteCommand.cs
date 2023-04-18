namespace WriteAndReadTextFile;

public class WriteCommand : ICommand
{
    private IWriter _writer;

    public WriteCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine($"{System.Environment.UserName} {DateTime.Now}: {text}");
        }
    }
}