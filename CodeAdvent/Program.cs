using CodeAdvent2021;
using System;
//https://adventofcode.com/

ReadFromFile readFromFile = new();
Day1 day1 = new(readFromFile.GetInts(@"DataDay1A.txt"));
Console.WriteLine("Day1 A: {0} B: {1}", day1.PartA(), day1.PartB());

Day2 day2 = new (readFromFile.GetTuple(@"DataDay2A.txt"));
Console.WriteLine("Day2 A: {0} B: {1}", day2.PartA(), day2.PartB());

Day3 day3 = new(readFromFile.GetStrings(@"DataDay3A.txt"));
Console.WriteLine("Day3 A: {0} B: {1}", day3.PartA(), day3.PartB());

Day4 day4 = new(readFromFile.GetStrings(@"DataDay4B.txt"));
Console.WriteLine("Day4 A: {0} B: {1}", day4.PartA(), day4.PartB());

Console.WriteLine("\nPress anything to exit");
Console.ReadKey();