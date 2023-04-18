namespace WriteAndReadTextFile;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите путь к файлу [С://]: ");
        string initialPath = Console.ReadLine();
        ConsoleHandler consoleHandler = new ConsoleHandler(initialPath);
        while (true)
        {
            consoleHandler.Read();
        }
    }
}
