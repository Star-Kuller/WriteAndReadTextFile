namespace WriteAndReadTextFile;

public class User
{
    public string Name { get; }
    public string? Number { get; set; }
    public string PasswordHash { get; }

    public User(string name, string passwordHash)
    {
        Name = name;
        PasswordHash = passwordHash;
    }
}