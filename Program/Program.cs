using Algorithms;
using System;
using System.Diagnostics;
using static Algorithms.SortUtilities;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortAlgorithms algorithm = new SortAlgorithms();
            SortUtilities utilities = new SortUtilities();

            Console.WriteLine("\t\t\t\tPlease select one sorting algorithm or exit.");
            Console.WriteLine();
            Console.WriteLine("1.Insertion sort \t2.Selection sort \n3.Bubble Sort  \t4.Merge sort \n5.Quick sort \t6.Exit");

            Console.Write("Please select number:");
            int input = int.Parse(Console.ReadLine());

            if (input.GetType() == typeof(int))
            {

                SortDelegate sortDelegate = null;
                switch (input)
                {
                    case 1:
                        {
                            sortDelegate = algorithm.InsertionSort;
                            break;
                        }
                    case 2:
                        {
                            sortDelegate = algorithm.SelectionSort;
                            break;
                        }
                    case 3:
                        {
                            sortDelegate = algorithm.BubbleSort;
                            break;
                        }
                    case 4:
                        {
                            sortDelegate = algorithm.MergeSort;
                            break;
                        }
                    case 5:
                        {
                            sortDelegate = algorithm.QuickSort;
                            break;
                        }
                    case 6:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Input. Please select between 1-5.");
                        break;
                }
                if (sortDelegate != null)
                {
                    Console.Write("\nPlease type the desired array size for testing:");
                    int arraySize = int.Parse(Console.ReadLine());
                    Console.WriteLine("You  entered :  {0}", input);
                   
                    int[] arrays = utilities.Prepare(arraySize);
                   
                    utilities.DisplayRunningTime(arrays, sortDelegate);

                }

            }

        }


       
    }
}
