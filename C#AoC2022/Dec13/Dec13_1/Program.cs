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
        double solution = 0;

        // Counter used for every other input
        double counter = 0;
        double pairNum = 0;


        double left = 0;
        double right = 0;


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
                    left = double.Parse(lineTrimmed);
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
                    right = double.Parse(lineTrimmed);
                }
                pairNum++;
            }

            Int128 tempRight = (Int128)right;
            Int128 tempLeft = (Int128)left;

            int numRight = 0;
            int numLeft = 0;

            Console.WriteLine(left);
            Console.WriteLine(right);

            while (tempRight > 0)
            {
                tempRight = tempRight / 10;
                numRight++;
            }

            while (tempLeft > 0)
            {
                tempLeft = tempLeft / 10;
                numLeft++;
            }

            double lengthDifference = numLeft - numRight;

            if (lengthDifference > 0)
            {
                double powerOfTen = Math.Pow(10, lengthDifference);
                right = right * powerOfTen;
            }
            else if (lengthDifference < 0)
            {
                lengthDifference = Math.Abs(lengthDifference);
                double powerOfTen = Math.Pow(10, lengthDifference);
                left = left * powerOfTen;
            }


            Console.WriteLine(lengthDifference);
            Console.WriteLine(pairNum);
            Console.WriteLine($"Left: {left}, Right: {right}");
            Console.WriteLine();
            Console.WriteLine();



            if (right > left)
            {
                Console.WriteLine(pairNum);
                solution += pairNum;
            }
            // break;
        }

        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($"Solution: {solution}, Code runtime: {watch.ElapsedMilliseconds}");

        // 6828 to high
        // 5117 to low
        // 6127 to high

        // * *    SOLUTION STRING    * *
    }
}