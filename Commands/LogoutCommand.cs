namespace WriteAndReadTextFile;

public class LogoutCommand : ICommand
{
    private readonly UserManager _userManager;

    public LogoutCommand(UserManager userManager)
    {
        _userManager = userManager;
    }

    public void Run(string path, string inputString)
    {
        _userManager.Logout();
    }
}