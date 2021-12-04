using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    internal class BingoTable
    {
        private List<List<int>>? _bingoTable { get; set; }
        private List<List<int>> _markedBingoTable = new List<List<int>>();
        public bool _IsBingo = false;
        public BingoTable(List<List<int>> bingoTable)
        {
            _bingoTable = bingoTable;
            for(int i = 0; i < _bingoTable.Count(); i++)
            {
                List<int> newRow = new List<int>();
                for(int j = 0; j < _bingoTable.Count(); j++ )
                {
                    newRow.Add(-1);
                }
                _markedBingoTable.Add(newRow);
            }
        }
        public BingoTable() { }
        public int SumOfUnmarked()
        {
            int sum = 0;
            for (int i = 0; i < _bingoTable!.Count(); i++)
            {
                for (int j = 0; j < _bingoTable!.Count(); j++)
                {
                    if(_markedBingoTable![i][j] == -1)
                    {
                        sum += _bingoTable![i][j];
                    }
                }
            }

            return sum;
        }
        public void MarkValue(int drawnNumber)
        {
            for (int i = 0; i < _bingoTable!.Count(); i++)
            {
                for (int j = 0; j < _bingoTable!.Count(); j++)
                {
                    if (_bingoTable![i][j] == drawnNumber)
                    {
                        _markedBingoTable![i][j] = _bingoTable[i][j];
                    }
                }
            }
        }

        public bool CheckIfBingo()
        {
            if (_IsBingo == true)
                return false;

            for (int i = 0; i < _bingoTable!.Count(); i++)
            {
                List<int> column = new List<int>();
                List<int> row = new List<int>();
                for (int j = 0; j < _bingoTable!.Count(); j++)
                {
                    if(_markedBingoTable![i][j] != -1)
                    {
                        row.Add(_markedBingoTable![i][j]);
                    }
                    if (_markedBingoTable![j][i] != -1)
                    {
                        column.Add(_markedBingoTable![j][i]);
                    }
                }
                if(row.Count() == _bingoTable!.Count())
                {
                    _IsBingo = true;
                    return _IsBingo;
                }
                if (column.Count() == _bingoTable!.Count())
                {
                    _IsBingo = true;
                    return _IsBingo;
                }
            }

            return _IsBingo;
        }

    }

    public class Day4
    {
        public List<string>? _data { get; set; } = null;
        private List<BingoTable> _bingoTables = new();
        private List<int> _orderOfNums = new();
        public Day4(List<string> data)
        {
            _data = data;
            CreateBingoTables();
            CreateNumberOrder();
        }

        private void CreateNumberOrder()
        {
            _orderOfNums = _data![0].Split(',').Select(x => Int32.Parse(x)).ToList();
        }

        private void CreateBingoTables()
        {
            for (int i = 1; i < _data!.Count; i++)
            {
                if (_data[i].Count() == 0)
                {
                    List<List<int>> bingoTable = new List<List<int>>();
                    for (int j = 0; j < 5; j++)
                    {
                        i++;
                        List<int> newRow = new List<int>();
                        newRow = _data![i].Split(' ').Where(x => x.Count() != 0).Select(x => Int32.Parse(x)).ToList();
                        bingoTable.Add(newRow);
                    }
                    _bingoTables.Add(new BingoTable(bingoTable));
                }
            }
        }

        public int PartA()
        {
            foreach(var x in _orderOfNums)
            {
                foreach(var table in _bingoTables)
                {
                    table.MarkValue(x);
                    if (table.CheckIfBingo())
                    {
                        return table.SumOfUnmarked() * x;
                    }
                }
            }

            return -1;
        }
        public int PartB()
        {
            int lastNum = 0;
            int sum = 0;
            foreach (var x in _orderOfNums)
            {
                for (int i = 0; i < _bingoTables.Count; i++)
                {
                    _bingoTables[i].MarkValue(x);
                    if (_bingoTables[i].CheckIfBingo())
                    {
                        lastNum = x;
                        sum = _bingoTables[i].SumOfUnmarked();
                    }
                }
            }
            return sum * lastNum;
        }
    }
}
