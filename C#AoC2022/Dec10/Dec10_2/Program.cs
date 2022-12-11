using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
string solution = "";

string inputCommand;

int cycle = 0;

int[] spritePositions = new int[3];

int inputArgument = 0;

string[,] CRT = new string[6, 40];

for (int col = 0; col < CRT.GetLength(0); col++)
{
    for (int row = 0; row < CRT.GetLength(1); row++)
    {
        CRT[col, row] = " ";
    }
}

int x = 1;

int startRow = 0;

// Looping through the input and reading the input lines
foreach (string inputLine in System.IO.File.ReadLines(@"input.txt"))
{
    // Trim away newlines etc
    inputLine.Trim();

    string[] inputArray = inputLine.Split(" ").ToArray();


    if (inputArray.Length == 1)
    {
        Console.WriteLine(inputArgument);
        for (int i = -1; i < 2; i++)
        {
            spritePositions[i + 1] = x + i;
            if (cycle == spritePositions[i + 1])
            {
                CRT[0, cycle] = "#";
            }
        }
        cycle += 1;

        if (CRT[0, cycle] == " ")
        {
            CRT[0, cycle] = ".";
        }


        continue;
    }


    inputCommand = inputArray[0];

    inputArgument = Int32.Parse(inputArray[1]);

    if (inputArray.Length == 2)
    {
        for (int twoCycles = 0; twoCycles < 2; twoCycles++)
        {
            for (int i = -1; i < 2; i++)
            {
                spritePositions[i + 1] = x + i;
                if (cycle == spritePositions[i + 1])
                {
                    CRT[0, cycle] = "#";
                }
            }
            cycle += 1;
            if (CRT[startRow, cycle] == " ")
            {
                CRT[startRow, cycle] = ".";
            }
        }
        for (int col = 0; col < CRT.GetLength(0); col++)
        {
            for (int row = 0; row < CRT.GetLength(1); row++)
            {
                Console.Write(CRT[col, row]);
            }
            Console.WriteLine();
        }
        x += inputArgument;
    }
}

// Stops timer and prints the solution to console and elapsed time to console
Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");

// * * 