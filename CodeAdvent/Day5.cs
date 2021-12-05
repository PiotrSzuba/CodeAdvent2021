using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    internal class Line
    {
        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;
        public Line(List<int> points)
        {
            _x1 = points[0];
            _y1 = points[1];
            _x2 = points[2];
            _y2 = points[3];
        }

        public bool AddHorizontal(int[,] matrix)
        {
            if (_y1 - _y2 == 0)
            {
                List<int> xList = new();
                if (_x1 > _x2)
                {
                    for (int i = _x1; i >= _x2; i--)
                    {
                        matrix[_y1, i] += 1;
                    }
                }
                else
                {
                    for (int i = _x1; i <= _x2; i++)
                    {
                        matrix[_y1, i] += 1;
                    }
                }
                return true;
            }

            return false;
        }
        public bool AddVertical(int[,] matrix)
        {
            if (_x1 - _x2 == 0)
            {
                List<int> yList = new();
                if (_y1 > _y2)
                {
                    for (int i = _y1; i >= _y2; i--)
                    {
                        yList.Add(i);
                        matrix[i, _x1] += 1;
                    }
                }
                else
                {
                    for (int i = _y1; i <= _y2; i++)
                    {
                        yList.Add(i);
                        matrix[i, _x1] += 1;
                    }
                }

                return true;
            }

            return false;
        }

        public bool AddDiagonal(int[,] matrix)
        {
            if (_x1 - _x2 != 0 && _y1 - _y2 != 0)
            {
                List<int> xList = new ();
                List<int> yList = new ();
                if(_x1 > _x2)
                {
                    for(int i = _x1; i >= _x2; i--)
                    {
                        xList.Add(i);
                    }
                }
                else
                {
                    for (int i = _x1; _x2 >= i; i++)
                    {
                        xList.Add(i);
                    }

                }
                if (_y1 > _y2)
                {
                    for (int i = _y1; i >= _y2; i--)
                    {
                        yList.Add(i);
                    }
                }
                else
                {
                    for (int i = _y1; _y2 >= i; i++)
                    {
                        yList.Add(i);
                    }
                }
                if (xList.Count == yList.Count)
                {
                    for (int i = 0; i < xList.Count; i++)
                    {
                        matrix[yList[i], xList[i]] += 1;
                    }
                }
                return true;
            }

            return false;
        }
    }

    public class Day5
    {
        private List<string> _data { get; set; } = new();
        private List<Line> _lines { get; set; } = new();
        private int[,] _matrix = new int[1000, 1000];
        public Day5(List<string> data)
        {
            _data = data;
            _lines = GetLines();
        }

        private List<Line> GetLines()
        {
            List<Line> lines = new();
            foreach (var x in _data)
            {
                List<int> pointsList = new();
                var cords = x.Split(" -> ");
                foreach(var cord in cords)
                {
                    var pointsInCord = cord.Split(",").Select(x => Int32.Parse(x)).ToList();
                    foreach(var point in pointsInCord)
                    {
                        pointsList.Add(point);
                    }
                }
                lines.Add(new Line(pointsList));
            }

            return lines;
        }

        private int CheckOverlaps(int[,] matrix)
        {
            int overlaps = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (matrix[i, j] > 1)
                    {
                        overlaps++;
                    }
                }
            }
            return overlaps;
        }

        public int PartA()
        {
            _matrix = new int[1000, 1000];
            foreach ( var line in _lines)
            {
                line.AddHorizontal(_matrix);
                line.AddVertical(_matrix);
            }

            return CheckOverlaps(_matrix);
        }

        public int PartB()
        {
            _matrix = new int[1000, 1000];
            foreach (var line in _lines)
            {
                line.AddHorizontal(_matrix);
                line.AddVertical(_matrix);
                line.AddDiagonal(_matrix);
            }

            return CheckOverlaps(_matrix);
        }

    }
}
