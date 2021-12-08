using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day8
    {
        private List<string> _data { get; set; } = new();
        public Day8(List<string> data)
        {
            _data = data;
        }
        public int PartA()
        {
            List<string> data = new();
            List<int> vals = new List<int> {2,3,4,7 };
            int elems = 0;
            foreach (var line in _data)
            {
                data.Add(line.Split(" | ")[1]);
            }
            for (int i = 0; i < data.Count; i++)
            {
                var split = data[i].Split(" ").Select(x => String.Join("",x.ToArray().Where(y => Char.IsLetter(y)))).Select(x => x.Length).ToList();
                foreach(var x in split)
                {
                    if (vals.Contains(x))
                    {
                        elems++;
                    }
                }
            }

            return elems;
        }

        public int PartB()
        {
            int resultSum = 0;
            foreach(var line in _data)
            {
                var split = line.Split(" | ").ToList();
                string data1 = split[0];
                string data2 = split[1];
                List<string> codes = GetEachCode(data1);
                List<string> toDecode = GetEachCode(data2);
                string one = "";
                string four = "";
                string seven = "";
                string eight = "";
                string resultString = "";
                foreach(var x in codes)
                {
                    switch(x.Length)
                    {
                        case 2:
                            one = x;
                            break;
                        case 3:
                            seven = x;
                            break;
                        case 4:
                            four = x;
                            break;
                        case 7:
                            eight = x;
                            break;
                    default:
                            break;
                    }
                }

                foreach(var x in toDecode)
                {
                    switch (x.Length)
                    {
                        case 2:
                            resultString += "1";
                            break;
                        case 3:
                            resultString += "7";
                            break;
                        case 4:
                            resultString += "4";
                            break;
                        case 5:
                            resultString += twoThreeOrFive(x,one,four,eight);
                            break;
                        case 6:
                            resultString += zeroSixNine(x,four,seven);
                            break;
                        case 7:
                            resultString += "8";
                            break;
                        default:
                            break;
                    }
                }
                resultSum += int.Parse(resultString);
             }

            return resultSum;
        }
        private List<string> GetEachCode(string line)
        {
            return line.Split(" ").Select(x => String.Join("", x.ToArray().Where(y => Char.IsLetter(y)))).ToList();
        }

        private string twoThreeOrFive(string code, string one,string four,string eight)
        {
            var twoMustContain = eight.ToCharArray().Where(x => !four.Contains(x)).ToArray();
            if(one.ToCharArray().All(x => code.Contains(x)))
            {
                return "3";
            }
            else if(twoMustContain.All(x => code.Contains(x)))
            {
                return "2";
            }
            else
            {
                return "5";
            }
        }

        private string zeroSixNine(string code,string four,string seven)
        {
            if(four.ToCharArray().All(x => code.Contains(x)))
            {
                return "9";
            }
            else if(seven.ToCharArray().All(x => code.Contains(x)))
            {
                return "0";
            }
            else
            {
                return "6";
            }
        }
    }
}
