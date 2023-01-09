// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_06_data.txt";
var dataFile = File.ReadAllText(_filepath);


var answer1 = GetFirstMarker(dataFile, 4);

Console.WriteLine($"\nAnswer 1: {answer1}");


var answer2 = GetFirstMarker(dataFile, 14);

Console.WriteLine($"\nAnswer 2: {answer2}");


static int GetFirstMarker(string data, int numberOfLetters)
{
    int i;
    for (i = numberOfLetters - 1; i < data.Length; i++)
    {
        var part = data.Substring(i + 1 - numberOfLetters, numberOfLetters);
        if (part.GroupBy(x => x).Any(y => y.Count() > 1) == false)
            break;
    }
    return i + 1;
}