namespace WriteAndReadTextFile;

public class ConsoleHandler : IWriter
{
   private string _path = "C://MyProjects/WriteAndReadTextFile/test.txt";
   private ICommand _openCommand = new OpenCommand();
   
   public ConsoleHandler(string path)
   {
       if (!string.IsNullOrWhiteSpace(path))
       {
           this._path = path;
           if (path[path.Length-1] == '/')
           {
               _path += "test.txt";
           }
           else
           {
               _path += "/test.txt";
           }
       }
       _openCommand.Run(_path);
   }

   public void Read() => Рarse(Console.ReadLine() ?? throw new InvalidOperationException());

   public void Write(string s) => Console.WriteLine(s);

   private ICommand Рarse(string str)
   {
    //TODO  
    return null;
   }
}