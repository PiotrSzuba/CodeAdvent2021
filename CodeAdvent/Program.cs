using CodeAdvent2021;
using System;
//https://adventofcode.com/

ReadFromFile readFromFile = new ReadFromFile();
Day1 day1 = new Day1(readFromFile.GetInts(@"DataDay1A.txt"));
//Console.WriteLine(day1.PartA());
//Console.WriteLine(day1.PartB());

Day2 day2 = new Day2(readFromFile.GetTuple(@"DataDay2A.txt"));
Console.WriteLine(day2.PartA());
Console.WriteLine(day2.PartB());

Day3 day3 = new Day3(readFromFile.GetStrings(@"DataDay3A.txt"));
Console.WriteLine(day3.PartA());
Console.WriteLine(day3.PartB());

Console.WriteLine("\nPress anything to exit");
Console.ReadKey();