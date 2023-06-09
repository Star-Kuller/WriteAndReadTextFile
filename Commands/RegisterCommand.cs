namespace WriteAndReadTextFile;

public class RegisterCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly UserManager _userManager;

    public RegisterCommand(UserManager userManager, IWriter writer)
    {
        _userManager = userManager;
        _writer = writer;
    }

    public void Run(string path, string inputString)
    {
        string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var user in _userManager.Users)
        {
            if (user.Name == words[1])
            {
                _writer.Write("This user already exists");
                return;
            }
        }

        if (words.Length < 3)
        {
            _writer.Write("Error: Invalid number of arguments");
            return;
        }
        _userManager.Register(words[1], words[2]);
    }
}