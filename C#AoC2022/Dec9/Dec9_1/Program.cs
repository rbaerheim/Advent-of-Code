using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
// int totalScore = 0;

int TAIL_X = 0;
int TAIL_Y = 0;

int HEAD_X = 0;
int HEAD_Y = 0;

int testCounter = 0;

var visitedCoordinates = new Dictionary<(int, int), int>() { { (TAIL_X, TAIL_Y), 1 } };

int movement;

string direction;


// Looping through the input and reading the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    testCounter += 1;
    // Trim away newlines etc
    line.Trim();
    string[] words = line.Split(" ");
    direction = words[0];
    movement = Int32.Parse(words[1].ToString());

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

    /*
    if (testCounter == 1)
    {
        Console.WriteLine($"Last direction: {direction}");
        Console.WriteLine($"Last movement steps: {movement}");
        foreach (KeyValuePair<(int, int), int> kvp in visitedCoordinates)
        {
            Console.WriteLine($"KEY: {kvp.Key.ToString()} Value: {kvp.Value}");
        }
        break;
    }
    */
}

Console.WriteLine(visitedCoordinates.Count());
// Prints the totalScore to console
// Console.WriteLine(totalScore);

// Stops the benchmarking and prints it to the console.
watch.Stop();
// Console.WriteLine(watch.ElapsedMilliseconds);