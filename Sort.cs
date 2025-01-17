static class Sort
{
    // Make QuickSort and MergeSort return int[]
    // OR
    // Make return type for iterative functions void
    
    static public void SortingFunc(int sortMethod, int[] a)
    {
        switch(sortMethod)
        {
            case 0: // Bubble Sort
                BubbleSort(a);
                break;
            case 1: // Insertion Sort
                SelectionSort(a);
                break;
            case 2: // Selection Sort
                InsertionSort(a);
                break;
            case 3: // Merge Sort
                MergeSort(a);
                break;
            case 4: // Quick Sort
                QuickSort(a, 0, a.Length-1);
                break;
            default: // Should not run
                Console.WriteLine("Sorting func not found");
                break;
        }
    }
    
    static private void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Iterative sorting algorithms
    static public int[] BubbleSort(int[] a)
    {
        int length = a.Length;
        for (int j = 0; j < length - 1; j++)
        {
            for (int i = 0; i < length - j; i++) // Improves speed
            {
                if (i == 0)
                    Console.Write("");
                else if (a[i] < a[i-1])
                    Swap(ref a[i], ref a[i-1]);
            }
        }

        return a;
    }

    static public int[] InsertionSort(int[] a)
    {
        for (int i = 1; i < a.Length; ++i) {
            // Current number to swap
            int key = a[i];
            // Index of number to swap with
            int j = i - 1;

            // Checks if J is not zero and if it is bigger than key
            while (j >= 0 && a[j] > key) {
                // Moves smaller number back
                a[j + 1] = a[j];
                j = j - 1;
            }
            a[j + 1] = key;
        }

        return a;
    }
    
    static public int[] SelectionSort(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < a.Length; j++)
                if (a[j] < a[min])
                    min = j;
            
            // Switches postion of current and lowest
            int temp = a[i];
            a[i] = a[min];
            a[min] = temp;
        }

        return a;
    }

    // Merge Sort
    static public void MergeSort(int[] fullArray)
    {
        int length = fullArray.Length;
        // If the array only contains one element it is already sorted, so return
        if (length <= 1)
        {
            return;
        }

        // Creates two arrays with size of half of the fullArray
        int middle = length/2;
        int[] leftArray = new int[middle];
        int[] rightArray = new int[length - middle];

        int r = 0, l = 0;

        for (l = 0; l < length; l++)
        {
            if (l < middle)
                leftArray[l] = fullArray[l];
            else
            {
                rightArray[r] = fullArray[l];
                r++;
            }
        }

        MergeSort(leftArray);
        MergeSort(rightArray);
        Merge(leftArray, rightArray, fullArray);
    }

    static private void Merge(int[] leftArray, int[] rightArray, int[] fullArray)
    {
        int lSize = fullArray.Length / 2;
        int rSize = fullArray.Length - lSize;
        int f = 0, l = 0, r = 0;

        while (l < lSize && r < rSize)
        {
            if (leftArray[l] < rightArray[r])
            {
                fullArray[f] = leftArray[l];
                f++;
                l++;
            }
            else
            {
                fullArray[f] = rightArray[r];
                f++;
                r++;
            }
        }

        while (l < lSize)
        {
            fullArray[f] = leftArray[l];
            f++;
            l++;
        }

        while (r < rSize)
        {
            fullArray[f] = rightArray[r];
            f++;
            r++;
        }
    }

    // Quick Sort
    static public void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Partition the array
            int pivotIndex = Partition(array, low, high);

            // Recursively sort the subarrays
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high]; // Choose the last element as the pivot
        int i = low - 1; // Index for the smaller element

        for (int j = low; j < high; j++)
        {
            // If the current element is smaller than or equal to the pivot
            if (array[j] <= pivot)
            {
                i++;
                // Swap element i and element j
                Swap(ref array[i],ref array[j]);
            }
        }

        // Swap element i + 1 and element high (the pivot)
        Swap(ref array[i + 1], ref array[high]);

        return i + 1;
    }
}