namespace WriteAndReadTextFile;

public class LoginCommand : ICommand
{
    private readonly UserManager _userManager;
    private readonly IWriter _writer;

    public LoginCommand(UserManager userManager, IWriter wr)
    {
        _userManager = userManager;
        _writer = wr;
    }

    public void Run(string path, string inputString)
    {
        string[] words = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _userManager.Login(Login(words[1], words[2]));
        
    }
    
    private User Login(string name, string password)
    {
        User? findUser = null;
        foreach (var user in _userManager.Users)
        {
            if (user.Name == name)
            {
                findUser = user;
                break;
            }
        }
        if (findUser == null)
        {
            _writer.Write("Error: User is not found");
            return findUser;
        }
        string passwordHash = SHA256HeshGenerator.ComputeSHA256(password);
        if (passwordHash == findUser.PasswordHash)
        {
            return findUser;
        }
        _writer.Write("Error: You shall not pass!!");
        return null;
    }
}