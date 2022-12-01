using System.Text;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

var path = @"input.txt";

var enumLines = File.ReadLines(path, Encoding.UTF8);

int temp = 0;
int max = 0;

foreach (string line in enumLines)
{
    line.Trim();
    if (string.IsNullOrEmpty(line))
    {
        if (temp > max)
        {
            max = temp;
        }
        temp = 0;
        continue;
    }
    temp += Int32.Parse(line);
}

Console.WriteLine(max); // 69626

watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 25ms