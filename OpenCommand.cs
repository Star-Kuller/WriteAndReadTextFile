namespace WriteAndReadTextFile;

public class OpenCommand : ICommand
{
    public void Run(string path)
    {
        Console.WriteLine($"File {path} has been opened");
        using (File.Open(path, FileMode.OpenOrCreate));
    }
}