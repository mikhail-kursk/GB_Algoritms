using System;
using System.Collections.Generic;
using System.Text;

namespace HW_8_Sort
{
    class BacketSort
    {

        public void Sort(ref int[] notSortedArray, int maxValue)
        {
            // Создаем 10 корзин
            int step = maxValue / 10;
            List<int>[] backets = new List<int>[10];
            
            for (int i = 0; i < 10; i++)
            {
                backets[i] = new List<int>();
            }

            for (int i = 0; i < notSortedArray.Length; i++)
            {
                int index = notSortedArray[i] / step;
                backets[index].Add(notSortedArray[i]);
            }

            int currentOffset = 0;

            for (int i = 0; i < 10; i++)
            {
                backets[i].Sort();
                Array.Copy(backets[i].ToArray(), 0, notSortedArray, currentOffset, backets[i].Count);
                currentOffset += backets[i].Count;
            }

            return;
        }

    }
}
