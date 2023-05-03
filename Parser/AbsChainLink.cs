namespace WriteAndReadTextFile.Parser;

public abstract class AbsChainLink : IParserChainLink
{
    private IParserChainLink? _nextChainLink;

    public IParserChainLink SetNextChainLink(IParserChainLink chainLink)
    {
        _nextChainLink = chainLink;
        return _nextChainLink;
    }
    
    public virtual ICommand ReturnCommand(string inputString)
    {
        if (_nextChainLink is null)
            return null;
        return _nextChainLink.ReturnCommand(inputString);
    }
}