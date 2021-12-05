using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// Prosty wrapper do wczytywania danych
/// W zależności od zadania nowe metody
/// beda sie pojawiac aby metody w innych klasach 
/// mialy dobre dane na wejsciu
/// </summary>


namespace CodeAdvent2021
{
    public class ReadFromFile
    {
        public ReadFromFile() { }
        public static List<string> Read(string path)
        {
            return File.ReadAllText(path).Split('\n').ToList();
        }

    }
}
