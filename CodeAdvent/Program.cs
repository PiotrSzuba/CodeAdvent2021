using CodeAdvent2021;
using System;
//https://adventofcode.com/

Day1 day1 = new(ReadFromFile.Read(@"Day1A.txt"));
Console.WriteLine("Day1 A: {0} B: {1}", day1.PartA(), day1.PartB());

Day2 day2 = new (ReadFromFile.Read(@"Day2A.txt"));
Console.WriteLine("Day2 A: {0} B: {1}", day2.PartA(), day2.PartB());

Day3 day3 = new(ReadFromFile.Read(@"Day3B.txt"));
Console.WriteLine("Day3 A: {0} B: {1}", day3.PartA(), day3.PartB());

Day4 day4 = new(ReadFromFile.Read(@"Day4B.txt"));
Console.WriteLine("Day4 A: {0} B: {1}", day4.PartA(), day4.PartB());

Day5 day5 = new(ReadFromFile.Read(@"Day5B.txt"));
Console.WriteLine("Day5 A: {0} B: {1}", day5.PartA(), day5.PartB());

Day6 day6 = new(ReadFromFile.Read(@"Day6B.txt"));
Console.WriteLine("Day6 A: {0} B: {1}", day6.PartA(), day6.PartB());

Day7 day7 = new(ReadFromFile.Read(@"Day7B.txt"));
Console.WriteLine("Day7 A: {0} B: {1}", day7.PartA(), day7.PartB());

Day8 day8 = new(ReadFromFile.Read(@"Day8B.txt"));
Console.WriteLine("Day7 A: {0} B: {1}", day8.PartA(), day8.PartB());

Console.WriteLine("\nPress anything to exit");
Console.ReadKey();