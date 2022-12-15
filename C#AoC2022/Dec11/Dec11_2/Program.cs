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

        // Array to store the input lines
        string[] monkeyArray = new string[6];

        // variables needed
        Int64 forEachMonkey = 0;
        Int64 lcm = 1;
        Int64 value1;
        Int64 value2;
        Int64 monkeyCurrentCount;
        Int64 monkeyIdToReceiveItem;
        Int64 itemToSwitchHands;

        // List for the monkey objects
        List<Monkey> monkeys = new List<Monkey>();

        // Looping through the input and reading the input lines
        foreach (string line in System.IO.File.ReadLines(@"input.txt"))
        {
            //Continuing if empty line
            if (line == "")
            {
                continue;
            }
            // Trim away newlines etc
            line.Trim();

            // Appending the line to the array
            monkeyArray[forEachMonkey] = line;

            // Variable to keep track of each line
            forEachMonkey += 1;

            // If 6 lines in the array, make a new monkey object
            if (forEachMonkey == 6)
            {
                Monkey newMonkey = new Monkey(
                    Int64.Parse(Regex.Match(monkeyArray[0], @"\d+").Value),
                    monkeyArray[2].Substring(monkeyArray[2].LastIndexOf('=') + 2).Split(" ").ToArray(),
                    Int32.Parse(monkeyArray[3].Substring(monkeyArray[3].LastIndexOf(' ') + 1)),
                    Int64.Parse(Regex.Match(monkeyArray[4], @"\d+").Value),
                    Int64.Parse(Regex.Match(monkeyArray[5], @"\d+").Value)
                );

                // Getting the least common multiple of all the monkey Test(divisible by)
                lcm *= newMonkey.Test;

                // Appending the item values to the list of monkey items
                foreach (var item in monkeyArray[1].Substring(monkeyArray[1].LastIndexOf(':') + 2).Split(",").Select(Int64.Parse).ToList())
                {
                    newMonkey.addToCurrentItems(item);
                }

                // Adding the monkey object to the monkeys list
                monkeys.Add(newMonkey);

                // Set counter to zero for start new monkey object
                forEachMonkey = 0;
            }

            // If all monkeys in input file have been added
            if (monkeys.Count() < 8)
            {
                continue;
            }

            // Looping for 10000 rounds
            for (Int64 round = 0; round < 10000; round++)
            {

                // Each monkey takes its turn
                for (Int64 numberOfMonkeys = 0; numberOfMonkeys < monkeys.Count(); numberOfMonkeys++)
                {
                    // Sets the current monkey to the loop variable to loop though them all
                    Monkey currentMonkey = monkeys.Where(monkey => monkey.Id == numberOfMonkeys).First();

                    // Number of items in the list currently contained by the monkey in question
                    monkeyCurrentCount = currentMonkey.CurrentItems.Count();

                    // Looping over the items from front to back
                    for (var item = monkeyCurrentCount; item > 0; item--)
                    {
                        currentMonkey.inspectedItems += 1;

                        // Checks if operation should include the old value in one or both of values
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

                        // Getting the new value after the operation on the item
                        itemToSwitchHands = currentMonkey.operationOnItem(currentMonkey, 0, value1, currentMonkey.Operation[1], value2, lcm);

                        // Checking which monkeyId should receive the item
                        monkeyIdToReceiveItem = currentMonkey.test(currentMonkey.getValue(0), currentMonkey.Test);

                        // Getting the monkey with the monkey ID from previous
                        Monkey monkeyToReceive = monkeys.Where(monkey => monkey.Id == monkeyIdToReceiveItem).First();

                        // Adding the item to the receiving monkey
                        monkeyToReceive.addToCurrentItems(itemToSwitchHands);

                        // Removing the item from the monkey that had it before
                        currentMonkey.removeFromCurrentItems(itemToSwitchHands);
                    }
                }
            }
        }

        // List for the count of all inspected items by all monkeys
        List<Int64> inspectedNumberList = new List<Int64>();

        // Looping over the monkey objects, getting the inspected items number and adding them to inspectedNumberList
        foreach (Monkey monkey in monkeys)
        {
            inspectedNumberList.Add(monkey.inspectedItems);
        }

        // Sort the list in ascending order.
        inspectedNumberList.Sort();

        // Getting the product of the two highest counts
        solution = inspectedNumberList[inspectedNumberList.Count() - 1] * inspectedNumberList[inspectedNumberList.Count() - 2];

        // Stops timer and prints the solution and elapsed time to console
        Console.WriteLine($"The two most inspecting monkeys inspected the items (multiplied together) {solution} times, Code runtime: {watch.ElapsedMilliseconds} ms.");
        // * * The two most inspecting monkeys inspected the items (multiplied together) 30599555965 times, Code runtime: 319 ms.
    }
}
