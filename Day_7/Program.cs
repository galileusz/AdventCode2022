// See https://aka.ms/new-console-template for more information
using Day_07;

Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_07_data.txt";
var dataFile = File.ReadAllLines(_filepath).ToArray();

var directoryDictionary = new DirectoryDictionary();
var mainDirectory = directoryDictionary.Create(dataFile);

var listOfSizes = directoryDictionary.GetDirectoriesSize().ToList();

var answer1 = listOfSizes.Where(x => x < 100000).Sum();

Console.WriteLine($"\nAnswer 1: {answer1}");

var spaceToClean = 30000000 - (70000000 - mainDirectory.Size);

var answer2 = listOfSizes.Where(x => x >= spaceToClean).Min();

Console.WriteLine($"\nAnswer 2: {answer2}");
