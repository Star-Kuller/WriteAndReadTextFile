namespace WriteAndReadTextFile;

public class SetNumberCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly UserManager _userManager;

    public SetNumberCommand(UserManager userManager, IWriter writer)
    {
        _userManager = userManager;
        _writer = writer;
    }

    public void Run(string path, string inputString)
    {
        string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < 2)
        {
            _writer.Write("Error: Invalid number of arguments");
            return;
        }
        _userManager.SetPhoneNumber(words[1]);
    }
}