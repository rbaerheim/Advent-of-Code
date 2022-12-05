using System.Text;
using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Path for the input
var path = @"input.txt";

// Reading lines in input skipping first ten because not needed.
var enumLines = File.ReadLines(path, Encoding.UTF8).Skip(10);

// List of words
List<string> wordList = new List<string> { " WBDNCFJ", " PZVQLST", " PZBGJT", " DTLJZBHC", " GVBJS", " PSQ", " BVDFLMPN", " PSMFBDLR", " VDTR" };

// LetterArray
char[] letterArray = new char[9];

// Looping through the input lines
foreach (string line in enumLines)
{
    // Trim away newlines etc
    line.Trim();

    // Gets the most important instructions
    string[] instruction = line.Split(" ").ToArray();

    // Parses instructions to integers for easy use
    int boxesToMove = Int32.Parse(instruction[1]);
    int moveFrom = Int32.Parse(instruction[3]);
    int moveTo = Int32.Parse(instruction[5]);

    // Gets the string which we want to move substring from
    string stringToMoveFrom = wordList[moveFrom - 1];

    // Removes the required substring
    string lettersToMove = stringToMoveFrom.Substring(stringToMoveFrom.Length - boxesToMove);

    // The characters from the substring we are moving are split into an array
    char[] lettersToMoveToCharArray = lettersToMove.ToCharArray();

    // The substring we just moved from a string is then removed from the original string
    string newStringMovedFrom = stringToMoveFrom.Remove(stringToMoveFrom.Length - boxesToMove);

    // Concatenates the char array into a string
    string reversedString = new string(lettersToMoveToCharArray);

    // Puts the strings to combine into an array
    string[] stringsToCombineArray = { wordList[moveTo - 1], reversedString };

    // Concatenates array to a single string
    string combinedStrings = string.Concat(stringsToCombineArray);

    // Sets the wordlist to now contain updated strings
    wordList[moveTo - 1] = combinedStrings;
    wordList[moveFrom - 1] = newStringMovedFrom;
}

// Indexer for letterArray
int indexer = 0;

// Looping over the puzzle strings, getting the last character and adds them to an array.
foreach (string puzzleString in wordList)
{
    char lastCharacter = puzzleString[puzzleString.Length - 1];
    letterArray[indexer] = lastCharacter;
    indexer += 1;
}

// Concatenates the last characters.
string combinedAnswer = string.Concat(letterArray);

Console.WriteLine(combinedAnswer); // TPFFBDRJD

// Stops the benchmarking and prints it to the console.
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds); // 16ms