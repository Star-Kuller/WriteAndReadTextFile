using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteAndReadTextFile
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь к папке, где необходимо создать/открыть файл: ");
            FileOpener opener = new FileOpener();
            LineReader lineReader = new LineReader();
            string path = Console.ReadLine();
            path += "/test.txt";
            opener.Open(path);
            lineReader.path=path;
            Console.WriteLine("Вводите текст или команду (%help% - список команд):");
            while(true)
            {
                lineReader.Read();
            }
        }
    }
}
