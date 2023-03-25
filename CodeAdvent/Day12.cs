using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace CodeAdvent2021
{
    public class Day12
    {   
        private List<string> _data {get; set;} = new();
        private List<string> _visited {get; set;} = new();

        public Day12(List<string> data)
        {
            _data = data;
            foreach (var item in data)
            {
                WriteLine(item);
            }
        }

        public int PartA()
        {
            return -1;
        }

        public int PartB()
        {
            return -1;
        }

        private bool checkVisited(string input)
        {
            return _visited.Find(input);
        }
    }
}
