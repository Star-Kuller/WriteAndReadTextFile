using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteAndReadTextFile
{
    internal class FileWriter
    {
        internal void Write(string text, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(text);
            }
        }
    }
}
