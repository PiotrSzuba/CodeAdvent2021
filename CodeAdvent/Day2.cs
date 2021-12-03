using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day2
    {
        private int Depth { get; set; } = 0;
        private int Horizontal { get; set; } = 0;

        private int Aim { get; set; } = 0;

        private List<Tuple<string, int>> Data = new List<Tuple<string, int>>();
        private List<string>? Commands { get; set; } = null;
        private List<int>? Values { get; set; } = null;
        public Day2(List<Tuple<string,int>> data )
        {
            if (data == null)
            {
                Console.WriteLine("Data is null");
                return;
            }

            Data = data;
        }

        public int PartA()
        {
            Horizontal = 0;
            Depth = 0;
            foreach (var x in Data)
            {
                if(x.Item1.Equals("forward"))
                {
                    Horizontal += x.Item2;
                }
                else if(x.Item1.Equals("up"))
                {
                    Depth -= x.Item2;
                }
                else if(x.Item1.Equals("down"))
                {
                    Depth += x.Item2;
                }
            }

            return Depth * Horizontal;
        }

        public int PartB()
        {
            Horizontal = 0;
            Depth = 0;
            Aim = 0;
            foreach (var x in Data)
            {
                if (x.Item1.Equals("forward"))
                {
                    Horizontal += x.Item2;
                    int temp = x.Item2 * Aim;
                    Depth += temp;
                }
                else if (x.Item1.Equals("up"))
                {
                    Aim -= x.Item2;
                }
                else if (x.Item1.Equals("down"))
                {
                    Aim += x.Item2;
                }
            }

            return Depth * Horizontal;
        }
    }
}
