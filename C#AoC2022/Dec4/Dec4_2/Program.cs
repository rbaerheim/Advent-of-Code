using System.Text;
using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Path for the input
var path = @"input.txt";

// Reading lines in input
var enumLines = File.ReadLines(path, Encoding.UTF8);

// Total score variable
int totalScore = 0;

// Character Array on where to split the inputs
char[] delimiterChars = { ',', '-' };

// Looping through the input lines
foreach (string line in enumLines)
{
    // Trim away newlines etc
    line.Trim();

    // Splitting the input into arrays of integers
    int[] assignedIds = line.Split(delimiterChars).Select(Int32.Parse).ToArray();

    // Basic math: If x1 <= y2 && y1 <= x2 number ranges overlap.
    if (assignedIds[0] <= assignedIds[3] && assignedIds[2] <= assignedIds[1])
    {
        totalScore += 1;
    }
}

// Prints the totalScore to console
Console.WriteLine(totalScore); // 806

// Stops the benchmarking and prints it to the console.
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 50