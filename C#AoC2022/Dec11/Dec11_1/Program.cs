using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Dec11_1;

class Program
{
    static void Main(string[] args)
    {
        // Benchmarking my code
        var watch = new Stopwatch();
        watch.Start();

        // Total score variable
        int solution = 0;

        string[] monkeyArray = new string[6];

        int forEachMonkey = 0;
        List<Monkey> monkeys = new List<Monkey>();

        // Looping through the input and reading the input lines
        foreach (string line in System.IO.File.ReadLines(@"input.txt"))
        {
            if (line == "")
            {
                continue;
            }
            // Trim away newlines etc
            line.Trim();
            monkeyArray[forEachMonkey] = line;

            forEachMonkey += 1;

            if (forEachMonkey == 6)
            {
                monkeys.Add(new Monkey(
                    Int32.Parse(Regex.Match(monkeyArray[0], @"\d+").Value),
                    monkeyArray[1].Substring(monkeyArray[1].LastIndexOf(':') + 2).Split(",").Select(Int32.Parse).ToList(),
                    monkeyArray[2].Substring(monkeyArray[2].LastIndexOf('=') + 1),
                    Int32.Parse(monkeyArray[3].Substring(monkeyArray[3].LastIndexOf(' ') + 1)),
                    Int32.Parse(Regex.Match(monkeyArray[4], @"\d+").Value),
                    Int32.Parse(Regex.Match(monkeyArray[5], @"\d+").Value)
                ));
                forEachMonkey = 0;
            }

        }

        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");
        Console.WriteLine(monkeys.Count());
        // * * 
    }
}
