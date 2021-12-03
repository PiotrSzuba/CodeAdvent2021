using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day2
    {
        private int _depth { get; set; } = 0;
        private int _horizontal { get; set; } = 0;
        private int _aim { get; set; } = 0;
        private List<Tuple<string, int>> _data = new List<Tuple<string, int>>();
        public Day2(List<Tuple<string,int>> data )
        {
            if (data == null)
            {
                Console.WriteLine("Data is null");
                return;
            }
            _data = data;
        }

        public int PartA()
        {
            _horizontal = 0;
            _depth = 0;
            foreach (var x in _data)
            {
                if(x.Item1.Equals("forward"))
                {
                    _horizontal += x.Item2;
                }
                else if(x.Item1.Equals("up"))
                {
                    _depth -= x.Item2;
                }
                else if(x.Item1.Equals("down"))
                {
                    _depth += x.Item2;
                }
            }

            return _depth * _horizontal;
        }

        public int PartB()
        {
            _horizontal = 0;
            _depth = 0;
            _aim = 0;
            foreach (var x in _data)
            {
                if (x.Item1.Equals("forward"))
                {
                    _horizontal += x.Item2;
                    _depth += (x.Item2 * _aim);
                }
                else if (x.Item1.Equals("up"))
                {
                    _aim -= x.Item2;
                }
                else if (x.Item1.Equals("down"))
                {
                    _aim += x.Item2;
                }
            }

            return _depth * _horizontal;
        }
    }
}
