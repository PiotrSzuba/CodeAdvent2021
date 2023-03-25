using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day9
    {
        private List<List<int>> _data { get; set; } = new();
        public Day9(List<string> data)
        {
            var extraRow = Enumerable.Range(0,data[0].Length+1).Select(x => 9).ToList();
            _data.Add(extraRow);

            foreach(var row in data)
            {
                var temp = row.ToCharArray().Where(x => Char.IsDigit(x)).Select(x => Int32.Parse(x.ToString())).ToList();
                temp.Insert(0, 9);
                temp.Insert(temp.Count, 9);
                _data.Add(temp);
            }
            _data.Add(extraRow);
        }
        private bool IsLowerA(List<List<int>> lines, int i, int j)
        {
            int value = lines[i][j];

            int p1 = lines[i][j - 1];
            int p2 = lines[i][j + 1];
            int p3 = lines[i-1][j];
            int p4 = lines[i+1][j];

            if (value < p1 && value < p2 && value < p3 && value < p4)
            {
                return true;
            }

            return false;
        }

        public int PartA()
        {
            int risk = 0;
            for(int i = 1; i<_data.Count-1; i++)
            {
                for(int j = 1; j < _data[i].Count-1; j++)
                {
                    if (IsLowerA(_data, i, j))
                    {
                        risk += _data[i][j] + 1;
                    }
                }
            }

            return risk;
        }

        public int PartB()
        {
            var lines = _data;

            List<int> basins = new List<int>();

            for (var i = 1; i < lines.Count -1; i++)
            {

                for (int j = 1; j < lines[i].Count - 1; j++)
                {
                    if (IsLowerA(lines, i, j))
                    {
                        HashSet<(int, int)> visited = new HashSet<(int, int)> { (i, j) };
                        FindBasin(lines, i, j, visited);
                        basins.Add(visited.Count);
                    }
                }
            }

            int max1 = basins.Max();
            basins.Remove(max1);

            int max2 = basins.Max();
            basins.Remove(max2);

            int max3 = basins.Max();
            basins.Remove(max3);

            return max1 * max2 * max3;
        }

        private void FindBasin(List<List<int>> lines, int x, int y, HashSet<(int, int)> visited)
        {
            int value = lines[x][y];

            int b1 = lines[x][y - 1];
            int b2 = lines[x][y + 1];
            int b3 = lines[x - 1][y];
            int b4 = lines[x + 1][y];

            if (b1 < 9 && b1 > value && !visited.Contains((x, y - 1)))
            {
                visited.Add((x, y - 1));

                FindBasin(lines, x, y - 1, visited);
            }

            if (b2 < 9 && b2 > value && !visited.Contains((x, y + 1)))
            {
                visited.Add((x, y + 1));

                FindBasin(lines, x, y + 1, visited);
            }

            if (b3 < 9 && b3 > value && !visited.Contains((x - 1, y)))
            {
                visited.Add((x - 1, y));

                FindBasin(lines, x - 1, y, visited);
            }

            if (b4 < 9 && b4 > value && !visited.Contains((x + 1, y)))
            {
                visited.Add((x + 1, y));

                FindBasin(lines, x + 1, y, visited);
            }
        }
    }
}
