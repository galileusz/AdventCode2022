// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var _filepath = "../../../../day_08_data.txt";
var dataFile = File.ReadAllLines(_filepath).ToArray();

var forest = dataFile.Select(x => x.Select(y => (int)y - 48).ToArray()).ToArray();

var visibleTrees = 0;
var maxScenicScore = 0;
var currentScenicScore = 0;
for (int i = 0; i < forest.Length; i++)
{
    for (int j = 0; j < forest.First().Length; j++)
    {
        if (IsTreeVisible(i, j, forest, out currentScenicScore))
            visibleTrees++;
        if (currentScenicScore > maxScenicScore)
            maxScenicScore = currentScenicScore;
    }
}

var answer1 = visibleTrees;

Console.WriteLine($"\nAnswer 1: {answer1}");

var answer2 = maxScenicScore;

Console.WriteLine($"\nAnswer 2: {answer2}");

bool IsTreeVisible(int i, int j, int[][] forest, out int scenicScore)
{
    bool leftHide = false;
    bool rightHide = false;
    bool topHide = false;
    bool bottomHide = false;
    int leftScore = 0;
    int rightScore = 0;
    int topScore = 0;
    int bottomScore = 0;

    for (int k = j - 1; k >= 0; k--)
    {
        leftScore++;
        if (forest[i][j] <= forest[i][k])
        {
            leftHide = true;
            break;
        }
    }
    for (int k = j + 1; k < forest.First().Length; k++)
    {
        rightScore++;
        if (forest[i][j] <= forest[i][k])
        {
            rightHide = true;
            break;
        }
    }
    for (int k = i - 1; k >= 0; k--)
    {
        topScore++;
        if (forest[i][j] <= forest[k][j])
        {
            topHide = true;
            break;
        }
    }
    for (int k = i + 1; k < forest.Length; k++)
    {
        bottomScore++;
        if (forest[i][j] <= forest[k][j])
        {
            bottomHide = true;
            break;
        }
    }
    scenicScore = leftScore * rightScore * topScore * bottomScore;
    return !(leftHide && rightHide && topHide && bottomHide);
}
