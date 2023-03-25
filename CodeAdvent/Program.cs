using CodeAdvent2021;
using System;
using System.Reflection;

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
Console.WriteLine("Day8 A: {0} B: {1}", day8.PartA(), day8.PartB());

Day9 day9 = new(ReadFromFile.Read(@"Day9B.txt"));
Console.WriteLine("Day10 A: {0} B: {1}", day9.PartA(), day9.PartB());

Day10 day10 = new(ReadFromFile.Read(@"Day10B.txt"));
Console.WriteLine("Day10 A: {0} B: {1}", day10.PartA(), day10.PartB());

Day11 day11 = new(ReadFromFile.Read(@"Day11B.txt"));
Console.WriteLine("Day11 A: {0} B: {1}", day11.PartA(), day11.PartB());

Day12 day12 = new(ReadFromFile.Read(@"Day12A.txt"));
Console.WriteLine("Day12 A: {0} B: {1}", day12.PartA(), day12.PartB());

Console.WriteLine("\nPress anything to exit");
Console.ReadKey();