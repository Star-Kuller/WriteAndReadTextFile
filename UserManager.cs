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

    public void Login(User? user)
    {
        if(user is null)
            return;
        _writer.Write($"Welcome, {user.Name}!");
        CurrentUser = user;
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