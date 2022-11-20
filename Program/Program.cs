using Algorithms;
using System;
using System.Xml;
using static Algorithms.SortUtilities;
using DataStructure;
namespace Program
{
    internal class Program
    {
            SortAlgorithms algorithm = new SortAlgorithms();
            SortUtilities utilities = new SortUtilities();
       
        static void Main(string[] args)
        {
            while (true)
            {
            Console.WriteLine("\t\t\t\tPlease select one operation");
            Console.WriteLine();
            Console.WriteLine("1. Sorting \t\t 2. Searching\t\t 3. Data Structure \t\t 4. File Handeling and Filter");
            Console.Write("\nPlease select operation:");
            int option = int.Parse(Console.ReadLine());
            DSBase dataStructure= new DSBase();

            switch (option)
            {
                case 1:
                    {
                        new Program().SortingMenu();
                        break;
                    }
                case 2:
                    {
                        new Program().SearchingMenu();
                        break;
                    }
                case 3:
                    {
                        dataStructure.Menu();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("File handeling and other operation...");
                        break;
                    }
                    default:
                        {
                        Console.WriteLine("Invalid Entry");
                        break;
                    }
            }
             
               Console.WriteLine("Would you like to repeat?[Y/N]");
                string opt= Console.ReadLine();
                if (opt.Equals("N")||opt.Equals("n"))
                {
                    Environment.Exit(0);
                }

            }

        }

        private void SearchingMenu()
        {
            Console.WriteLine("\n1.Linear Search \t2.Binary Search \t3.Lambda Search");
            Console.Write("\nPlease select searching algorithm:");
            int option = int.Parse(Console.ReadLine());
            SearchingDelegate searchingDelegate = null;

            switch (option)
            {
                case 1:
                    {
                        searchingDelegate = algorithm.LinearSearch;
                        break;
                    }
                case 2:
                    {
                        searchingDelegate = algorithm.BinarySearch;
                        break;
                    }
                case 3:
                    {
                        searchingDelegate = algorithm.SearchByLambda;
                        break;
                    }
            }
            if (searchingDelegate != null)
            {
                int[] arrays = utilities.Prepare(1000000);
                Array.Sort(arrays);

                Console.WriteLine("With first element in the array:");
                utilities.DisplayRunningTime("search", arrays, null, searchingDelegate, arrays[0]);

                Console.WriteLine("With middle element in the array:");
                utilities.DisplayRunningTime("search", arrays, null, searchingDelegate, arrays[(arrays.Length/2)-1]);

                Console.WriteLine("With last element in the array:");
                utilities.DisplayRunningTime("search", arrays, null, searchingDelegate, arrays[arrays.Length-1]);
            }
        }

        private void SortingMenu()
        {
            Console.WriteLine("\n1.Insertion sort \t2.Selection sort \t3.Bubble Sort  \t4.Merge sort \t5.Quick sort \t6.Lambda");
            Console.Write("\nPlease select sorting algorithm:");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("You  entered :  {0}", input);

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
                        {
                            sortDelegate = algorithm.SortByLambda;
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid Input. Please select between 1-5.");
                        break;
                }
                if (sortDelegate != null)
                {
                    Console.Write("\nPlease type the desired array size for testing:");
                    int arraySize = int.Parse(Console.ReadLine());
                    int[] arrays = utilities.Prepare(arraySize);
                    utilities.DisplayRunningTime("sort", arrays, sortDelegate);
                }
            }
        }
    }
}
