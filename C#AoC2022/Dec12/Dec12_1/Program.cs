using System.Diagnostics;

namespace Dec12_1;
// Benchmarking my code
class Program
{
    static void Main(string[] args)
    {

        var watch = new Stopwatch();
        watch.Start();
        var input = System.IO.File.ReadLines(@"input.txt");
        int numOfColumns = input.First().Length;
        int numOfRows = input.Count();

        char[] characterArray = new char[numOfColumns];
        int counter = 0;
        // Total score variable
        int solution = 0;
        int[,] map = new int[numOfRows, numOfColumns];
        // Looping through the input and reading the input lines
        foreach (string line in input)
        {
            // Trim away newlines etc
            line.Trim();
            characterArray = line.ToCharArray();
            for (int i = 0; i < numOfColumns; i++)
            {
                switch (characterArray[i])
                {
                    case 'S':
                        map[counter, i] = 100;
                        break;
                    case 'E':
                        map[counter, i] = 1000;
                        break;
                    default:
                        map[counter, i] = char.ToUpper(characterArray[i]) - 64;
                        break;
                }
            }
            counter += 1;
            // Stops timer and prints the solution to console and elapsed time to console
            Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");
        }
        Console.WriteLine(map[1, 1]);
        // * * 
    }
}