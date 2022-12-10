using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
int totalScore = 0;

int cycle = 1;
int x = 1;
int commandValue;

// Looping through the input and reading the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Trim away newlines etc
    line.Trim();

    string[] inputLine = line.Split(" ");

    if (cycle == 1 && inputLine.Length == 2)
    {
        commandValue = Int32.Parse(inputLine[1]);
    }


    cycle += 1;

}

// Prints the totalScore to console
Console.WriteLine(totalScore);

// Stops the benchmarking and prints it to the console.
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds);