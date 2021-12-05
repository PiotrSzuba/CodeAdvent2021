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

        public Day2(List<string> data )
        {
            _data = GetTuple(data);
        }

        public List<Tuple<string, int>> GetTuple(List<string> data)
        {
            List<Tuple<string, int>> tuple = new List<Tuple<string, int>>();
            foreach (var line in data!)
            {
                var value = Int32.Parse(line.Where(x => Char.IsDigit(x)).ToArray());

                var letter = String.Join("",line.Where(x => Char.IsLetter(x)).ToArray()); 

                tuple.Add(new(letter, value));
            }

            return tuple;
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
