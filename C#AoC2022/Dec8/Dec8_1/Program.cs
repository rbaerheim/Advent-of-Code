using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Variable where the answer is stored
int totalScore = 0;

// Finding the length and height of the array
int rowLength = File.ReadLines(@"input.txt").First().Length;
int colLength = File.ReadLines(@"input.txt").Count();

// 2D array for storing the input
int[,] treeArray = new int[rowLength, colLength];

// A an array for checking the values in the Y-axis
int[] colCountingArray = new int[rowLength];

// Variables for checking the max value when iterating over a row
int rowMax = 0;
int rowCurrent = 0;

// Variables for inserting the row and column values into treeArray.
int row = 0;
int column = 0;

// A hashset for storing the co-ordinates of the values needed for the answer.
HashSet<string> setOfTreesCoordinates = new HashSet<string>();

// Looping through the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Setting the column variable to zero when starting a new row iteration
    column = 0;

    // Trim away newlines etc
    char[] charArray = line.Trim().ToCharArray();

    // Looping over the columns of the rows, inserting them into the 2D array.
    for (int i = 0; i < charArray.Length; i++)
    {
        treeArray[row, column] = (int)Char.GetNumericValue(charArray[i]);
        column += 1;
    }

    row += 1;

    // Continuing if done with the input rows
    if (row < rowLength)
    {
        continue;
    }

    // Loop over the array rows
    for (int r = 0; r < row; r++)
    {
        // Loop over the array columns
        for (int c = 0; c < column; c++)
        {
            // If first tree in row, set that as the max height and add to a tree that can be seen
            // * * From left -> right:
            if (c == 0)
            {
                rowMax = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
                continue;
            }
            // If a row tree is larger than the current max, it can be seen - add the co-ordinate to the hashmap.
            else if (treeArray[r, c] > rowMax)
            {
                rowMax = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
            }
            // Using another array to find the tree sizes y-axis.
            // * * From top -> bottom.
            if (r == 0)
            {
                colCountingArray[c] = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
            }
            else
            {
                if (treeArray[r, c] > colCountingArray[c])
                {
                    colCountingArray[c] = treeArray[r, c];
                    setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
                }
            }
        }

        // * * From right -> left
        for (int c = rowLength - 1; c >= 0; c--)
        {
            if (c == rowLength - 1)
            {
                rowMax = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
                continue;
            }
            else
            {
                rowCurrent = treeArray[r, c];
            }
            if (rowCurrent > rowMax)
            {
                rowMax = rowCurrent;
                setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
            }
        }
    }
    // * * From bottom -> top
    for (int r = rowLength - 1; r >= 0; r--)
    {
        for (int c = 0; c < column; c++)
        {
            if (r == rowLength - 1)
            {
                colCountingArray[c] = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
            }
            else
            {
                if (treeArray[r, c] > colCountingArray[c])
                {
                    colCountingArray[c] = treeArray[r, c];
                    setOfTreesCoordinates.Add(r.ToString() + " " + c.ToString());
                }
            }
        }
    }
}

// Stops timer and prints the totalScore to console and elapsed time to console
totalScore = setOfTreesCoordinates.Count();
watch.Stop();
Console.WriteLine($"Trees that can be seen: {totalScore}, Code runtime: {watch.ElapsedMilliseconds}");

// * * Trees that can be seen: 1845, Code runtime: 6