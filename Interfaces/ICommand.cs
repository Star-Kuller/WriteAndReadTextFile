namespace WriteAndReadTextFile;

public interface ICommand
{ 
    public void Run(string path, string text);
}