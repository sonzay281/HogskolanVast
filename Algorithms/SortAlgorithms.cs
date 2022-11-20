using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace Algorithms
{
    public class SortAlgorithms
    {
        public SortUtilities sortUtilities=new SortUtilities();
        
        public int []  InsertionSort(int[] rawArray)
        {
            //Straight insertion
            int length = rawArray.Length, i, j,temp;
            for (i = 1; i < length; i++)
            {
                temp= rawArray[i];
                for (j = i - 1; j >= 0 && temp < rawArray[j]; j--)
                { 
                    rawArray[j + 1] = rawArray[j];
                }
                rawArray[j+1] = temp;
            }
            return rawArray;
        }

        public int[] SelectionSort(int[] rawArray)
        {
            //Straight selection
            int length = rawArray.Length, i, j,large,index;
            for (i = length - 1; i > 0; i--)
            {
                large = rawArray[0];
                index = 0;
                for (j = 1; j <=i; j++)
                {
                    if (rawArray[j] > large)
                    {
                        large=rawArray[j];
                        index = j;
                    }
                }
                rawArray[index] = rawArray[i];
                rawArray[i]=large;
            }
       return rawArray;
        }

        public int[] BubbleSort(int[] rawArray)
        { 
            int length=rawArray.Length, i, j;
            for (i = 0; i < length - 1; i++)
            {
                for (j = 0; j < length - i - 1; j++)
                {
                    if (rawArray[j] > rawArray[j + 1])
                    {
                        sortUtilities.Swap(rawArray, j, j + 1); 
                    }
                }
            }
            return rawArray;
        }
       
        public int [] QuickSort(int[] rawArray)
        {
           return QuickSorter(rawArray, 0, rawArray.Length-1);
        }
       
        private int[] QuickSorter(int[]array,int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = partition(array, low, high);

                // Separately sort elements before
                // partition and after partition
                QuickSorter(array, low, pi - 1);
                QuickSorter(array, pi + 1, high);
            }
            return array;
        }
        
        public int partition(int[] arr, int low, int high)
        {

            // pivot
            int pivot = arr[high];

            // Index of smaller element and
            // indicates the right position
            // of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller
                // than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of
                    // smaller element
                    i++;
                    sortUtilities.Swap(arr, i, j);
                }
            }
            sortUtilities.Swap(arr, i + 1, high);
            return (i + 1);
        }
        
        public int[] MergeSort(int[] rawArray)
        {
           return MergeSortDivider(rawArray, 0, rawArray.Length);
        }
        
        private int [] MergeSortDivider(int[] array,int beg,int end)
        {
            if (beg < end&&array.Length>0)
            {
                int mid = (beg + end) / 2;
                MergeSortDivider(array, beg, mid);
                MergeSortDivider(array, mid + 1, end);
                 Merger(array, beg, mid, end);
            }
            return array;
        }
        
        private int[] Merger(int [] array,int beg,int mid,int end)
        {

            int i, j, k;
            int n1 = mid - beg;
            int n2 = end - mid;

            /* temporary Arrays */
            int[] leftArray = new int[n1];
            int [] rightArray = new int[n2];
            
            /* copy data to temp arrays */
            for (i = 0; i < n1; i++)
            {
                leftArray[i] = array[beg + i];
            }

            for (j = 0; j < n2; j++)
            {
                rightArray[j] = array[mid + j];
            }

            i = 0; /* initial index of first sub-array */
            j = 0; /* initial index of second sub-array */
            k = beg;  /* initial index of merged sub-array */

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1 )
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
            return array;
        }
        
        
        
        public int LinearSearch(int[] array, int key)
        {
            int index=-1;
            for (int i = 0; i <array.Length; i++)
            {
                if (array[i] == key)
                {
                    index = i;
                }
            }
            if (index>-1){
            Console.WriteLine("\nElement {0} found in index {1}",key,index);
            } else{
                Console.WriteLine("Could not find element {0} in the given array.",key);
            }
            return index;
        }

        public int BinarySearch(int[] array,int key)
        {
            //array needs to be sorted for this search algorithm to work   
            int low=0, high=array.Length-1,index=-1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (array[mid] == key)
                {
                    index = mid;
                }

                if (array[mid] < key)
                {

                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (index != -1)
            {
                Console.WriteLine("Found in index: {0}", index);
            }
            else
            {
                Console.WriteLine("Not Found!");
            }
            return index;
           
        }


        public int SearchByLambda(int[]arr,int key)
        {
            int index = Array.IndexOf(arr, key);
            Console.WriteLine("Element found!"+index);
            return index;
        }
        public int[] SortByLambda(int[] rawArray)
        {
         int[] newArray=rawArray.OrderBy(x=>x).ToArray();
           return newArray;
        }



    }
}
