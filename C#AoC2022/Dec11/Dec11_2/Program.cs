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
        Int64 solution = 0;

        string[] monkeyArray = new string[6];

        Int64 forEachMonkey = 0;
        Int64 value1;
        Int64 value2;
        Int64 monkeyCurrentCount;
        Int64 monkeyIdToReceiveItem;
        Int64 itemToSwitchHands;
        Int64 gcd;



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
                Monkey newMonkey = new Monkey(
                    Int64.Parse(Regex.Match(monkeyArray[0], @"\d+").Value),
                    monkeyArray[2].Substring(monkeyArray[2].LastIndexOf('=') + 2).Split(" ").ToArray(),
                    Int64.Parse(Regex.Match(monkeyArray[4], @"\d+").Value),
                    Int64.Parse(Regex.Match(monkeyArray[5], @"\d+").Value)
                );

                foreach (var item in monkeyArray[1].Substring(monkeyArray[1].LastIndexOf(':') + 2).Split(",").Select(Int64.Parse).ToList())
                {
                    newMonkey.addToCurrentItems(item);
                }
                monkeys.Add(newMonkey);
                forEachMonkey = 0;
            }
            if (monkeys.Count() < 4)
            {
                continue;
            }

            for (Int64 round = 0; round < 1; round++)
            {
                /*
                if (round == 1 || round == 20 || round == 1000)
                {
                    foreach (Monkey monkey in monkeys)
                    {
                        Console.WriteLine(monkey.inspectedItems);
                    }
                    Console.WriteLine();
                }
                */
                for (Int64 numberOfMonkeys = 0; numberOfMonkeys < monkeys.Count(); numberOfMonkeys++)
                {
                    Monkey currentMonkey = monkeys.Where(monkey => monkey.Id == numberOfMonkeys).First();

                    monkeyCurrentCount = currentMonkey.CurrentItems.Count();

                    gcd = currentMonkey.getGCD(currentMonkey);

                    for (var item = monkeyCurrentCount; item > 0; item--)
                    {
                        currentMonkey.inspectedItems += 1;

                        if (currentMonkey.Operation[0] == "old")
                        {
                            value1 = currentMonkey.getValue(0);
                        }
                        else
                        {
                            value1 = Int64.Parse(currentMonkey.Operation[0]);
                        }
                        if (currentMonkey.Operation[2] == "old")
                        {
                            value2 = currentMonkey.getValue(0);
                        }
                        else
                        {
                            value2 = Int64.Parse(currentMonkey.Operation[2]);
                        }
                        itemToSwitchHands = currentMonkey.operationOnItem(currentMonkey, 0, value1, currentMonkey.Operation[1], value2);

                        monkeyIdToReceiveItem = currentMonkey.test(currentMonkey.getValue(0), gcd);

                        Monkey monkeyToReceive = monkeys.Where(monkey => monkey.Id == monkeyIdToReceiveItem).First();

                        monkeyToReceive.addToCurrentItems(itemToSwitchHands);

                        currentMonkey.removeFromCurrentItems(itemToSwitchHands);
                    }
                }
            }
        }

        List<Int64> inspectedNumberList = new List<Int64>();

        foreach (Monkey monkey in monkeys)
        {
            inspectedNumberList.Add(monkey.inspectedItems);
            Console.WriteLine(monkey.inspectedItems);
        }

        inspectedNumberList.Sort();

        solution = inspectedNumberList[inspectedNumberList.Count() - 1] * inspectedNumberList[inspectedNumberList.Count() - 2];

        // 2067503700 to low

        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");
        // * * 
    }
}
