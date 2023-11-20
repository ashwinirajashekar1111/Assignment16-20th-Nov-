using System;
using System.Diagnostics;

class QuickSortExample
{
    static void Main()
    {
        // Example usage
        int[] array = { 12, 4, 5, 6, 7, 3, 1, 15 };
        Console.WriteLine("Original array: " + string.Join(", ", array));

        QuickSort(array, 0, array.Length - 1);
        Console.WriteLine("Sorted array: " + string.Join(", ", array));

       
        // Performance analysis
        Console.WriteLine("\nPerformance Analysis:");
        MeasureSortingTime(20);
        MeasureSortingTime(30);
        MeasureSortingTime(50);
    }

    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
                return false;
        }
        return true;
    }

    static void MeasureSortingTime(int arraySize)
    {
        int[] randomArray = GenerateRandomArray(arraySize);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        QuickSort(randomArray, 0, randomArray.Length - 1);

        stopwatch.Stop();
        Console.WriteLine($"Time to sort {arraySize} elements: {stopwatch.Elapsed.Milliseconds} milliseconds");
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 100);
        }

        return array;
    }
}