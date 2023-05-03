using System.Security.Cryptography;

namespace WriteAndReadTextFile;

public class UserManager
{
    public readonly List<User> Users = new List<User>();
    private readonly IWriter _writer;

    public UserManager(IWriter writer)
    {
        _writer = writer;
    }

    public User? CurrentUser { get; private set; }

    public void Logout()
    {
        CurrentUser = null;
    }

    public void Login(string name, string password)
    {
        User? findUser = null;
        foreach (var user in Users)
        {
            if (user.Name == name)
            {
                findUser = user;
                break;
            }
        }
        if (findUser == null)
        {
            _writer.Write("Error: User unfinded");
            return;
        }
        int passwordHash = password.GetHashCode();
        if (passwordHash == findUser.PasswordHash)
        {
            CurrentUser = findUser;
            return;
        }
        _writer.Write("Error: You should not pass!!");
    }

    public void Register(string name, string password)
    {
        Users.Add(new User(name, password.GetHashCode()));
        _writer.Write("User has be created");
    }

    public void SetPhoneNumber(string number)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Name == CurrentUser.Name)
            {
                CurrentUser.Number = number;
                Users[i].Number = number;
            }
        }
    }
}