using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WriteAndReadTextFile
{
    internal class LineReader
    {
        public string path;
        FileWriter writer = new FileWriter();
        internal void Read()
        {
            string line = Console.ReadLine();
            if (line[0] == '%' & line[line.Length-1] == '%')
            {
                if (line == "%read%")
                {
                    try
                    {
                        foreach (string s in File.ReadAllLines(path))
                        {
                            Console.WriteLine(s);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } else
                {
                    if (line == "%close%")
                    {
                        Process.GetCurrentProcess().Kill();
                    } else
                    {
                        if (line == "%help%")
                        {
                            Console.WriteLine("%help% - список команд с описанием\n" +
                                "%read% - прочитать содержание файла\n" +
                                "%close% - завершить работу программы");

                        }
                        else
                        {
                            Console.WriteLine("Неизвестная комманда");
                        }
                    }
                }
            } else
            {
                writer.Write(line, path);
            }
            
        }
    }
}
