namespace WriteAndReadTextFile;

public class RegisterCommand : ICommand
{
    private readonly UserManager _userManager;

    public RegisterCommand(UserManager userManager)
    {
        _userManager = userManager;
    }

    public void Run(string path, string inputString)
    {
        string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _userManager.Register(words[1], words[2]);
    }
}