using System.Text;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

var path = @"input.txt";

var enumLines = File.ReadLines(path, Encoding.UTF8);

int[] maxArray = new int[3];
int temp = 0;

foreach (string line in enumLines)
{
    line.Trim();
    if (string.IsNullOrEmpty(line))
    {
        for (int i = 0; i < maxArray.Length; i++)
        {
            if (temp > maxArray[i])
            {
                maxArray[i] = temp;
                Array.Sort(maxArray);
                break;
            }
        }
        temp = 0;
        continue;
    }
    temp += Int32.Parse(line);
}
Console.WriteLine(maxArray.Sum()); // 206780

watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 27ms