namespace WriteAndReadTextFile.Parser;

public sealed class SimpleChainLink : AbsChainLink
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
        string[] words = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (words[0].ToLower() == _commandName)
            return _returnCommand;
        return base.ReturnCommand(inputString);
    }
}