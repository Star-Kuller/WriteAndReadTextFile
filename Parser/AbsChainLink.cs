namespace WriteAndReadTextFile.Parser;

public abstract class AbsChainLink : IParserChainLink
{
    private IParserChainLink _nextChainLink;

    public IParserChainLink SetNextChainLink(IParserChainLink ChainLink)
    {
        _nextChainLink = ChainLink;
        return _nextChainLink;
    }
    
    public virtual ICommand ReturnCommand(string inputString)
    {
        if (_nextChainLink != null)
            return _nextChainLink.ReturnCommand(inputString);
        return null;
    }
}