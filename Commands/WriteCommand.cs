namespace WriteAndReadTextFile;

public class WriteCommand : ICommand
{
    private readonly IWriter _writer;

    public WriteCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        if (File.Exists(path))
        {
            using (StreamWriter writer = new StreamWriter(path, true)) 
            {
                writer.WriteLine($"{System.Environment.UserName} {DateTime.Now}: {text}"); 
            }
        }
        else
        {
            _writer.Write("No file is open");
        }
    }
}