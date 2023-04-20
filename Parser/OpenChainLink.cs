namespace WriteAndReadTextFile.Parser;

public sealed class OpenChainLink : AbsChainLink
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
        string[] words = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (words[0].ToLower() == _commandName)
        {
            _consoleHandler.NewPath(words[1]);
            return _returnCommand;
        }
        return base.ReturnCommand(inputString);
    }
}