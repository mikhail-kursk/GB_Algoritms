using System;
using System.Collections.Generic;
using System.Text;

namespace HW_8_Sort
{
    class QuickSort
    {
        public static int[] Sort(int[] nonSortedArr)
        {
            int middleElement_index = nonSortedArr.Length / 2;
            int middleElement = nonSortedArr[nonSortedArr.Length / 2];
            int temp;

            //int[] leftPart = new int[nonSortedArr.Length];
            //int[] rightPart = new int[nonSortedArr.Length];

            for (int i = 0; i < middleElement_index; i++)
            {
                if (nonSortedArr[i] > middleElement)
                {
                    temp = nonSortedArr[i];
                    for (int j = i; j < nonSortedArr.Length - 1; j++)
                    {
                        nonSortedArr[j] = nonSortedArr[j + 1];
                    }
                    nonSortedArr[nonSortedArr.Length - 1] = temp;
                    middleElement_index -= 1;
                    i--;
                }
            }

            for (int j = nonSortedArr.Length - 1; j > middleElement_index; j--)
            {
                if (nonSortedArr[j] <= middleElement)
                {
                    temp = nonSortedArr[j];

                    for (int i = j; i >= 1; i--)
                    {
                        nonSortedArr[i] = nonSortedArr[i - 1];
                    }

                    nonSortedArr[0] = temp;
                    middleElement_index += 1;
                    j++;
                }
            }

            if (nonSortedArr.Length >= 3 && middleElement_index > 0)
            {
                int[] leftPart = new int[middleElement_index];
                Array.Copy(nonSortedArr, 0, leftPart, 0, middleElement_index);
                leftPart = Sort(leftPart);
                Array.Copy(leftPart, 0, nonSortedArr, 0, middleElement_index);
            }

            if (nonSortedArr.Length >= 3 && middleElement_index < nonSortedArr.Length - 1)
            {
                int[] RightPart = new int[nonSortedArr.Length - middleElement_index - 1];
                Array.Copy(nonSortedArr, middleElement_index + 1, RightPart, 0, nonSortedArr.Length - middleElement_index - 1);
                RightPart = Sort(RightPart);
                Array.Copy(RightPart, 0, nonSortedArr, middleElement_index + 1, nonSortedArr.Length - middleElement_index - 1);
            }
            return nonSortedArr;
        }
    }
}
