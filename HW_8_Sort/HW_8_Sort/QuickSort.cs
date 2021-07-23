using System;
using System.Collections.Generic;
using System.Text;

namespace HW_8_Sort
{
    class QuickSort
    {
        public static void Sort(ref int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                Sort(ref array, i, last);
            if (first < j)
                Sort(ref array, first, j);
        }
    }
}

