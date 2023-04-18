using System.Diagnostics;

namespace WriteAndReadTextFile;


public class ConsoleHandler : IWriter
{
   private string _path = "C://MyProjects/WriteAndReadTextFile/test.txt";
   private string _tempString = "";
   private string _text = "";
   private ICommand _tempCommand;
   private ICommand _openCommand;
   private ICommand _closeCommand;
   private ICommand _writeCommand;
   private ICommand _readCommand;
   private ICommand _helpCommand;
   private ICommand _deleteCommand;

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
       _openCommand = new OpenCommand(this);
       _closeCommand = new CloseCommand(this);
       _writeCommand = new WriteCommand(this);
       _readCommand = new ReadCommand(this);
       _helpCommand = new HelpCommand(this);
       _deleteCommand = new DeleteCommand(this);
       _openCommand.Run(_path, "");
   }

   public void Read()
   {
       Рarse(Console.ReadLine()).Run(_path, _text);
   } 

   public void Write(string s) => Console.WriteLine(s);

   private ICommand Рarse(string str)
   {
       if (str[0] == '/')
       {
           foreach (char c in str)
           {
               if (c == ' ') break;
               _tempString += c;
           }
           switch (_tempString.ToLower())
           {
               case "/open":
                   _path = "";
                   for (int i = _tempString.Length+1; i < str.Length; i++)
                   {
                       _path += str[i];
                   }
                   if (_path[_path.Length-1] == '/')
                   {
                       _path += "test.txt";
                   }
                   else
                   {
                       _path += "/test.txt";
                   }
                   _tempCommand = _openCommand;
                   break;
               case "/close":
                   _tempCommand = _closeCommand;
                   break;
               case "/read":
                   _tempCommand = _readCommand;
                   break;
               case "/help":
                   _tempCommand = _helpCommand;
                   break;
               case "/delete":
                   _tempCommand = _deleteCommand;
                   break;
               default:
                   Write("Error: Unknown command");
                   throw new ArgumentException();
                   break;
           }
       }
       else
       {
           _tempCommand = _writeCommand;
           _text = str;
       }
       _tempString = "";
       return _tempCommand;
   }
   
   
}