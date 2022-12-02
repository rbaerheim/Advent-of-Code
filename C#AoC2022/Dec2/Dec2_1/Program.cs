using System.Text;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

var path = @"input.txt";

var enumLines = File.ReadLines(path, Encoding.UTF8);

var cities = new Dictionary<string, int>(){
    {"A X", 0},
    {"A Y", 0},
    {"A Z", 0},
    {"B X", 0},
    {"B Y", 0},
    {"B Z", 0},
    {"C X", 0},
    {"C Y", 0},
    {"C Z", 0}
};

int totalScore = 0;

foreach (string line in enumLines)
{
    line.Trim();
    cities[line] += 1;
}

foreach (KeyValuePair<string, int> kvp in cities)
{
    if (kvp.Key == "A X")
    {
        totalScore += (kvp.Value * 4);
    }
    else if (kvp.Key == "A Y")
    {
        totalScore += (kvp.Value * 8);
    }
    else if (kvp.Key == "A Z")
    {
        totalScore += (kvp.Value * 3);
    }
    else if (kvp.Key == "B X")
    {
        totalScore += (kvp.Value * 1);
    }
    else if (kvp.Key == "B Y")
    {
        totalScore += (kvp.Value * 5);
    }
    else if (kvp.Key == "B Z")
    {
        totalScore += (kvp.Value * 9);
    }
    else if (kvp.Key == "C X")
    {
        totalScore += (kvp.Value * 7);
    }
    else if (kvp.Key == "C Y")
    {
        totalScore += (kvp.Value * 2);
    }
    else if (kvp.Key == "C Z")
    {
        totalScore += (kvp.Value * 6);
    }
}

Console.WriteLine(totalScore); // 9651

watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 15ms