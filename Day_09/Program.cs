// See https://aka.ms/new-console-template for more information
using Day_09;

var _filepath = "../../../../day_09_data.txt";
var dataFile = File.ReadAllLines(_filepath).ToList();

var snake = new Snake(2);
foreach (var command in dataFile)
    snake.MoveByCommand(command);


var answer1 = snake.TailPositionHistory.GroupBy(x => x).Count();

Console.WriteLine($"\nAnswer 1: {answer1}");

snake = new Snake(10);
foreach (var command in dataFile)
    snake.MoveByCommand(command);

var answer2 = snake.TailPositionHistory.GroupBy(x => x).Count();

Console.WriteLine($"\nAnswer 2: {answer2}");

