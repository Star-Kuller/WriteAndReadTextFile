namespace WriteAndReadTextFile;

public interface IParserChainLink
{
    public ICommand ReturnCommand(string inputString);
    IParserChainLink SetNextChainLink(IParserChainLink ChainLink);
}