using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

var path = @"input.txt";

var enumLines = File.ReadLines(path, Encoding.UTF8);

var cities = new Dictionary<string, int>(){
    {"AX", 0},
    {"AY", 0},
    {"AZ", 0},
    {"BX", 0},
    {"BY", 0},
    {"BZ", 0},
    {"CX", 0},
    {"CY", 0},
    {"CZ", 0}
};

int totalScore = 0;

foreach (string line in enumLines)
{
    string str = Regex.Replace(line, @"\s", "");

    if (str.EndsWith("X"))
    {
        if (str.StartsWith("A"))
        {
            str = Regex.Replace(str, ".$", "Z");
        }
        else if (str.StartsWith("B"))
        {
            str = Regex.Replace(str, ".$", "X");
        }
        else
        {
            str = Regex.Replace(str, ".$", "Y");
        }
    }
    else if (str.EndsWith("Y"))
    {
        if (str.StartsWith("A"))
        {
            str = Regex.Replace(str, ".$", "X");
        }
        else if (str.StartsWith("B"))
        {
            str = Regex.Replace(str, ".$", "Y");
        }
        else
        {
            str = Regex.Replace(str, ".$", "Z");
        }
    }
    else
    {
        if (str.StartsWith("A"))
        {
            str = Regex.Replace(str, ".$", "Y");
        }
        else if (str.StartsWith("B"))
        {
            str = Regex.Replace(str, ".$", "Z");
        }
        else
        {
            str = Regex.Replace(str, ".$", "X");
        }
    }
    cities[str] += 1;
}

foreach (KeyValuePair<string, int> kvp in cities)
{
    if (kvp.Key == "AX")
    {
        totalScore += (kvp.Value * 4);
    }
    else if (kvp.Key == "AY")
    {
        totalScore += (kvp.Value * 8);
    }
    else if (kvp.Key == "AZ")
    {
        totalScore += (kvp.Value * 3);
    }
    else if (kvp.Key == "BX")
    {
        totalScore += (kvp.Value * 1);
    }
    else if (kvp.Key == "BY")
    {
        totalScore += (kvp.Value * 5);
    }
    else if (kvp.Key == "BZ")
    {
        totalScore += (kvp.Value * 9);
    }
    else if (kvp.Key == "CX")
    {
        totalScore += (kvp.Value * 7);
    }
    else if (kvp.Key == "CY")
    {
        totalScore += (kvp.Value * 2);
    }
    else if (kvp.Key == "CZ")
    {
        totalScore += (kvp.Value * 6);
    }
}

Console.WriteLine(totalScore); // 10560

watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 28ms