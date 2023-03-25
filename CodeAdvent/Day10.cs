using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day10
    {
        private List<string> _data { get; set; } = new();
        private List<char> _openers { get; set; } = new List<char>{ '{' , '[', '(', '<' };
        private List<char> _closers { get; set; } = new List<char>{ '}', ']', ')', '>' };
        public Day10(List<string> data)
        {
            _data = data;
        }

        private int CheckRowA(string row)
        {
            Stack<char> openers = new Stack<char>();
            foreach (var x in row)
            {
                if (_openers.Contains(x))
                {
                    openers.Push(x);
                }
                else
                {
                    int i = _openers.IndexOf(openers.Pop());
                    if (_closers[i] != x)
                    {
                        return GetPointsFromMissing(x);
                    }
                }
            }

            return 0;
        }
        private long CheckRowB(string row)
        {
            Stack<char> openers = new Stack<char>();
            long sum = 0;
            foreach (var x in row)
            {
                if (_openers.Contains(x))
                {
                    openers.Push(x);
                }
                else if(_closers.Contains(x))
                {
                    int i = _openers.IndexOf(openers.Pop());
                    if (_closers[i] != x)
                    {
                        return 0;
                    }
                }
            }

            foreach (var x in openers)
            { 
                sum = 5 * sum + GetPointsFromComplete(x);
            }


            return sum;
        }

        private int GetPointsFromMissing(char x)
        {
            switch (x)
            {
                case '}':
                    return 1197;
                case ']':
                    return 57;
                case ')':
                    return 3;
                case '>':
                    return 25137;
                default:
                    return 0;
            }
        }
        private int GetPointsFromComplete(char x)
        {
            switch (x)
            {
                case '{':
                    return 3;
                case '[':
                    return 2;
                case '(':
                    return 1;
                case '<':
                    return 4;
                default:
                    return 0;
            }
        }

        public int PartA()
        {
            int sum = 0;
            foreach(var row in _data)
            {
                sum += CheckRowA(row);
            }
            return sum;
        }

        public long PartB()
        {
            List<long> results = new();
            foreach (var row in _data)
            {
                long result = CheckRowB(row);
                if (result > 0)
                {
                    results.Add(result);
                }
            }

            results.Sort();

            return results[(results.Count - 1)/2];
        }
    }
}
