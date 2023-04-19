namespace WriteAndReadTextFile.Parser;

public class SimpleChainLink : AbsChainLink
{
    private readonly ICommand _returnCommand;
    private readonly string _commandName;

    public SimpleChainLink(ICommand returnCommand, string commandName)
    {
        _returnCommand = returnCommand;
        _commandName = commandName;
    }

    public override ICommand ReturnCommand(string inputString)
    {
        if (inputString.ToLower() == _commandName)
            return _returnCommand;
        return base.ReturnCommand(inputString);
    }
}