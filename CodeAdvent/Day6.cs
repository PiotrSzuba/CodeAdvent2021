using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public  class Day6
    {
        private List<int> _data { get; set; } = new();
        public Day6(List<string> data)
        {
            _data = data[0].Split(",").Select(x => int.Parse(x)).ToList();
        }

        public long PartA() => PopulationAfer(80);

        public long PartB() => PopulationAfer(256);

        private long PopulationAfer(int maxDays)
        {
            int initialDayForNew = 8;
            int initialDayForOld = 6;
            long result = 0;
            List<int> data = _data;
            List<long> currentFishes = Enumerable.Range(0, initialDayForNew + 1).Select(x => 0L).ToList();
            foreach (var x in data)
            {
                currentFishes[x]++;
            }

            for (int i = 0; i < maxDays; i++)
            {
                long nextGen = 0;
                for (int j = 0; j <= initialDayForNew; j++)
                {
                    if (j == 0)
                    {
                        nextGen = currentFishes[j];
                        currentFishes[j] = 0;
                    }
                    else
                    {
                        currentFishes[j - 1] += currentFishes[j];
                        currentFishes[j] = 0;
                    }
                }
                currentFishes[initialDayForNew] = nextGen;
                currentFishes[initialDayForOld] += nextGen;
            }

            currentFishes.ForEach(x => result += x);

            return result;
        }
    }
}
