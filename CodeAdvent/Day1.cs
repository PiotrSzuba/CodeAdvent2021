using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Opis dzialania: 
/// 
/// W tym zadaniu chodzilo o zwykle znalezienie zasiegu dzialania petli
/// Znaki ? oraz ! beda sie powatarzac w nastepnych rozwiazaniach
/// Znak ? - daje znac ze wartosc moze byc nullem
/// Znak ! - daje znac ze nie ma mozliwosci aby wartosc byla nullem
/// znak ! wystarczy dac na poczatku metody i starcza mozna tez nie dawac
/// ale beda ostrzerzenia ktore brzydko wygladaja w ide
/// 
/// Czesc pierwsza polegala na znalezieniu czy wartosc nastepna jest wieksza od poprzedniej
/// Tak wiec zasieg petli to:
/// start = 0 -> data.size-1 
/// lub 
/// start = 1 -> data.size
/// 
/// Druga czesc polegala na sumowaniu grup po 3 
/// A
/// AB
/// ABC
///  BCD I tak dalej
///  Z tego wynika że dla kazdej litery byly dwa elementy wspolne
///  oraz dwa elementy nie wspolne
///  Oznacza to że ilosc elementow w jednym rowaniu to 4
///  tak wiec zasieg petli to:
///  start = 3 -> data.size
///  lub
///  start = 0 -> data.size-4
///  (0,1,2,3).size = 4
/// </summary>

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
