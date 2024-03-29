﻿using System.Diagnostics;

// Benchmarking my code
var watch = new Stopwatch();
watch.Start();

// Total score variable
int solution = 0;

// Looping through the input and reading the input lines
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Trim away newlines etc
    line.Trim();
}

// Stops timer and prints the solution to console and elapsed time to console
Console.WriteLine($": {solution}, Code runtime: {watch.ElapsedMilliseconds}");

// * * 