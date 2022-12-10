using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
int solution = 0;

int cycle = 1;
int x = 1;

// Looping through the input and reading the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Trim away newlines etc
    line.Trim();

    // Splits the input into an array
    string[] inputLine = line.Split(" ");

    // If there are 2 inputs in array it is an addx command
    if (inputLine.Length == 2)
    {
        // Adding cycles as an addx is two cycles
        for (int i = 0; i < 1; i++)
        {
            cycle += 1;
            // Checking if a cycle number is 20, 60, 100, 140, 180 or 220
            // which is where we are going to get the values for our solution
            if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
            {
                solution += (cycle * x);
            }
        }
        // Adding the value to x after 2 cycles
        x += Int32.Parse(inputLine[1]);
    }

    // Adds another cycle to simulate next cycle
    cycle += 1;

    // Again, checking if a cycle number is 20, 60, 100, 140, 180 or 220
    // which is where we are going to get the values for our solution
    if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
    {
        solution += (cycle * x);
    }
}

// Stops timer and prints the solution to console and elapsed time to console
Console.WriteLine($"Sum of signal strengths: {solution}, Code runtime: {watch.ElapsedMilliseconds}");

// * * Sum of signal strengths: 12540, Code runtime: 6