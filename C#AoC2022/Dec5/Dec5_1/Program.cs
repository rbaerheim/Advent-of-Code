using System.Text;
using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Path for the input
var path = @"input.txt";

// Reading lines in input
var enumLines = File.ReadLines(path).Skip(10);

// Total score variable
int totalScore = 0;

// List of words
List<string> wordList = new List<string> { "wbdncfj", "pzvqlst", "pzbgjt", "dtljzbhc", "gvbjs", "psq", "bvdflmpn", "psmfbdlr", "vdtr" };

// Looping through the input lines
foreach (string line in enumLines)
{
    // Trim away newlines etc
    line.Trim();
    string[] instruction = line.Split(" ").ToArray();

    string boxesToMove = instruction[1];
    string moveFrom = instruction[3];
    string moveTo = instruction[5];

    string stringToMoveFrom = wordList[moveFrom]

    break;
}

// Prints the totalScore to console
Console.WriteLine(totalScore);

// Stops the benchmarking and prints it to the console.
watch.Stop();
// Console.WriteLine(watch.ElapsedMilliseconds);