using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.Algorithm;

namespace Algorithms
{
    public class UnilityClass
    {
        public delegate int[] SortDelegate(int[] rawArray);
        public void DisplayRunningTime(int[] array, SortDelegate sortDelegate)
        {
            Stopwatch sw=new  Stopwatch();
            sw.Start();
            sortDelegate(array);
            sw.Stop();
            string formatedTime = getFormatedTime(sw.Elapsed);
            Console.WriteLine("Execution time=>" + formatedTime);
        }


        private string getFormatedTime(TimeSpan timeSpan)
        {
           return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
               timeSpan.Milliseconds / 10);
        }
    }
}
