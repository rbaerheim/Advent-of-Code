using System.Diagnostics;
using System.Linq;

namespace Decx_y;
class Program
{
    static void Main(string[] args)
    {
        // Benchmarking my code
        var watch = new Stopwatch();
        watch.Start();

        // Reads input
        var input = System.IO.File.ReadLines(@"input.txt");

        // Variables used
        long solution = 0;

        // Counter used for every other input
        long counter = 0;
        long pairNum = 0;


        long left = 0;
        long right = 0;


        // Looping through the input and reading the input lines
        foreach (string line in input)
        {
            if (line == "")
            {
                counter = 0;
                continue;
            }
            counter++;
            // Trim away newlines etc
            string lineTrimmed = line.Trim().Replace("[", "").Replace("]", "").Replace(",", "");
            if (counter == 1)
            {
                if (lineTrimmed == "")
                {
                    left = 0;
                }
                else
                {
                    left = Int64.Parse(lineTrimmed);
                }
                continue;
            }
            else
            {
                if (lineTrimmed == "")
                {
                    right = 0;
                }
                else
                {
                    right = Int64.Parse(lineTrimmed);
                }
                pairNum++;
                if (right.ToString().Length < left.ToString().Length)
                {

                }
            }
            long lengthDifference = left.ToString().Length - right.ToString().Length;

            if (lengthDifference > 0)
            {
                long powerOfTen = (long)Math.Pow(10, lengthDifference);
                right = right * powerOfTen;
            }
            else if (lengthDifference < 0)
            {
                lengthDifference = Math.Abs(lengthDifference);
                long powerOfTen = (long)Math.Pow(10, lengthDifference);
                left = left * powerOfTen;
            }
            Console.WriteLine(pairNum);
            Console.WriteLine($"Left: {left}, Right: {right}");
            Console.WriteLine();
            Console.WriteLine();



            if (right > left)
            {
                solution += pairNum;
            }
            // break;
        }

        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($"Solution: {solution}, Code runtime: {watch.ElapsedMilliseconds}");

        // * *    SOLUTION STRING    * *
    }
}