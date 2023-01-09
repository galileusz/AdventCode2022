// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_10_data.txt";
var dataFile = File.ReadAllLines(_filepath).ToArray();

var X = 1;
var currentCycles = 0;
var cycleNumber = 1;
var additional = 0;
var sumOfSignalStrength = 0;
var spritePos = 1;
foreach (var line in dataFile)
{
    if (line.StartsWith("noop"))
    {
        currentCycles = 1;
        additional = 0;
    }
    if (line.StartsWith("addx"))
    {
        currentCycles = 2;
        additional = Convert.ToInt32(line.Split(' ')[1]);
    }
    for(int i = 0; i < currentCycles; i++)
    {
        if ((cycleNumber - 20) % 40 == 0)
            sumOfSignalStrength += X * cycleNumber;
        if ((cycleNumber % 40 >= spritePos && cycleNumber % 40 <= spritePos + 2) && (cycleNumber%40 != 0))
            Console.Write("#");
        else if ((cycleNumber % 40 == 0 && spritePos > 37))
            Console.Write("#");
        else
            Console.Write(".");
        if (cycleNumber % 40 == 0)
            Console.WriteLine();
        cycleNumber++;
        if (i == currentCycles - 1)
        {
            X += additional;
            spritePos += additional;
        }
    }
}

var answer1 = sumOfSignalStrength;

Console.WriteLine($"\nAnswer 1: {answer1}");

var answer2 = sumOfSignalStrength;

Console.WriteLine($"\nAnswer 2: {answer2}");

