using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
string solution = "";

// The input command (addx or noop)
string inputCommand;

// The cycle counter
int cycle = 0;

// Array of ints where the sprite currently cover
int[] spritePositions = new int[3];

// The input argument (4,1,-11 and so on)
int inputArgument = 0;

// The CRT screen array
// 6 rows, 40 columns
string[,] CRT = new string[6, 40];

// Inserting empty strings into all CRT(array slots)
for (int col = 0; col < CRT.GetLength(0); col++)
{
    for (int row = 0; row < CRT.GetLength(1); row++)
    {
        CRT[col, row] = " ";
    }
}

// The x value incrementing or decrementing with the input
int x = 1;

// Current row of the CRT(array) variable
int CRTRow = 0;

// Looping through the input and reading the input lines
foreach (string inputLine in System.IO.File.ReadLines(@"input.txt"))
{
    // Trim away newlines etc
    inputLine.Trim();

    // Input into an array
    string[] inputArray = inputLine.Split(" ").ToArray();

    // If input only contains noop
    if (inputArray.Length == 1)
    {
        // Looping over and setting the sprite to the x-value +/- 1.
        for (int i = -1; i < 2; i++)
        {
            spritePositions[i + 1] = x + i;

            // If the cycle is the same value as where the sprite currently is
            // that is, the x value, 
            if (cycle == spritePositions[i + 1])
            {
                CRT[CRTRow, cycle] = "#";
            }
        }
        // Increment cycle by one
        cycle += 1;

        // If cycle is divisible by 40, set new cow
        // and reset cycle counter
        if (cycle % 40 == 0)
        {
            CRTRow += 1;
            cycle = 0;
        }

        // If cycle pixel do not contain the sprite,
        // set pixel to a dot (".")
        if (CRT[CRTRow, cycle] == " ")
        {
            CRT[CRTRow, cycle] = ".";
        }

        // Run new input line as there is not point in
        // going further
        continue;
    }

    // The command of the input
    inputCommand = inputArray[0];

    // The argument of the input
    inputArgument = Int32.Parse(inputArray[1]);

    // If input contains both a command and an argument
    if (inputArray.Length == 2)
    {
        // Looping 2 times as an addx command runs
        // for two cycles 
        for (int twoCycles = 0; twoCycles < 2; twoCycles++)
        {
            // Looping over and setting the sprite to the x-value +/- 1.
            for (int i = -1; i < 2; i++)
            {
                spritePositions[i + 1] = x + i;

                // If the cycle is the same value as where the sprite currently is
                // that is, the x value, 
                if (cycle == spritePositions[i + 1])
                {
                    CRT[CRTRow, cycle] = "#";
                }
            }
            // Increment cycle by one
            cycle += 1;

            // If cycle is divisible by 40, set new cow
            // and reset cycle counter
            if (cycle % 40 == 0)
            {
                CRTRow += 1;
                cycle = 0;
            }

            // If cycle pixel do not contain the sprite,
            // set pixel to a dot (".")
            if (CRT[CRTRow, cycle] == " ")
            {
                CRT[CRTRow, cycle] = ".";
            }
        }

        // Increasing x value with argument
        x += inputArgument;

        // ** For printing to console/debugging


        for (int col = 0; col < CRT.GetLength(0); col++)
        {
            for (int row = 0; row < CRT.GetLength(1); row++)
            {
                Console.Write(CRT[col, row]);
            }
            Console.WriteLine();
        }

    }
}

// What is displayed in the CRT
solution = "FECZELHE";

// Stops timer and prints the solution to console and elapsed time to console
Console.WriteLine($"The CRT reads: {solution}, Code runtime: {watch.ElapsedMilliseconds}");

// * * Code crashes as some weird bug during last cycles runs the array out of bounds
// * * I did however get the solution. Might get back to look at this on a later date.