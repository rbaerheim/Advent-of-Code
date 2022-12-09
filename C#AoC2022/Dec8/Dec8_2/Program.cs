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
int[] topRow = new int[rowLength];
int[] bottomRow = new int[rowLength];


// Variables for checking the max value when iterating over a rowNum
int tempScore = 0;
int currentTree = 0;

// Variables for calculating scenic scores
int scoreLeft = 0;
int scoreRight = 0;
int scoreTop = 0;
int scoreBottom = 0;

// Variables for inserting the rowNum and columnNum values into treeArray.
int rowNum = 0;
int columnNum = 0;

// Value for the conversion from string to integer
int numericValue;

// Looping through the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Setting the columnNum variable to zero when starting a new rowNum iteration
    columnNum = 0;

    // Trim away newlines etc
    char[] charArray = line.Trim().ToCharArray();

    // Looping over the columns of the rows, inserting them into the 2D array.
    for (int i = 0; i < charArray.Length; i++)
    {
        numericValue = (int)Char.GetNumericValue(charArray[i]);
        if (rowNum == 0)
        {
            topRow[i] = numericValue;
        }
        if (rowNum == 98)
        {
            bottomRow[i] = numericValue;
        }
        treeArray[rowNum, columnNum] = numericValue;
        columnNum += 1;
    }

    rowNum += 1;

    // Continuing if done with the input rows
    if (rowNum < rowLength)
    {
        continue;
    }

    for (int row = 0; row < colLength; row++)
    {
        for (int column = 0; column < rowLength; column++)
        {
            currentTree = treeArray[row, column];

            // * * Every tree to the left
            for (int left = column - 1; left >= 0; left--)
            {
                if (treeArray[row, left] >= currentTree)
                {
                    scoreLeft += 1;
                    break;
                }
                scoreLeft += 1;
            }
            // * * Every tree to the right
            for (int right = column + 1; right < rowLength; right++)
            {
                if (treeArray[row, right] >= currentTree)
                {
                    scoreRight += 1;
                    break;
                }
                scoreRight += 1;
            }
            // * * Every tree on the top
            for (int top = row - 1; top >= 0; top--)
            {
                if (treeArray[top, column] >= currentTree)
                {
                    scoreTop += 1;
                    break;
                }
                scoreTop += 1;
            }
            // * * Every tree on the bottom
            for (int bottom = row + 1; bottom < colLength; bottom++)
            {
                if (treeArray[bottom, column] >= currentTree)
                {
                    scoreBottom += 1;
                    break;
                }
                scoreBottom += 1;
            }

            // Updating a totalScore if scenicScore is higher
            tempScore = scoreLeft * scoreRight * scoreTop * scoreBottom;
            if (totalScore < tempScore)
            {
                totalScore = tempScore;
            }
            scoreLeft = 0;
            scoreRight = 0;
            scoreTop = 0;
            scoreBottom = 0;
        }
    }
}

// Stops timer and prints the totalScore to console and elapsed time to console
watch.Stop();
Console.WriteLine($"Most scenic view score: {totalScore}, Code runtime: {watch.ElapsedMilliseconds}");

// * * Most scenic view score: 230112, Code runtime: 6