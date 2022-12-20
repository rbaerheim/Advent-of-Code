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
        int row = 0;

        // Total score variable
        int solution = 0;
        int[,] map = new int[numOfRows, numOfColumns];
        // Looping through the input and reading the input lines
        foreach (string line in input)
        {
            // Trim away newlines etc
            line.Trim();
            characterArray = line.ToCharArray();
            for (int column = 0; column < numOfColumns; column++)
            {
                switch (characterArray[column])
                {
                    case 'S':
                        map[row, column] = 100;
                        break;
                    case 'E':
                        map[row, column] = 1000;
                        break;
                    default:
                        map[row, column] = char.ToUpper(characterArray[column]) - 64;
                        break;
                }
                Console.Write(map[row, column] + ",");
            }
            Console.WriteLine();
            row += 1;
        }

        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");
        // * * 
    }
}