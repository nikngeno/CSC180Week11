
/*
 * CSC180 Week 11 Programmming Assignment - Problem #2
/* useful links:
 * https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
 * https://dotnetcoretutorials.com/2020/05/10/basic-sorting-algorithms-in-c/
 * https://medium.com/engineering-hub/https-medium-com-engineering-hub-sorting-algorithms-in-csharp-and-java-4615f6f87696
 */

using System;
using System.IO;
using System.Diagnostics;

namespace CSC180Week11
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt";
            Stopwatch stopwatch = new Stopwatch();
            Method01(fileName, 1000, 1, 1001);
            string[] lines = File.ReadAllLines(fileName);
            int[] values = new int[lines.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(lines[i]);
            }
            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }
        //Method1 takes 4 parameters
        //Parameter 1 is a file name where data will be stored
        //Parameter 2 is the total number of random numbers generated
        //Parameter 3 is the lower bound of the randomly generated numbers
        //Parameter 4 is the upper bound of the randomly generated numbers

        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            using (var writer = new StreamWriter(fileName))// create a new file
            {
                Random r = new Random();// generate a lits of numbers
                int number = 0;
                {
                    for (int i = 1; i < total; i++)
                    {
                        number = r.Next(lowerRange, upperRange);// Generate a random number between lowerRange and upperRange
                        writer.WriteLine(number); // writes the numbers to a file
                    }
                }
            }
        }

        //Method 2 takes an array of integers numbers as the parameter
        //It iterates through the numbers and sorts them - sorting algorithm
        static void Method02(int[] arr)
        {
            for (int start = 0; start < arr.Length - 1; start++) // iteration process
            {
                int posMin = start;
                for (int i = start + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i;
                    }
                }
                int tmp = arr[start]; // creates a temporary integer variable to store value of the current element
                arr[start] = arr[posMin];// if postMin is less than start then is assigned to start
                arr[posMin] = tmp;// original value at start is now assigned to posMin
            }
        }
    }
}