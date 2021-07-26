using System;
using System.Diagnostics;

namespace HW_8_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrLen = 1_00_000_000;  // Длина массива
            int maxvalue = 1_000_000;    // Максимальное значение
            int backets = 10;            // количество корзин

            int[] notSortedArray = GenerateIntArray(arrLen, maxvalue);
            int[] notSortedArray2 = new int[arrLen];
            int[] notSortedArray3 = new int[arrLen];
            int[] notSortedArray4 = new int[arrLen];

            for (int i = 0; i < arrLen; i++)
            {
                notSortedArray2[i] = notSortedArray[i];
                notSortedArray3[i] = notSortedArray[i];
                notSortedArray4[i] = notSortedArray[i];
            }

            Stopwatch timer1 = new Stopwatch();

            timer1.Start();
            Array.Sort(notSortedArray);
            timer1.Stop();

            Console.WriteLine($"Сортировка по умолчанию {timer1.ElapsedMilliseconds} мс");

            BacketSort backet = new BacketSort(backets);

            Stopwatch timer2 = new Stopwatch();

            timer2.Start();
            backet.Sort(ref notSortedArray2, maxvalue);
            timer2.Start();

            Console.WriteLine($"Сортировка через корзины и сортировка внутри корзины через List.Sort {timer2.ElapsedMilliseconds} мс");

            Stopwatch timer3 = new Stopwatch();

            timer3.Start();
            QuickSort.Sort(ref notSortedArray3, 0, notSortedArray3.Length - 1);
            timer3.Start();

            Console.WriteLine($"Сортировка через быструю сортировку из методички {timer3.ElapsedMilliseconds} мс");
            

            BacketSort parallel = new BacketSort(backets, true);

            Stopwatch timer4 = new Stopwatch();

            timer4.Start();
            parallel.ParallelSort(ref notSortedArray4, maxvalue);
            timer4.Start();

            Console.WriteLine($"Сортировка через корзины и параллельная сортировка корзин через List.Sort {timer4.ElapsedMilliseconds} мс");

            for (int i = 0; i < arrLen; i++)
            {
                if ((notSortedArray[i] != notSortedArray2[i]) || (notSortedArray[i] != notSortedArray3[i]) || (notSortedArray[i] != notSortedArray4[i]))
                    Console.WriteLine("Не совпадает!");
            }
        }

        static int[] GenerateIntArray(int len, int maxValue)
        {
            Random randomInt = new Random();

            int[] array = new int[len];

            for (int i = 0; i < len; i++)
            {
                array[i] = randomInt.Next(maxValue);
            }

            return array;
        }
    }
}
