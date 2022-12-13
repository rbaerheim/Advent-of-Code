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
        int value1;
        int value2;
        int monkeyCurrentCount;
        int monkeyIdToReceiveItem;
        int itemToSwitchHands;



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
                    Int32.Parse(Regex.Match(monkeyArray[0], @"\d+").Value),
                    monkeyArray[2].Substring(monkeyArray[2].LastIndexOf('=') + 2).Split(" ").ToArray(),
                    Int32.Parse(monkeyArray[3].Substring(monkeyArray[3].LastIndexOf(' ') + 1)),
                    Int32.Parse(Regex.Match(monkeyArray[4], @"\d+").Value),
                    Int32.Parse(Regex.Match(monkeyArray[5], @"\d+").Value)
                );

                foreach (var item in monkeyArray[1].Substring(monkeyArray[1].LastIndexOf(':') + 2).Split(",").Select(Int32.Parse).ToList())
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

            for (int round = 0; round < 10000; round++)
            {
                if (round == 1 || round == 20 || round == 1000)
                {
                    foreach (Monkey monkey in monkeys)
                    {
                        Console.WriteLine(monkey.inspectedItems);
                    }
                    Console.WriteLine();
                }
                for (int numberOfMonkeys = 0; numberOfMonkeys < monkeys.Count(); numberOfMonkeys++)
                {
                    Monkey currentMonkey = monkeys.Where(monkey => monkey.Id == numberOfMonkeys).First();

                    monkeyCurrentCount = currentMonkey.CurrentItems.Count();
                    for (var item = monkeyCurrentCount; item > 0; item--)
                    {
                        currentMonkey.inspectedItems += 1;

                        if (currentMonkey.Operation[0] == "old")
                        {
                            value1 = currentMonkey.getValue(0);
                        }
                        else
                        {
                            value1 = Int32.Parse(currentMonkey.Operation[0]);
                        }
                        if (currentMonkey.Operation[2] == "old")
                        {
                            value2 = currentMonkey.getValue(0);
                        }
                        else
                        {
                            value2 = Int32.Parse(currentMonkey.Operation[2]);
                        }
                        itemToSwitchHands = currentMonkey.operationOnItem(currentMonkey, 0, value1, currentMonkey.Operation[1], value2);

                        monkeyIdToReceiveItem = currentMonkey.test(currentMonkey.getValue(0), currentMonkey.Test);

                        Monkey monkeyToReceive = monkeys.Where(monkey => monkey.Id == monkeyIdToReceiveItem).First();

                        monkeyToReceive.addToCurrentItems(itemToSwitchHands);

                        currentMonkey.removeFromCurrentItems(itemToSwitchHands);
                    }
                }
            }
        }

        List<int> inspectedNumberList = new List<int>();

        foreach (Monkey monkey in monkeys)
        {
            inspectedNumberList.Add(monkey.inspectedItems);
        }

        inspectedNumberList.Sort();

        solution = inspectedNumberList[inspectedNumberList.Count() - 1] * inspectedNumberList[inspectedNumberList.Count() - 2];

        // 2067503700 to low

        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");
        // * * 
    }
}
