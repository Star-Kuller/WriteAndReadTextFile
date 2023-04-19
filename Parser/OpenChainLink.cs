namespace WriteAndReadTextFile.Parser;

public class OpenChainLink : AbsChainLink
{
    private readonly ICommand _returnCommand;
    private readonly string _commandName;
    private readonly ConsoleHandler _consoleHandler;


    public OpenChainLink(ICommand returnCommand, string commandName, ConsoleHandler consoleHandler)
    {
        _returnCommand = returnCommand;
        _commandName = commandName;
        _consoleHandler = consoleHandler;
    }

    public override ICommand ReturnCommand(string inputString)
    { 
        string inputCommand = "";
        string tempPath = "";
        foreach (char c in inputString)
        {
            if(c == ' ') break;
            inputCommand += c;
        }
        for (int i = inputCommand.Length+1; i < inputString.Length; i++)
        {
            tempPath += inputString[i];
        }
        if (inputCommand.ToLower() == _commandName)
        {
            _consoleHandler.NewPath(tempPath);
            return _returnCommand;
        }
        return base.ReturnCommand(inputString);
    }
}