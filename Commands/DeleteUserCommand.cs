namespace WriteAndReadTextFile;

public class DeleteUserCommand : ICommand
{
    private readonly UserManager _userManager;

    public DeleteUserCommand(UserManager userManager)
    {
        _userManager = userManager;
    }

    public void Run(string path, string inputString)
    {
        _userManager.Delete();
    }
}