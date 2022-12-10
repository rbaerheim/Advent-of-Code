using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
int totalScore = 0;

// Variables for the coordinates of the knots on the rope
int TAIL_X = 0;
int TAIL_Y = 0;
int HEAD_X = 0;
int HEAD_Y = 0;

// Dictionary containing the visited coordinates
var visitedCoordinates = new Dictionary<(int, int), int>() { { (TAIL_X, TAIL_Y), 1 } };

// Variables to store the inputs
int movement;
string direction;


// Looping through the input and reading the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Trim away newlines etc
    line.Trim();

    // Split input into a string array and getting the values in variables
    string[] words = line.Split(" ");
    direction = words[0];
    movement = Int32.Parse(words[1].ToString());

    // Switch/Case for checking if rope i pulled up, down, right or left.
    switch (direction)
    {
        case "U":
            if (TAIL_Y > HEAD_Y)
            {
                HEAD_Y += movement;
                for (int i = 0; i < movement - 2; i++)
                {
                    if (TAIL_X < HEAD_X)
                    {
                        TAIL_X += 1;
                    }
                    else if (TAIL_X > HEAD_X)
                    {
                        TAIL_X -= 1;
                    }
                    TAIL_Y += 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_Y == HEAD_Y)
            {
                HEAD_Y += movement;
                for (int i = 0; i < movement - 1; i++)
                {
                    if (TAIL_X < HEAD_X)
                    {
                        TAIL_X += 1;
                    }
                    else if (TAIL_X > HEAD_X)
                    {
                        TAIL_X -= 1;
                    }
                    TAIL_Y += 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_Y < HEAD_Y)
            {
                HEAD_Y += movement;
                for (int i = 0; i < movement; i++)
                {
                    if (TAIL_X < HEAD_X)
                    {
                        TAIL_X += 1;
                    }
                    else if (TAIL_X > HEAD_X)
                    {
                        TAIL_X -= 1;
                    }
                    TAIL_Y += 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            break;
        case "D":
            if (TAIL_Y < HEAD_Y)
            {
                HEAD_Y -= movement;
                for (int i = 0; i < movement - 2; i++)
                {
                    if (TAIL_X < HEAD_X)
                    {
                        TAIL_X += 1;
                    }
                    else if (TAIL_X > HEAD_X)
                    {
                        TAIL_X -= 1;
                    }
                    TAIL_Y -= 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_Y == HEAD_Y)
            {
                HEAD_Y -= movement;
                for (int i = 0; i < movement - 1; i++)
                {
                    if (TAIL_X < HEAD_X)
                    {
                        TAIL_X += 1;
                    }
                    else if (TAIL_X > HEAD_X)
                    {
                        TAIL_X -= 1;
                    }
                    TAIL_Y -= 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_Y > HEAD_Y)
            {
                HEAD_Y -= movement;
                for (int i = 0; i < movement; i++)
                {
                    if (TAIL_X < HEAD_X)
                    {
                        TAIL_X += 1;
                    }
                    else if (TAIL_X > HEAD_X)
                    {
                        TAIL_X -= 1;
                    }
                    TAIL_Y -= 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            break;
        case "L":
            if (TAIL_X < HEAD_X)
            {
                HEAD_X -= movement;
                for (int i = 0; i < movement - 2; i++)
                {
                    if (TAIL_Y < HEAD_Y)
                    {
                        TAIL_Y += 1;
                    }
                    else if (TAIL_Y > HEAD_Y)
                    {
                        TAIL_Y -= 1;
                    }
                    TAIL_X -= 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_X == HEAD_X)
            {
                HEAD_X -= movement;
                for (int i = 0; i < movement - 1; i++)
                {
                    if (TAIL_Y < HEAD_Y)
                    {
                        TAIL_Y += 1;
                    }
                    else if (TAIL_Y > HEAD_Y)
                    {
                        TAIL_Y -= 1;
                    }
                    TAIL_X -= 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_X > HEAD_X)
            {
                HEAD_X -= movement;
                for (int i = 0; i < movement; i++)
                {
                    if (TAIL_Y < HEAD_Y)
                    {
                        TAIL_Y += 1;
                    }
                    else if (TAIL_Y > HEAD_Y)
                    {
                        TAIL_Y -= 1;
                    }
                    TAIL_X -= 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            break;
        case "R":
            if (TAIL_X < HEAD_X)
            {
                HEAD_X += movement;
                for (int i = 0; i < movement; i++)
                {
                    if (TAIL_Y < HEAD_Y)
                    {
                        TAIL_Y += 1;
                    }
                    else if (TAIL_Y > HEAD_Y)
                    {
                        TAIL_Y -= 1;
                    }
                    TAIL_X += 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_X == HEAD_X)
            {
                HEAD_X += movement;
                for (int i = 0; i < movement - 1; i++)
                {
                    if (TAIL_Y < HEAD_Y)
                    {
                        TAIL_Y += 1;
                    }
                    else if (TAIL_Y > HEAD_Y)
                    {
                        TAIL_Y -= 1;
                    }
                    TAIL_X += 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            else if (TAIL_X > HEAD_X)
            {
                HEAD_X += movement;
                for (int i = 0; i < movement - 2; i++)
                {
                    if (TAIL_Y < HEAD_Y)
                    {
                        TAIL_Y += 1;
                    }
                    else if (TAIL_Y > HEAD_Y)
                    {
                        TAIL_Y -= 1;
                    }
                    TAIL_X += 1;
                    if (!visitedCoordinates.ContainsKey((TAIL_X, TAIL_Y)))
                    {
                        visitedCoordinates[(TAIL_X, TAIL_Y)] = 0;
                    }
                    visitedCoordinates[(TAIL_X, TAIL_Y)] += 1;
                }
            }
            break;
    }
}

// Stops timer and prints the totalScore to console and elapsed time to console
totalScore = visitedCoordinates.Count();
Console.WriteLine($"TCoordinates visited by the tail: {totalScore}, Code runtime: {watch.ElapsedMilliseconds}");

// * * TCoordinates visited by the tail: 6044, Code runtime: 16