// See https://aka.ms/new-console-template for more information
using Day_04;

Console.WriteLine("Hello, World!");


var _filepath = "../../../../day_04_data.txt";
var dataFile = File.ReadAllLines(_filepath);

var pairsOfElves = dataFile.Select(x => new PairOfElves(x));

var answer1 = pairsOfElves.Count(x => x.IsPairIntersection());

Console.WriteLine($"\nAnswer 1: {answer1}");

var answer2 = pairsOfElves.Count(x => x.IsPairOverlaping());

Console.WriteLine($"\nAnswer 2: {answer2}");
