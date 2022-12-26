using System.Diagnostics;

namespace Dec12_1;
class Program
{
    static void Main(string[] args)
    {
        // Benchmarking my code
        var watch = new Stopwatch();
        watch.Start();

        // Reads input
        var input = System.IO.File.ReadLines(@"input.txt");

        // Gets the number of rows and columns of input + 1 more in each direction
        int numOfColumns = input.First().Length + 2;
        int numOfRows = input.Count() + 2;

        // More variables used
        int row = 0;
        int currentRow = 0;
        int currentColumn = 0;
        int neighbour;
        int tempSolution;
        int whileIterator;
        (int, int, int) currentVertex;
        bool found;
        char[] characterArray = new char[numOfColumns];

        // Coordinates for checking left, up, down, right from current nodes
        var coords = new[] { (-1, 0), (0, -1), (0, 1), (1, 0) };

        // Queue, hashset and list used
        Queue<(int, int, int)> vertexQueue = new();
        HashSet<(int, int, int)> vertexHashSet = new();
        List<(int, int)> startPositionsList = new();

        // Total score variable
        int solution = 500;

        // Map for storing all letters (numbers)
        int[,] map = new int[numOfRows, numOfColumns];

        // Making arrays of zeroes which are 1 row/column longer in each direction
        // This is to make it easy to handle out of bounds errors
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfColumns; j++)
            {
                map[i, j] = 0;
            }
        }

        // Looping through the input and reading the input lines
        foreach (string line in input)
        {
            // Trim away newlines etc
            line.Trim();

            // Making the line to a chararray
            characterArray = line.ToCharArray();

            // Looping over the chararray and inserting the equivalent letter into the map array.
            // The start (S) = 1, a = 2, b = 3 ...
            // The end (E) i put as 1000.
            // Adding the a's or S to a list of starting positions.
            for (int column = 0; column < characterArray.Length; column++)
            {
                switch (characterArray[column])
                {
                    case 'S':
                        map[row + 1, column + 1] = 1;
                        currentRow = row + 1;
                        currentColumn = column + 1;
                        startPositionsList.Add((currentRow, currentColumn));
                        break;
                    case 'a':
                        map[row + 1, column + 1] = 1;
                        currentRow = row + 1;
                        currentColumn = column + 1;
                        startPositionsList.Add((currentRow, currentColumn));
                        break;
                    case 'E':
                        map[row + 1, column + 1] = 1000;
                        break;
                    default:
                        map[row + 1, column + 1] = char.ToUpper(characterArray[column]) - 64;
                        break;
                }
            }
            row++;
        }
        for (int startPosition = 0; startPosition < startPositionsList.Count(); startPosition++)
        {
            // Sets all counters to zero, found to false, clears the queue and hashset and starts from the next position.
            whileIterator = 0;
            tempSolution = 0;
            found = false;
            vertexQueue.Clear();
            vertexHashSet.Clear();

            // Adding the start vertex value and coordinates to queue and hashset
            vertexQueue.Enqueue((startPositionsList[startPosition].Item1, startPositionsList[startPosition].Item2, map[startPositionsList[startPosition].Item1, startPositionsList[startPosition].Item2]));
            vertexHashSet.Add((startPositionsList[startPosition].Item1, startPositionsList[startPosition].Item2, map[startPositionsList[startPosition].Item1, startPositionsList[startPosition].Item2]));

            // While the goal is not found
            while (!found)
            {
                // Variable to help counting the tree levels
                int queueCount = vertexQueue.Count();

                // Looping the tree levels
                for (int j = 0; j < queueCount; j++)
                {
                    // Checking next vertex in the queue
                    currentVertex = vertexQueue.Dequeue();

                    // Looping over the neighboring vertices
                    for (int i = 0; i < coords.Length; i++)
                    {
                        neighbour = map[(currentVertex.Item1 + coords[i].Item1), (currentVertex.Item2 + coords[i].Item2)];

                        // If vertex value is 1000, set found to true.
                        if (neighbour == 1000)
                        {
                            found = true;
                        }

                        // If neighboring vertex is less than current vertex or 1 bigger, add the coordinate and value to queue
                        if ((neighbour <= currentVertex.Item3 || neighbour == currentVertex.Item3 + 1) && neighbour != 0)
                        {
                            // If the tuple can be added to a hashset it is unvisited and can be added to queue.
                            if (vertexHashSet.Add((currentVertex.Item1 + coords[i].Item1, currentVertex.Item2 + coords[i].Item2, neighbour)))
                            {
                                vertexQueue.Enqueue((currentVertex.Item1 + coords[i].Item1, currentVertex.Item2 + coords[i].Item2, neighbour));
                            }
                        }
                    }
                }
                // Adding one for each "tree" level into the map towards the goal
                tempSolution++;
                whileIterator++;

                // No point in continuing if the number of steps are the same or going beyond the current minimum.
                if (whileIterator >= solution)
                {
                    found = true;
                }
            }

            // Saving the lowest counter.
            if (tempSolution < solution)
            {
                solution = tempSolution;
            }
        }
        // Stops timer and prints the solution to console and elapsed time to console
        Console.WriteLine($"Shortest number of steps: {solution}, Code runtime: {watch.ElapsedMilliseconds}");

        // * *    Shortest number of steps: 504, Code runtime: 23    * *
    }
}