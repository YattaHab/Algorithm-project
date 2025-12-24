

using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Find Pair Sum Program ===");

        Console.Write("Enter first array numbers (comma separated): ");
        int[] A = ReadArrayFromInput();

        Console.Write("Enter second array numbers (comma separated): ");
        int[] B = ReadArrayFromInput();

        Console.Write("Target sum: ");
        int S = int.Parse(Console.ReadLine());

        bool found = false;

        
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < B.Length; j++)
            {
                if (A[i] + B[j] == S)
                {
                    Console.WriteLine("\nFound a matching pair!");
                    Console.WriteLine("Number from first array: " + A[i]);
                    Console.WriteLine("Number from second array: " + B[j]);
                    Console.WriteLine($"Sum: {A[i]} + {B[j]} = {S}");
                    found = true;
                    break;
                }
            }
            if (found)
                break;
        }

        if (!found)
        {
            Console.WriteLine("\nNo matching pair found.");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
    static int[] ReadArrayFromInput()
    {
        string input = Console.ReadLine();
        string[] parts = input.Split(',');

        int[] arr = new int[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            arr[i] = int.Parse(parts[i].Trim());
        }
        return arr;
    }
}
