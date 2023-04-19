using System.Diagnostics;
using WriteAndReadTextFile.Parser;

namespace WriteAndReadTextFile;


public class ConsoleHandler : IWriter
{
    private readonly ICommand _writeCommand;
   private readonly SimpleChainLink _parserChain;
   private string _cachePath = "C://MyProjects/WriteAndReadTextFile/test.txt";
   private string _text = "";
   private ICommand? _tempCommand = null;

   public ConsoleHandler(string cachePath)
   {
       if (!string.IsNullOrWhiteSpace(cachePath))
       {
           this._cachePath = cachePath;
           if (cachePath[cachePath.Length-1] == '/')
           {
               _cachePath += "test.txt";
           }
           else
           {
               _cachePath += "/test.txt";
           }
       }
       _parserChain = new SimpleChainLink(new CloseCommand(this),"/close");
       SimpleChainLink deleteChainLink = new SimpleChainLink(new DeleteCommand(this),"/delete");
       SimpleChainLink helpChainLink = new SimpleChainLink(new HelpCommand(this),"/help");
       SimpleChainLink readChainLink = new SimpleChainLink(new ReadCommand(this),"/read");
       OpenChainLink openChainLink = new OpenChainLink(new OpenCommand(this),"/open", this);
       _parserChain.SetNextChainLink(deleteChainLink);
       deleteChainLink.SetNextChainLink(helpChainLink);
       helpChainLink.SetNextChainLink(openChainLink);
       openChainLink.SetNextChainLink(readChainLink);
       
       ICommand openCommand = new OpenCommand(this);
       _writeCommand = new WriteCommand(this);
       openCommand.Run(_cachePath, "");
   }

   public void Read()
   {
       Рarse(Console.ReadLine()).Run(_cachePath, _text);
   } 

   public void Write(string s) => Console.WriteLine(s);

   private ICommand Рarse(string inputString)
   {
       if (inputString[0] == '/')
       {
           _tempCommand = _parserChain.ReturnCommand(inputString);
           if (_tempCommand == null)
           {
               Write("Error: Unknown command");
               throw new ArgumentException();
           }
       }
       else
       {
           _tempCommand = _writeCommand;
           _text = inputString;
       }
       return _tempCommand;
   }

   public void NewPath(string path)
   {
       _cachePath = path;
       if (_cachePath[_cachePath.Length-1] == '/')
       {
           _cachePath += "test.txt";
       }
       else
       {
           _cachePath += "/test.txt";
       }
   }
}