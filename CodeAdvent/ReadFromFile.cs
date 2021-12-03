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
        public List<string>? Data { get; set; } = null;
        public ReadFromFile() { }
        private void Read(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path);
                Data = new List<string>();
                Data = lines.ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("File does not exist");
            }
        }
        public List<int> GetInts(string path)
        {
            Read(path);
            List<int> DataAsInts = new List<int>();
            foreach (string line in Data!)
            {
                DataAsInts.Add(Int32.Parse(line));
            }
            return DataAsInts;
        }
        public List<string> GetStrings(string path)
        {
            Read(path);
            return Data!;
        }

        public List<Tuple<string,int>> GetTuple(string path)
        {
            List<Tuple<string, int>> data = new List<Tuple<string, int>>();
            string temp = "";
            int value = 0;
            Read(path);
            foreach (var line in Data!)
            {
                temp = new(line.Where(Char.IsDigit).ToArray());
                value = Int32.Parse(temp);

                temp = new(line.Where(Char.IsLetter).ToArray());
                data.Add(new(temp,value));
            }
            
            return data;
        }

    }
}
