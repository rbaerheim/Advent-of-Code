using System.Text;
using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Path for the input
var path = @"input.txt";

// Reading lines in input
var enumLines = File.ReadLines(path, Encoding.UTF8);

char[] testArray = new char[4];

// Total score variable
int totalScore = 0;

// Looping through the input lines
foreach (string line in enumLines)
{
    // Trim away newlines etc
    line.Trim();

    // Splitting the input characters into a character array
    char[] charactersInInputArray = line.ToCharArray();

    // Looping though the characters replacing the old ones until I get an array containing distinct characters
    for (var i = 0; i < charactersInInputArray.Length; i++)
    {
        testArray[0] = charactersInInputArray[i];
        testArray[1] = charactersInInputArray[i + 1];
        testArray[2] = charactersInInputArray[i + 2];
        testArray[3] = charactersInInputArray[i + 3];

        if (testArray.Length != testArray.Distinct().Count())
        {
            continue;
        }

        totalScore = (i + 4);
        break;
    }
}

// Prints the totalScore to console
Console.WriteLine(totalScore); // 1655

// Stops the benchmarking and prints it to the console.
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 15ms