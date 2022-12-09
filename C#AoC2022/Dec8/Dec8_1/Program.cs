using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
// int totalScore = 0;

int rowLength = File.ReadLines(@"input.txt").First().Length;
int colLength = File.ReadLines(@"input.txt").Count();

// Console.WriteLine(rowLength);
// Console.WriteLine(colLength);
/*
int topDB;
int rightDB;
int bottomDB;
int leftDB;
int centerDB;
*/

int[,] treeArray = new int[rowLength, colLength];
int[] colCountingArray = new int[rowLength];

int rowMax = 0;
// int colMax = 0;
int rowCurrent = 0;
// int colCurrent = 0;

int row = 0;
int column = 0;
// int testCounter = 1;

HashSet<string> setOfTreesCoordinates = new HashSet<string>();

// Looping through the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    column = 0;
    // Trim away newlines etc
    char[] charArray = line.Trim().ToCharArray();
    for (int i = 0; i < charArray.Length; i++)
    {
        treeArray[row, column] = (int)Char.GetNumericValue(charArray[i]);


        column += 1;
    }

    row += 1;

    if (row < rowLength)
    {
        continue;
    }



    for (int r = 0; r < row; r++)
    {
        for (int c = 0; c < column; c++)
        {
            if (c == 0)
            {
                rowMax = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + c.ToString());
                continue;
            }
            else
            {
                rowCurrent = treeArray[r, c];
            }
            if (rowCurrent > rowMax)
            {
                rowMax = rowCurrent;
                setOfTreesCoordinates.Add(r.ToString() + c.ToString());
            }
            if (r == 0)
            {
                colCountingArray[c] = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + c.ToString());
            }
            else
            {
                if (treeArray[r, c] > colCountingArray[c])
                {
                    colCountingArray[c] = treeArray[r, c];
                    setOfTreesCoordinates.Add(r.ToString() + c.ToString());
                }
            }
        }
        for (int c = rowLength - 1; c >= 0; c--)
        {
            if (c == rowLength - 1)
            {
                rowMax = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + c.ToString());
                continue;
            }
            else
            {
                rowCurrent = treeArray[r, c];
            }
            if (rowCurrent > rowMax)
            {
                rowMax = rowCurrent;
                setOfTreesCoordinates.Add(r.ToString() + c.ToString());
            }
        }
    }
    for (int r = rowLength - 1; r >= 0; r--)
    {
        for (int c = 0; c < column; c++)
        {
            if (r == rowLength - 1)
            {
                colCountingArray[c] = treeArray[r, c];
                setOfTreesCoordinates.Add(r.ToString() + c.ToString());
            }
            else
            {
                if (treeArray[r, c] > colCountingArray[c])
                {
                    colCountingArray[c] = treeArray[r, c];
                    setOfTreesCoordinates.Add(r.ToString() + c.ToString());
                }
            }
        }
    }
}
// Prints the totalScore to console
// Console.WriteLine(totalScore);

Console.WriteLine(setOfTreesCoordinates.Count());

// Stops the benchmarking and prints it to the console.
watch.Stop();
//Console.WriteLine(watch.ElapsedMilliseconds);