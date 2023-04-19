namespace WriteAndReadTextFile;

public interface IParserChainLink
{
    ICommand ReturnCommand(string inputString);
    IParserChainLink SetNextChainLink(IParserChainLink ChainLink);
}