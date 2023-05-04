namespace WriteAndReadTextFile;

public class HelpCommand : ICommand
{
    private readonly IWriter _writer;

    public HelpCommand(IWriter wr)
    {
        _writer = wr;
    }
    public void Run(string path, string text)
    {
        string[] helpText =
        { 
            "_______________________________________________",
            "/help - Show a list of commands", 
            "/open <path> - Open or create a file \"test.txt\"", 
            "/close - Close this program", 
            "/read - Read all lines from an open file", 
            "/delete - Delete an opened file", 
            "/register <AccountName> <Password> - Register new account", 
            "/login <AccountName> <Password> - Sign in", 
            "/SetNumber <Number> - Add number for current account", 
            "/number - Show number for current account", 
            "/users - Show users list", 
            "/DeleteMyAccount - Delete current account",
            "_______________________________________________"
        };
        foreach (string s in helpText)
        {
            _writer.Write(s);
        }
    }
}