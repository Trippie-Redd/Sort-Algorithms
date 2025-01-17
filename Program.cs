using System.Diagnostics;

Random rng = new Random();
Stopwatch stopwatch = new Stopwatch();

int sampleSize = 10; // Higher numbers increase accuracy of results
int[] sizes = [1, 10, 100, 1000, 10000, 100000];
bool[] exceptions = [
    // false to include in calculation, true to exclude
    false, // Bubble Sort
    false, // Selection Sort
    false, // Insertion Sort 
    false, // Merge Sort
    false  // Quick Sort
];

double[,] totalTimes = new double[5, sizes.Length];

// Main loop
// Used to run sampleSize samples
for (int k = 0; k < sampleSize; k++)
{
    // Runs for all sizes in sizes
    for (int i = 0; i < sizes.Length; i++)
    {
        // Creates unsorted array to be used for all sorting algorithms
        int[] ua = RandomArray(sizes[i]);

        // The sorting algorithm used changes as j increases
        for (int j = 0; j <= 4; j++)
        {   
            if (!exceptions[j])// Does nothing if sorting algorithm is excluded
            { 
                // Makes a neq temporary array
                int[] temp = new int[ua.Length];
                Array.Copy(ua, temp, ua.Length);

                stopwatch.Start();

                Sort.SortingFunc(j, temp);
                
                stopwatch.Stop();
                totalTimes[j, i] += stopwatch.ElapsedTicks/(double)Stopwatch.Frequency*1000; // Goes to fast if i use ElapsedMilliseconds straight up, this give correct answers
                stopwatch.Reset();
            }
        }
    }

    Console.WriteLine("Sample " + (k+1) + " of " + sampleSize + " done!");
}

// Buffer
Console.WriteLine("------------------------------------------");

// Prints result
for (int j = 0; j < totalTimes.GetLength(0); j++)
{   
    if (!exceptions[j]) // Does nothing if sorting algorithm is excluded
    {
        switch (j)
        {
            case 0:
                Console.Write("Bubble Sort:     ");
                break;
            case 1:
                Console.Write("Selection Sort:  ");
                break;
            case 2:
                Console.Write("Insertion Sort:  ");
                break;
            case 3:
                Console.Write("Merge Sort:      ");
                break;
            case 4:
                Console.Write("Quick Sort:      ");
                break;
        }

        for (int i = 0; i < totalTimes.GetLength(1); i++)
        {
            Console.Write(Math.Round(totalTimes[j, i] / sampleSize, 3) + " ms ");
        }
        Console.WriteLine();
    }
}

Console.WriteLine("------------------------------------------");

// Returns a random array with specified length
int[] RandomArray(int length)
{
    int[] intArray = new int[length];
    
    for(int i = 0; i < length; i++)
    {
        intArray[i] = rng.Next();
    }

    return intArray;
}