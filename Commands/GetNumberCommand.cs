namespace WriteAndReadTextFile;

public class GetNumberCommand : ICommand
{
    private readonly UserManager _userManager;

    public GetNumberCommand(UserManager userManager)
    {
        _userManager = userManager;
    }

    public void Run(string path, string inputString)
    {
        _userManager.GetPhoneNumber();
    }
}