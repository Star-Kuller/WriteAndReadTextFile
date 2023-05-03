using WriteAndReadTextFile.Parser;

namespace WriteAndReadTextFile;


public class ConsoleHandler : IWriter, IGetUserManager
{
    private readonly ICommand _writeCommand;
   private readonly SimpleChainLink _parserChain;
   private string _cachePath = "test.txt";
   private string _text = "";
   private ICommand? _tempCommand;
   public UserManager UserManager { get; }

   public ConsoleHandler()
   {
       UserManager = new UserManager(this);
       _parserChain = new SimpleChainLink(new CloseCommand(this),"/close");
       SimpleChainLink deleteChainLink = new SimpleChainLink(new DeleteCommand(this),"/delete");
       SimpleChainLink helpChainLink = new SimpleChainLink(new HelpCommand(this),"/help");
       SimpleChainLink readChainLink = new SimpleChainLink(new ReadCommand(this),"/read");
       SimpleChainLink registerChainLink = new SimpleChainLink(new RegisterCommand(UserManager, this),"/register");
       SimpleChainLink loginChainLink = new SimpleChainLink(new LoginCommand(UserManager, this),"/login");
       SimpleChainLink logoutChainLink = new SimpleChainLink(new LogoutCommand(UserManager),"/logout");
       SimpleChainLink setNumberChainLink = new SimpleChainLink(new SetNumberCommand(UserManager, this),"/setnumber");
       SimpleChainLink getNumberChainLink = new SimpleChainLink(new GetNumberCommand(UserManager),"/number");
       OpenChainLink openChainLink = new OpenChainLink(new OpenCommand(this),"/open", this);
       _parserChain.SetNextChainLink(deleteChainLink);
       deleteChainLink.SetNextChainLink(helpChainLink);
       helpChainLink.SetNextChainLink(openChainLink);
       openChainLink.SetNextChainLink(readChainLink);
       readChainLink.SetNextChainLink(registerChainLink);
       registerChainLink.SetNextChainLink(loginChainLink);
       loginChainLink.SetNextChainLink(logoutChainLink);
       logoutChainLink.SetNextChainLink(setNumberChainLink);
       setNumberChainLink.SetNextChainLink(getNumberChainLink);
       
       ICommand openCommand = new OpenCommand(this);
       _writeCommand = new WriteCommand(this, this);
       openCommand.Run(_cachePath, "");
   }

   public void Read()
   {
       string? str = Console.ReadLine();
       if(string.IsNullOrWhiteSpace(str))
           return;
       ICommand? command = Рarse(str);
       if (command is not null) 
           command.Run(_cachePath, _text);
   } 

   public void Write(string s) => Console.WriteLine(s);

   private ICommand Рarse(string inputString)
   {
       _text = inputString;
       if (inputString[0] == '/')
       {
           _tempCommand = _parserChain.ReturnCommand(inputString);
           if (_tempCommand is null)
               Write("Error: unknown command");
           return _tempCommand;
       }
       _tempCommand = _writeCommand;
       return _tempCommand;
   }

   public void NewPath(string path)
   {
       _cachePath = path;
       if (_cachePath[_cachePath.Length-1] == '/')
           _cachePath = _cachePath.Remove(_cachePath.Length - 1);
       _cachePath += "/test.txt";
   }
}