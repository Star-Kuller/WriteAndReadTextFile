namespace WriteAndReadTextFile;
class Program
{
    static void Main(string[] args)
    {
        ConsoleHandler consoleHandler = new ConsoleHandler();
        while (true)
        {
            consoleHandler.Read();
        }
    }
}
