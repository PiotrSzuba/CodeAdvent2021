using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day3
    {
        public List<string>? _data { get; set; } = null;
        public Day3(List<string> data)
        {
            _data = data;

        }

        private char GetLeast(string data)
        {
            var least = data
                .GroupBy(x => x)
                .OrderBy(group => group.Count())
                .Select(x => x.Key)
                .First();

            return least;
        }
        private char GetMost(string data)
        {
            var most = data
                .GroupBy(x => x)
                .OrderBy(group => group.Count())
                .Select(x => x.Key)
                .Last();

            return most;
        }

        public int PartA()
        {
            string gamma = "";
            string epsilon = "";

            string[] data = new string[12];

            foreach(var x in _data!)
            {
                for(int i = 0; i < x.Count(); i++)
                {
                    data[i] += x[i];
                }
            }

            foreach (var x in data)
            {
                gamma += GetMost(x);
                epsilon += GetLeast(x);
            }

            int _epsilon = Convert.ToInt32(epsilon,2);
            int _gamma = Convert.ToInt32(gamma, 2);

            return _epsilon * _gamma;
        }

        private int PartBWrapper(bool one)
        {
            int currentSize = _data!.Count();
            int rowSize = _data![0].Count();
            var currentData = new List<string>();
            currentData = _data;
            string strResult = "";
            int charValue = 0;
            for (int i = 0; i < rowSize; i++)
            {
                charValue = 0;
                foreach (var x in currentData)
                {   
                    var temp = x[i];
                    charValue += int.Parse(temp.ToString());
                }
                currentSize = currentData.Count();
                char searchArgument = ' ';
                if(one)
                {
                    searchArgument = currentSize - (2 * charValue) <= 0 ? '0' : '1';
                }
                else
                {
                    searchArgument = currentSize - (2 * charValue) <= 0 ? '1' : '0';
                }

                var tempData = (from x in currentData where x[i].Equals(searchArgument) select x).ToList();

                if (tempData.Count() != 0)
                {
                    currentData = tempData;
                    strResult = string.Join(",", currentData);
                }
            }
            return Convert.ToInt32(strResult, 2);

        }

        public int PartB() => PartBWrapper(true) * PartBWrapper(false);
    }
}
