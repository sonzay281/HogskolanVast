using Algorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DataStructure
{

    public class DSBase
    {
        SortAlgorithms algorithm = new SortAlgorithms();
        private Stopwatch sw = new Stopwatch();
        public void Menu()
        {
            ArrayTest();
            Listtest();
            StackTest();
            Queuetest();
            DictionaryTest();
            HashSetTest();
        }

         
        public void ArrayTest()
        {
            int[] array = new int[10];
            //Defining List (Dynamic Array)
            array[1] = 5;
            Console.WriteLine("\nDatatype : Array");
            sw.Restart();
            array[0] = 1;
            sw.Stop();
            Console.WriteLine("Addition:" + sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            int index = algorithm.LinearSearch(array, 5);
            sw.Stop();
            Console.WriteLine("\nSearch:" + sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            array.Except(new int[] { 5 }).ToArray();
            sw.Stop();
            Console.WriteLine("Deletion:" + sw.Elapsed.TotalMilliseconds);
            sw.Restart();
            int t = array[2];
            sw.Stop();
            Console.WriteLine("Access by index:" + sw.Elapsed.TotalMilliseconds);

        }
        public void StackTest()
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("\nDatatype : Stack");
            sw.Restart();
            stack.Push(10);
            sw.Stop();
            Console.WriteLine("Addition:"+sw.Elapsed.TotalMilliseconds);
            stack.Push(20);
            stack.Push(110);
            stack.Push(102);
            stack.Push(101);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);
            stack.Push(60);
            stack.Push(70);
            stack.Push(80);
            sw.Restart();
            stack.Pop();
            sw.Stop();
            Console.WriteLine("Deletion:"+sw.Elapsed.TotalMilliseconds);

        }
        public void Listtest()
        {
            List<int> list = new List<int>();
            Console.WriteLine("\nDatatype : Array");
            sw.Restart();
            list.Add(10);
            sw.Stop();
            Console.WriteLine("Addition:" + sw.Elapsed.TotalMilliseconds);
            list.Add(30);
            list.Add(20);
            sw.Restart();
            list.Contains(20);
            sw.Stop();
            Console.WriteLine("Search:" + sw.Elapsed.TotalMilliseconds);
            sw.Restart();
            list.Remove(10);
            sw.Stop();
            Console.WriteLine("Deletion:" + sw.Elapsed.TotalMilliseconds);
            
        }
        public void Queuetest()
        {
            Console.WriteLine("\nDatatype:  Queue");
            Queue queue = new Queue(5);
            sw.Restart();
            queue.Enqueue(10);
            sw.Stop();
            Console.WriteLine("Addition:" + sw.Elapsed.TotalMilliseconds);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(50);
            queue.Enqueue(60);

            sw.Restart();
            queue.Dequeue();
            sw.Stop();
            Console.WriteLine("Deletion:" + sw.Elapsed.TotalMilliseconds);


        }
        public void DictionaryTest()
        {
            Console.WriteLine("\nDatatype:  Dictionary");
            Dictionary<string, string> dictionary =new Dictionary<string, string>();
            sw.Restart();
            dictionary.Add("key1", "value1");
            sw.Stop();
            Console.WriteLine("Addition:" + sw.Elapsed.TotalMilliseconds);
            dictionary.Add("key2", "value2");
            dictionary.Add("key3", "value3");
            dictionary.Add("key4", "value4");
            sw.Restart();
            dictionary.Remove("key1");
            sw.Stop();
            Console.WriteLine("Deletion:" + sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            dictionary.ContainsValue("value");
            sw.Stop();
            Console.WriteLine("Search:" + sw.Elapsed.TotalMilliseconds);


        }
        
        public void HashSetTest()
        {
            Console.WriteLine("\nDatatype:  Hash Set");
            HashSet<int> numbers = new HashSet<int>();
            sw.Restart();
            numbers.Add(10);
            sw.Stop();
            Console.WriteLine("Addition:" + sw.Elapsed.TotalMilliseconds);
        for(int i = 0; i < 5; i++)
            {
                numbers.Add(i*5);
            }
            sw.Restart();
            numbers.Remove(5);
            sw.Stop();
            Console.WriteLine("Deletion:" + sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            numbers.Contains(10);
            sw.Stop();
            Console.WriteLine("Search:" + sw.Elapsed.TotalMilliseconds);
        }
    }
}