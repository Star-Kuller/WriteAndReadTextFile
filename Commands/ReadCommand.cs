namespace WriteAndReadTextFile;

public class ReadCommand : ICommand
{
    private readonly IWriter _writer;

    public ReadCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    _writer.Write(s);
                }
            }
        }
        else
        {
            _writer.Write("No file is open");
        }
    }
}