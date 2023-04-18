namespace WriteAndReadTextFile;

public class OpenCommand : ICommand
{
    private readonly IWriter _writer;

    public OpenCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        bool file = File.Exists(path);
        using (File.Open(path, FileMode.OpenOrCreate));
        if (file)
        {
            _writer.Write($"File {path} has been opened");
        }
        else
        {
            _writer.Write($"File {path} has been created and opened");
        }
    }  
}