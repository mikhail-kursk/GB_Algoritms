using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HW_8_Sort
{
    class BacketSort
    {

        public List<int>[] Backets { get; set; }

        public int NumberOfBuckets { get; set; }

        public bool[] Sorted { get; set; }

        public int Threads { get; set; }

        public BacketSort(int numberOfBuckets)
        {
            NumberOfBuckets = numberOfBuckets;

            Backets = new List<int>[NumberOfBuckets];

            for (int i = 0; i < NumberOfBuckets; i++)
            {
                Backets[i] = new List<int>();
            }
        }

        public BacketSort(int numberOfBuckets, bool parallel)
        {
            NumberOfBuckets = numberOfBuckets;
            Sorted = new bool[numberOfBuckets];

            if (parallel)
                Threads = numberOfBuckets;
            else
                Threads = 1;

            Backets = new List<int>[NumberOfBuckets];

            for (int i = 0; i < NumberOfBuckets; i++)
            {
                Backets[i] = new List<int>();
            }
        }

        public void Sort(ref int[] notSortedArray, int maxValue)
        {
            // Создаем 10 корзин
            int step = maxValue / NumberOfBuckets;


            for (int i = 0; i < notSortedArray.Length; i++)
            {
                int index = notSortedArray[i] / step;
                Backets[index].Add(notSortedArray[i]);
            }

            int currentOffset = 0;

            for (int i = 0; i < NumberOfBuckets; i++)
            {
                Backets[i].Sort();
                Array.Copy(Backets[i].ToArray(), 0, notSortedArray, currentOffset, Backets[i].Count);
                currentOffset += Backets[i].Count;
            }

            return;
        }

        public void ParallelSort(ref int[] notSortedArray, int maxValue)
        {
            // Создаем 10 корзин
            int step = maxValue / NumberOfBuckets;

            for (int i = 0; i < notSortedArray.Length; i++)
            {
                int index = notSortedArray[i] / step;
                Backets[index].Add(notSortedArray[i]);
            }


            for (int i = 0; i < NumberOfBuckets; i++)
            {
                Thread thread = new Thread(ThreadSort);
                thread.Start((object)i);
            }


            bool ready;
            do
            {
                ready = true;
                for (int i = 0; i < NumberOfBuckets; i++)
                {

                    if (Sorted[i] == false)
                    {
                        ready = false;
                        break;
                    }
                }
            } while (!ready);

            int currentOffset = 0;

            for (int i = 0; i < NumberOfBuckets; i++)
            {
                Array.Copy(Backets[i].ToArray(), 0, notSortedArray, currentOffset, Backets[i].Count);
                currentOffset += Backets[i].Count;
            }

            return;
        }

        public void ThreadSort(object number)
        {
            int numberOfThread = (int)number;
            Backets[numberOfThread].Sort();
            Sorted[numberOfThread] = true;
        }
    }
}
