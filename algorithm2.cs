using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Find Pair Sum Program ===");
            // Get arrays
            int[] firstArray = GetArray("first");
            int[] secondArray = GetArray("second");

            // Check if arrays are empty
            if (firstArray.Length == 0 || secondArray.Length == 0)
            {
                Console.WriteLine("\nERROR: Both arrays must have at least one number!");
                Console.WriteLine("Please restart the program.");
                return;
            }
            
            // Get targetted sum
            Console.Write("Target sum: ");
            int targetSum = int.Parse(Console.ReadLine()); // Simple parse

            // Try to find the pair
            Console.WriteLine("\nSTEP 4: Searching for a pair...");
            var result = BinarySearch(firstArray, secondArray, targetSum);

            // Step 5: Show the result
            if (result != null)
            {
                Console.WriteLine("\nFound a matching pair!");
                Console.WriteLine($"Number from first array: {result.Value.firstNumber}");
                Console.WriteLine($"Number from second array: {result.Value.secondNumber}");
                Console.WriteLine($"Sum: {result.Value.firstNumber} + {result.Value.secondNumber} = {targetSum}");
            }
            else
            {
                Console.WriteLine("\nNo matching pair found.");
                Console.WriteLine($"No combination adds up to {targetSum}");
            }
            Console.ReadKey();
        }

        // Function 1: Convert string like "1,2,3" to array
        static int[] GetArray(string arrayName)
        {
            Console.Write($"Enter {arrayName} array numbers (comma separated): ");
            string input = Console.ReadLine();
            string[] parts = input.Split(',');

            int[] array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = int.Parse(parts[i].Trim());
            }

            return array;
        }

        // Function 2: Find if any number from first array + any number from second array = target sum
        static (int firstNumber, int secondNumber)? BinarySearch(int[] array1, int[] array2, int targetSum)
        {
            // Sort first array
            Array.Sort(array1);

            // Check each number in second array
            for (int i = 0; i < array2.Length; i++)
            {
                int neededNumber = targetSum - array2[i];

                // Binary search in sorted first array
                int left = 0;
                int right = array1.Length - 1;

                while (left <= right)
                {
                    int middle = (left + right) / 2;

                    if (array1[middle] == neededNumber)
                    {
                        // Found it! Just return the pair
                        return (neededNumber, array2[i]);
                    }
                    else if (array1[middle] < neededNumber)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            }

            // No pair found
            return null;
        }
    }
}
