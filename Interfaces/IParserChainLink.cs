namespace WriteAndReadTextFile;

public interface IParserChainLink
{
    public ICommand ReturnCommand(string inputString);
    public IParserChainLink SetNextChainLink(IParserChainLink ChainLink);
}