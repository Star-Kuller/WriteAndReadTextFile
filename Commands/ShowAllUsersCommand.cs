using System.Text;

namespace WriteAndReadTextFile;

public class ShowAllUsersCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly UserManager _userManager;

    public ShowAllUsersCommand(UserManager userManager, IWriter writer)
    {
        _userManager = userManager;
        _writer = writer;
    }

    public void Run(string path, string inputString)
    {
        _writer.Write($"Users total: {_userManager.Users.Count}\n" +
                      $"_______________________________________________\n" +
                      $"         User         |         Number         \n" +
                      $"-----------------------------------------------");
        foreach (var user in _userManager.Users)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = user.Name.Length; i < 20; i++)
            {
                sb.Append(' ');
            }
            _writer.Write($"  {user.Name}{sb}|  {user.Number}");
        }
        _writer.Write("______________________|________________________");
    }
}