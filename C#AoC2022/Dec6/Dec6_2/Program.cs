using System.Text;
using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Path for the input
var path = @"input.txt";

// Reading lines in input
var enumLines = File.ReadLines(path, Encoding.UTF8);

char[] testArray = new char[14];

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
        testArray[4] = charactersInInputArray[i + 4];
        testArray[5] = charactersInInputArray[i + 5];
        testArray[6] = charactersInInputArray[i + 6];
        testArray[7] = charactersInInputArray[i + 7];
        testArray[8] = charactersInInputArray[i + 8];
        testArray[9] = charactersInInputArray[i + 9];
        testArray[10] = charactersInInputArray[i + 10];
        testArray[11] = charactersInInputArray[i + 11];
        testArray[12] = charactersInInputArray[i + 12];
        testArray[13] = charactersInInputArray[i + 13];


        if (testArray.Length != testArray.Distinct().Count())
        {
            continue;
        }

        totalScore = (i + 14);
        break;
    }
}

// Prints the totalScore to console
Console.WriteLine(totalScore); // 2665

// Stops the benchmarking and prints it to the console.
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 17ms