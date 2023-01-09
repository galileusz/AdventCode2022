// See https://aka.ms/new-console-template for more information
using System.Data;
using Day_11;

Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_11_data.txt";
var dataFile = File.ReadAllText(_filepath);
var monkeysData = dataFile.Split("\r\n\r\n").Select(x => x.Split("\r\n")).ToList();

var monkeys = monkeysData.Select(x => new Monkey(x)).ToList();

for (int i=0; i<20;i++)
{
    foreach (var monkey in monkeys)
        monkey.ThrowItems(monkeys, useWorryLevelDivisor: true);
}

var numberOfInspectionsList = monkeys.Select(x => x.InspectedItems).OrderByDescending(x => x).ToList();

var answer1 = numberOfInspectionsList.First() * numberOfInspectionsList.Skip(1).First();

Console.WriteLine($"\nAnswer 1: {answer1}");

monkeys = monkeysData.Select(x => new Monkey(x)).ToList();

for (int i = 0; i < 10000; i++)
{
    foreach (var monkey in monkeys)
        monkey.ThrowItems(monkeys);
}

numberOfInspectionsList = monkeys.Select(x => x.InspectedItems).OrderByDescending(x => x).ToList();

var answer2 = numberOfInspectionsList.First() * numberOfInspectionsList.Skip(1).First();

Console.WriteLine($"\nAnswer 2: {answer2}");

;

