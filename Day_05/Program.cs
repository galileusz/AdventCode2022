// See https://aka.ms/new-console-template for more information

using Day_05;

Console.WriteLine("Hello, World!");


var _filepath = "../../../../day_05_data.txt";
var dataFile = File.ReadAllLines(_filepath).ToList();
var index = dataFile.IndexOf(string.Empty);
var stacksData = dataFile.Take(index).ToArray();
var movesData = dataFile.Take(Range.StartAt(index + 1)).ToArray();

var crateStacks = new CrateStacks(stacksData);
crateStacks.MoveCrates(movesData);

var answer1 = crateStacks.GetTopCrates();

Console.WriteLine($"\nAnswer 1: {answer1}");

crateStacks = new CrateStacks(stacksData);
crateStacks.MoveCrates(movesData, multiple: true);

var answer2 = crateStacks.GetTopCrates();

Console.WriteLine($"\nAnswer 2: {answer2}");
