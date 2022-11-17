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

        public delegate void SortDelegate(int[] rawArray);
        public void DisplayRunningTime(int[] array, SortDelegate sortDelegate)
        {
            Console.WriteLine("\nBefore sorting:");
            PrintArray(array);

            Stopwatch sw = new Stopwatch();
            sw.Start();
           
            sortDelegate(array);
            sw.Stop();
            Console.WriteLine("\n After sorting:");
            PrintArray(array);

            string formatedTime = GetFormatedTime(sw.Elapsed);
            Console.WriteLine("\nExecution time ->" + formatedTime);
        }


        private string GetFormatedTime(TimeSpan timeSpan)
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
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
