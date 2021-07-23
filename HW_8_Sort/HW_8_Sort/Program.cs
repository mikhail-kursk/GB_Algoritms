using System;
using System.Diagnostics;

namespace HW_8_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrLen = 1_000;   // Длина массива

            int[] notSortedArray   = GenerateIntArray(arrLen);
            int[] notSortedArray_2 = new int[arrLen];
            
            for (int i = 0; i < arrLen; i++)
            {
                notSortedArray_2[i] = notSortedArray[i];
            }

            Stopwatch timer_2 = new Stopwatch();
            timer_2.Start();
            Array.Sort(notSortedArray_2);
            timer_2.Start();

            Console.WriteLine(timer_2.ElapsedMilliseconds);

            Stopwatch timer_1 = new Stopwatch();
            timer_1.Start();
            int[] sortedArray = QuickSort.Sort(notSortedArray);
            timer_1.Stop();

            Console.WriteLine(timer_1.ElapsedMilliseconds);

            //BacketSort backet = new BacketSort();
            //backet.Sort(notSortedArray, 1_000_000);
        }

        static int [] GenerateIntArray (int len)
        {
            Random randomInt = new Random();

            int[] array = new int[len];

            for (int i = 0; i < len; i++)
            {
                array[i] = randomInt.Next(1_000_000_000);
            }

            return array;
        }
    }
}
