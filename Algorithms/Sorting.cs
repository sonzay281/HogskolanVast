using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Sorting
    {
        public int [] InsertionSort(int[] rawArray) 
        {
            
            //Implement inserton  sort
            return rawArray;
        }

        public int[] SelectionSort(int[] rawArray)
        {

            //Implement selection  sort
            return rawArray;
        }

        public int[] BubbleSort(int[] rawArray)
        {

            //Implement bubble sort
            return rawArray;
        }
        public int[] MergeSort(int[] rawArray)
        {

            //Implement merge sort
            return rawArray;
        }
        public int[] QuickSort(int[] rawArray)
        {

            //Implement quick sort
            return rawArray;
        }

        public int[] SortByLambda(int[] rawArray)
        {
            int[] newArray= new int[rawArray.Length];
            //implement lamda sort
            return newArray;
        }

        public delegate int SortDelegate(int[] rawArray);

    }
}
