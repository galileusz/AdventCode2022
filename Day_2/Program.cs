// See https://aka.ms/new-console-template for more information
using Day_02;

Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_02_data.txt";
var dataFile = File.ReadAllLines(_filepath);

var scores1 = dataFile.Select(x => ScoreCalculator.CalculateByFirstStrategy(x));

var answer1 = scores1.Sum();

Console.WriteLine($"\nAnswer 1: {answer1}");

var scores2 = dataFile.Select(x => ScoreCalculator.CalculateBySecondStrategy(x));

var answer2 = scores2.Sum();

Console.WriteLine($"\nAnswer 2: {answer2}");
;