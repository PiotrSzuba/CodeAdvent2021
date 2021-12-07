using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day7
    {
        private List<int> _data { get; set; } = new();
        public Day7(List<string> data)
        {
            _data = data[0].Split(",").Select(x => int.Parse(x)).ToList();
        }

        private int GetAvg() => _data.Sum() / _data.Count;

        private long GetCostA(int moveTo)
        {
            int sum = 0;
            _data.ForEach(x => sum += Math.Abs(x - moveTo));

            return Convert.ToInt64(sum);
        }

        double GetDistance(long x) => ((x * x) * 0.5) + x * 0.5;

        private long GetCostB(int moveTo)
        {
            double sum = 0;
            _data.ForEach(x => sum += GetDistance(Math.Abs(x - moveTo)));

            return Convert.ToInt64(sum);
        }
        private long Solve(Func<int,long> GetCost)
        {
            long upperBound = GetCost(_data.Count / 2);
            int lowerBound = GetAvg() / 2;
            long bestCost = int.MaxValue;
            long currentCost = 0;
            long prevCost = 0;

            for (int i = lowerBound; i < upperBound; i++)
            {
                if (i > 0)
                {
                    prevCost = GetCost(i - 1);
                }
                currentCost = GetCost(i);
                if (currentCost > prevCost)
                {
                    break;
                }
                if (bestCost > currentCost)
                {
                    bestCost = currentCost;
                }
            }

            return bestCost;
        }

        public long PartA() => Solve(GetCostA);
        public long PartB() => Solve(GetCostB);
    }
    
}
