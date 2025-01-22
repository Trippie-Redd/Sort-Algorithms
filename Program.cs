using System.Diagnostics;

Random rng = new Random();
Stopwatch stopwatch = new Stopwatch();

int sampleSize = 10; // Higher numbers increase accuracy of results
int[] sizes = [10, 100, 1000, 10000];
bool[] inclusions = [
    // true to include in calculation, false to exclude
    true, // Bubble Sort, 1
    true, // Selection Sort, 2
    true, // Insertion Sort, 3
    true, // Merge Sort, 4
    true  // Quick Sort, 5
];
string[] algorithmNames = [
    "Bubble Sort",
    "Selection Sort",
    "Insertion Sort",
    "Merge Sort",
    "Quick Sort"
];

double[,] totalTimes = new double[inclusions.Length, sizes.Length];
string buffer = "------------------------------------------";

// Program

Console.WriteLine(buffer);

// Used to run sampleSize samples
// Gets total times for all algorithms and sizes
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
            if (inclusions[j])// Does nothing if sorting algorithm is excluded
            { 
                // Makes a neq temporary array
                int[] temp = new int[ua.Length];
                Array.Copy(ua, temp, ua.Length);

                stopwatch.Start();

                Sort.SortingFunc(algorithmNames[j], temp);
                
                stopwatch.Stop();
                totalTimes[j, i] += stopwatch.ElapsedTicks/(double)Stopwatch.Frequency*1000; // Goes to fast if i use ElapsedMilliseconds straight up, this give correct answers
                stopwatch.Reset();

                /*
                // Checks if lists are properly sorted
                int tempCount = temp[0];
                foreach (int n in temp)
                {
                    if (n < tempCount)
                    {
                        Console.WriteLine($"List is not properly sorted. \nSorting Algorithm {j+1} used.");
                        return;
                    }
                    
                    tempCount = n;
                }
                */
            }
        }
    }

    Console.WriteLine("Sample " + (k+1) + " of " + sampleSize + " done.");
}

Console.WriteLine(buffer);

// Prints result
for (int j = 0; j < totalTimes.GetLength(0); j++)
{   
    if (inclusions[j]) // Does nothing if sorting algorithm is excluded
    {
        string algorithmName = algorithmNames[j];
        algorithmName += ":";
        while (algorithmName.Length <= 17)
            algorithmName += " ";
        Console.Write(algorithmName);

        for (int i = 0; i < totalTimes.GetLength(1); i++)
        {
            Console.Write(Math.Round(totalTimes[j, i] / sampleSize, 3) + " ms ");
        }
        Console.WriteLine();
    }
}

Console.WriteLine(buffer);

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