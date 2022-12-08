using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
int totalScore = 0;

int rowLength = File.ReadLines(@"input.txt").First().Length;
int colLength = File.ReadLines(@"input.txt").Count();

// Console.WriteLine(rowLength);
// Console.WriteLine(colLength);

int topdb;
int rightdb;
int bottomdb;
int leftdb;
int centerdb;



int[,] treeArray = new int[rowLength, colLength];
int min = 10;
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


        if (row == 0 || column == 0 || column == colLength - 1 || row == rowLength - 1)
        {
            setOfTreesCoordinates.Add(row.ToString() + column.ToString());
        }
        column += 1;
    }

    row += 1;

    if (row < rowLength)
    {
        continue;
    }

    Console.WriteLine(setOfTreesCoordinates.Count());


    for (int r = 1; r < row; r++)
    {
        for (int c = 1; c < column; c++)
        {

            centerdb = treeArray[r, c];
            topdb = treeArray[r - 1, c];
            if (c < 4)
            {
                rightdb = treeArray[r, c + 1];
            }
            if (r < 4)
            {
                bottomdb = treeArray[r + 1, c];
            }
            leftdb = treeArray[r, c - 1];


            min = 10;
            for (int left = 0; left < c; left++)
            {
                if (treeArray[r, left] < treeArray[r, c] && treeArray[r, left] < min)
                {
                    min = treeArray[r, left];
                    setOfTreesCoordinates.Add(r.ToString() + left.ToString());
                }
            }
            min = 10;
            for (int right = (rowLength - 1); right > r; right--)
            {
                if (treeArray[r, right] < treeArray[r, c] && treeArray[r, right] < min)
                {
                    min = treeArray[r, right];
                    setOfTreesCoordinates.Add(r.ToString() + right.ToString());
                }
            }
            min = 10;
            for (int top = 0; top < r; top++)
            {
                if (treeArray[top, c] < treeArray[r, c] && treeArray[top, c] < min)
                {
                    min = treeArray[top, c];
                    setOfTreesCoordinates.Add(top.ToString() + c.ToString());
                }
            }
            min = 10;
            for (int bottom = (colLength - 1); bottom > r; bottom--)
            {
                if (treeArray[bottom, c] < treeArray[r, c] && treeArray[bottom, r] < min)
                {
                    min = treeArray[bottom, r];
                    setOfTreesCoordinates.Add(bottom.ToString() + c.ToString());
                }
            }
        }
    }

    /*
    if (row < 100)
    {
        if (testCounter == 10)
        {
            break;
        }

        testCounter += 1;
        row += 1;
        if (testCounter == 9)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(treeArray[i, j]);
                }
                Console.WriteLine();
            }
        }
        continue;
    }
    break;
    */
}

// Prints the totalScore to console
// Console.WriteLine(totalScore);

Console.WriteLine(setOfTreesCoordinates.Count());

// Stops the benchmarking and prints it to the console.
watch.Stop();
//Console.WriteLine(watch.ElapsedMilliseconds);