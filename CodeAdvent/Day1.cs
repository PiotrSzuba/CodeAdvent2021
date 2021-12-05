using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day1
    {
        private int _larger { get; set; } = 0;
        private List<int>? _data { get; set; } = null;

        public Day1(List<string> data) 
        {
            _data = data.Select(x => Int32.Parse(x)).ToList();
        }

        public int PartA()
        {
            _larger = 0;
            for (int i = 0; i < _data!.Count - 1; i++)
            {
                if (_data[i + 1] > _data[i])
                {
                    _larger++;
                }
            }

            return _larger;
        }

        public int PartB()
        {
            _larger = 0;
            for (int i = 3; i < _data!.Count; i++)
            {
                if(_data[i - 3] + _data[i - 2] + _data[i-1] < _data[i] + _data[i - 1] + _data[i-2])
                {
                    _larger++;
                }
            }

            return _larger;
        }
    }
}
