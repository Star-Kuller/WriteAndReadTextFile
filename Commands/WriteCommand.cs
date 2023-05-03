namespace WriteAndReadTextFile;

public class WriteCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly IGetUserManager _getUserManager;

    public WriteCommand(IWriter wr, IGetUserManager getUserManager)
    {
        _writer = wr;
        _getUserManager = getUserManager;
    }
    public void Run(string path, string text)
    {
        try
        {
            if (File.Exists(path))
            {
                if(_getUserManager.UserManager.CurrentUser is not null)
                {
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine($"{_getUserManager.UserManager.CurrentUser.Name} {DateTime.Now}: {text}");
                    }
                    return;
                }
                _writer.Write("Unlogined users can't write");
                return;
            }
            _writer.Write("No file is open");
        }
        catch (Exception e)
        {
            _writer.Write("Error: failed to write to file");
        }
    }
}