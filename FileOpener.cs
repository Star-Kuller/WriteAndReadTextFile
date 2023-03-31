using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteAndReadTextFile
{
    internal class FileOpener
    {
        internal void Open(string path)
        {
            DateTime dateTime = DateTime.UtcNow;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Дата записи: " + dateTime.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
