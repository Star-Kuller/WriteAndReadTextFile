namespace WriteAndReadTextFile;

public class User
{
    public string Name { get; }
    public string? Number { get; set; }
    public int PasswordHash { get; }

    public User(string name, int passwordHash)
    {
        Name = name;
        PasswordHash = passwordHash;
    }
}