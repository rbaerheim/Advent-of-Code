using System.Text;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Benchmarking my code
        var watch = new Stopwatch();
        watch.Start();

        // Path for the input
        var path = @"input.txt";

        // Reading lines in input
        var enumLines = File.ReadLines(path, Encoding.UTF8);

        // Total score variable
        int totalScore = 1000000000;

        // Counter for directory ID's.
        int dirID = 0;

        // Dictionary containing the ID and value of the directories.
        var dirDictionary = new Dictionary<int, int>();

        // A list containing the ID's of directories currently in use.
        var treeList = new List<int>();

        // Looping through the input lines
        foreach (string line in enumLines)
        {
            // Trim away newlines etc
            string[] inputLine = checkFirstWord(line);

            // No need for lines containing listing of items or directories.
            if (inputLine[1] == "ls" || inputLine[0] == "dir")
            {
                continue;
            }

            // Adding a counter ID to a dictionary or removing the ID if cd ..
            if (inputLine[1] == "cd")
            {

                if (inputLine[2] == "..")
                {
                    treeList.RemoveAt(treeList.Count() - 1);
                    continue;
                }
                treeList.Add(dirID);
                dirDictionary[dirID] = 0;
                dirID += 1;
                continue;
            }

            // Check if I can parse the first input value to an integer
            var isNumeric = int.TryParse(inputLine[0], out int number);

            // If so, I add the integer to all the ID's in the dictionary.
            if (isNumeric)
            {
                foreach (var directory in treeList)
                {
                    dirDictionary[directory] += number;
                }
                continue;
            }
        }

        int neededForUpdate = 30000000;
        int totalSpaceOnDisk = 70000000;
        int unUsedSpace = totalSpaceOnDisk - dirDictionary[0];
        int spaceNeededToBeFreed = neededForUpdate - unUsedSpace;

        Console.WriteLine($"Total space needed for update = {neededForUpdate}");
        Console.WriteLine($"Total space on Disk = {totalSpaceOnDisk}");
        Console.WriteLine($"Used space by '/' = {dirDictionary[0]}");
        Console.WriteLine($"Unused space = {unUsedSpace}");
        Console.WriteLine($"Space needed to be freed = {spaceNeededToBeFreed}");

        // Looping over the directories, finding the one closest to the size needed to be freed.
        foreach (KeyValuePair<int, int> kvp in dirDictionary)
        {

            if (kvp.Value > spaceNeededToBeFreed && kvp.Value < totalScore)
            {
                totalScore = kvp.Value;
            }
        }

        // Prints the answer to the console
        Console.WriteLine($"Closest size directory is {totalScore}"); // 7068748

        // Stops the benchmarking and prints it to the console.
        watch.Stop();
        Console.WriteLine($"The code took {watch.ElapsedMilliseconds} ms to run"); // 17ms

    }


    static string[] checkFirstWord(string line)
    {
        var command = line.Trim().Split(" ").ToArray();
        return command;
    }
}
