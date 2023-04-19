namespace WriteAndReadTextFile;

public class DeleteCommand : ICommand
{
    private readonly IWriter _writer;

    public DeleteCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            _writer.Write($"File {path} has been deleted \nDon't try to add text to a file before opening another file");
        }
        else
        {
            _writer.Write("No file is open");
        }
    }  
}