using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeAdvent2021
{
    public class ReadFromFile
    {
        public static List<string> Read(string path) => File.ReadAllText(path).Split('\n').ToList();

    }
}
