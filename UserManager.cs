using System.Text.Json;

namespace WriteAndReadTextFile;

public class UserManager
{
    public List<User> Users { get; private set; }
    private readonly IWriter _writer;
    
    public UserManager(IWriter writer)
    {
        _writer = writer;
        Load();
    }
    
    ~UserManager()
    {
        Save();
    }

    public User? CurrentUser { get; private set; }

    public void Logout()
    {
        if(CurrentUser is null)
            return;
        _writer.Write($"Bye, {CurrentUser.Name}!");
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
        Users.Add(new User(name, SHA256HeshGenerator.ComputeSHA256(password)));
        _writer.Write("User has be created");
        Login(Users[Users.Count-1]);
        Save();
    }

    public void SetPhoneNumber(string number)
    {
        if (CurrentUser is null)
        {
            _writer.Write("You are not authorized");
            return;
        }
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Name == CurrentUser.Name)
            {
                CurrentUser.Number = number;
                Users[i].Number = number;
                _writer.Write($"Number \"{number}\" has been added to account {CurrentUser.Name}");
                return;
            }
        }
        Save();
    }
    
    public void GetPhoneNumber()
    {
        if (CurrentUser is null)
        {
            _writer.Write("You are not authorized");
            return;
        }
        if (string.IsNullOrWhiteSpace(CurrentUser.Number))
        {
            _writer.Write($"{CurrentUser.Name} does not have a number");
            return;
        }
        _writer.Write($"{CurrentUser.Name} has a number {CurrentUser.Number}");
    }

    public void Delete()
    {
        if (CurrentUser is null)
        {
            _writer.Write("You are not authorized");
            return;
        }
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Name == CurrentUser.Name)
            {
                Users.Remove(Users[i]);
                _writer.Write($"User \"{CurrentUser.Name}\" deleted");
                CurrentUser = null;
                Save();
                return;
            }
        }
    }

    private async void Save()
    {
        using (FileStream fs = new FileStream("users.json", FileMode.Create))
        {
            await JsonSerializer.SerializeAsync(fs, Users);
        }
    }
    
    private async void Load()
    {
        using (FileStream fs = new FileStream("users.json", FileMode.OpenOrCreate))
        {
            try
            {
                Users = await JsonSerializer.DeserializeAsync<List<User>>(fs);
            }
            catch
            {
                // ignored
            }
            if(Users is null)
                Users = new List<User>();
        }
    }
}