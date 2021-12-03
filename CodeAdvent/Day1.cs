using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAdvent2021
{
    public class Day1
    {
        public int Larger { get; set; } = 0;
        public List<int>? Data { get; set; } = null;

        public Day1(List<int> data) 
        {
            if(data == null)
            {
                Console.WriteLine("Data is null");
                return;
            }

            Data = data;
        }

        public int PartA()
        {
            Larger = 0;
            for (int i = 0; i < Data!.Count - 1; i++)
            {
                if (Data[i + 1] > Data[i])
                {
                    Larger++;
                }
            }

            return Larger;
        }

        public int PartB()
        {
            Larger = 0;
            for (int i = 3; i < Data!.Count; i++)
            {
                if(Data[i - 3] + Data[i - 2] + Data[i-1] < Data[i] + Data[i - 1] + Data[i-2])
                {
                    Larger++;
                }
            }

            return Larger;
        }
    }
}
