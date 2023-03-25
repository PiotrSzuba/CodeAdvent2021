using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day11
    {
        protected List<string> _data { get; set; } = new();
        public Day11(List<string> data)
        {
            _data = data;
        }

        public int PartA()
        {
            List<List<int>> data = _data.Select(x => x.ToCharArray().Where(y => Char.IsDigit(y)).Select(z => z - '0').ToList()).ToList();
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                HashSet<KeyValuePair<int, int>> toFlash = new();
                HashSet<KeyValuePair<int, int>> flashed = new();

                for(int j = 0; j < data.Count; j++)
                {
                    for(int k = 0; k < data[j].Count; k++)
                    {
                        data[j][k] += 1;
                        if(data[j][k] > 9)
                        {
                            toFlash.Add(new KeyValuePair<int,int>(j,k));
                        }
                    }
                }
                while (toFlash.Count > 0)
                {
                    var item = toFlash.First();
                    toFlash.Remove(item);
                    data[item.Key][item.Value] = 0;
                    flashed.Add(item);
                    for(int j = item.Key - 1; j < item.Key + 2; j++)
                    {
                        if(j < 0 || j >= data.Count)
                        {
                            continue;
                        }
                        for(int k = item.Value -1; k < item.Value + 2; k++)
                        {
                            if (k < 0 || k >= data[0].Count)
                            {
                                continue;
                            }
                            var newItem = new KeyValuePair<int, int>(j, k);
                            if (flashed.Contains(newItem))
                            {
                                continue;
                            }
                            data[j][k] += 1;
                            if (data[j][k] > 9)
                            {
                                toFlash.Add(newItem);
                            }
                        }
                    }
                }
                sum += flashed.Count;
            }
            return sum;
        }

        public int PartB()
        {
            List<List<int>> data = _data.Select(x => x.ToCharArray().Where(y => Char.IsDigit(y)).Select(z => z - '0').ToList()).ToList();
            int iter = 0;
            while(true)
            {
                iter++;
                HashSet<KeyValuePair<int, int>> toFlash = new();
                HashSet<KeyValuePair<int, int>> flashed = new();

                for (int j = 0; j < data.Count; j++)
                {
                    for (int k = 0; k < data[j].Count; k++)
                    {
                        data[j][k] += 1;
                        if (data[j][k] > 9)
                        {
                            toFlash.Add(new KeyValuePair<int, int>(j, k));
                        }
                    }
                }
                while (toFlash.Count > 0)
                {
                    var item = toFlash.First();
                    toFlash.Remove(item);
                    data[item.Key][item.Value] = 0;
                    flashed.Add(item);
                    for (int j = item.Key - 1; j < item.Key + 2; j++)
                    {
                        if (j < 0 || j >= data.Count)
                        {
                            continue;
                        }
                        for (int k = item.Value - 1; k < item.Value + 2; k++)
                        {
                            if (k < 0 || k >= data[0].Count)
                            {
                                continue;
                            }
                            var newItem = new KeyValuePair<int, int>(j, k);
                            if (flashed.Contains(newItem))
                            {
                                continue;
                            }
                            data[j][k] += 1;
                            if (data[j][k] > 9)
                            {
                                toFlash.Add(newItem);
                            }
                        }
                    }
                }
                if (flashed.Count == data[0].Count * data.Count)
                {
                    break;
                }
            }
            return iter;
        }
    }
}
