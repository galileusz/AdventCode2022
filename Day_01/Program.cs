// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_01_data.txt";
var dataFile = File.ReadAllLines(_filepath);
;
;
var elf_list = new List<int>();
int calories = 0;
for (int i = 0; i < dataFile.Length; i++)
{
    if (dataFile[i] == string.Empty)
    {
        elf_list.Add(calories);
        calories = 0;
        continue;
    }
    calories += Convert.ToInt32(dataFile[i]);
}

var answer1 = elf_list.Max();

Console.WriteLine($"\nAnswer 1: {answer1}");

var answer2 = 0;
for (int i = 0; i<3 ; i++)
{
    var max = elf_list.Max();
    answer2 += max;
    elf_list.Remove(max);
}

Console.WriteLine($"\nAnswer 2: {answer2}");
