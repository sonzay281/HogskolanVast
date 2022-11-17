using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Security.Cryptography;

namespace Algorithms
{
    public class SortAlgorithms
    {
        public SortUtilities sortUtilities=new SortUtilities();
        
        public void  InsertionSort(int[] rawArray)
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
        }

        public void SelectionSort(int[] rawArray)
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
       
        }

        public void BubbleSort(int[] rawArray)
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
        }
       
        public void QuickSort(int[] rawArray)
        {
           quickSort(rawArray, 0, rawArray.Length);
        }
       
        private void quickSort(int[]array,int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = partition(array, low, high);

                // Separately sort elements before
                // partition and after partition
                quickSort(array, low, pi - 1);
                quickSort(array, pi + 1, high);
            }
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
        
        public void MergeSort(int[] rawArray)
        {
           mergeSort(rawArray, 0, rawArray.Length);
        }
        
        private void mergeSort(int[] array,int beg,int end)
        {
            if (beg < end&&array.Length>0)
            {
                int mid = (beg + end) / 2;
                mergeSort(array, beg, mid);
                mergeSort(array, mid + 1, end);
                merge(array, beg, mid, end);
            }
        }
        
        private void merge(int [] array,int beg,int mid,int end)
        {

            int i, j, k;
            int n1 = mid - beg;
            int n2 = end - mid;

            /* temporary Arrays */
            int[] leftArray = new int[n1];
            int [] rightArray = new int[n2];
            
            /* copy data to temp arrays */
            for (i = 0; i < n1; i++)
                leftArray[i] = array[beg + i];
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
        }
        public int[] SortByLambda(int[] rawArray)
        {
            return Array.Sort(rawArray, (a, b) => b - a);
        }
    }
}
