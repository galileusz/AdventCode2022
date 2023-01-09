// See https://aka.ms/new-console-template for more information
using Day_03;

Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_03_data.txt";
var dataFile = File.ReadAllLines(_filepath);

var backpacks = dataFile.Select(x => new Backpack(x)).ToList();

var scores = backpacks.Select(x => x.GetScore());

var answer1 = scores.Sum();

Console.WriteLine($"\nAnswer 1: {answer1}");

var scores2 = 0;
for(int i = 0; i < backpacks.Count; i+=3)
    scores2 += backpacks[i].GetScoreOfBadges(backpacks[i+1], backpacks[i+2]);

var answer2 = scores2;

Console.WriteLine($"\nAnswer 2: {answer2}");

