using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SortUtilities
    {
        public void Swap(int[] baseArray, int firstInteger, int secondInteger)
        {
            int temp = baseArray[firstInteger];
            baseArray[firstInteger] = baseArray[secondInteger];
            baseArray[secondInteger] = temp;    
            
            //Tuple 
            //(baseArray[secondInteger], baseArray[firstInteger]) = (baseArray[firstInteger], baseArray[secondInteger]);
        }

        public int[] Randomize(int[] baseArray)
        {
            Random randomNumber = new Random();
            for (int i = 0; i < baseArray.Length; i++)
            {
                baseArray[i] = randomNumber.Next(0, baseArray.Length * 10);
            }
            return baseArray;
        }

        public int[] Prepare(int arraySize)
        {
            return Randomize(new int[arraySize]);
        }

        public delegate int[] SortDelegate(int[] rawArray);
        public delegate int SearchingDelegate(int[] rawArray,int key=0);


        public void DisplayRunningTime(string operation, int[] array, SortDelegate sortDelegate = null, SearchingDelegate searchingDelegate = null, int key = 0)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (operation)
            {
                case "sort":
                    sortDelegate(array); break;
                case "search":
                    searchingDelegate(array, key);
                    break;
                default:
                    break;
            }
            sw.Stop();
/* string formatedTime = GetFormatedTime(sw.Elapsed);*/
            Console.WriteLine("\nExecution time : " + sw.Elapsed.TotalMilliseconds + " milliseconds");
        }


        private string GetFormatedTime(TimeSpan timeSpan)
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00} ",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
                timeSpan.Milliseconds);
        }
        public void PrintArray(int[] arr)
        {
            foreach (int a in arr)
            {
                Console.Write("{0} ", a);
            }
            Console.WriteLine();
        }

    }
}
