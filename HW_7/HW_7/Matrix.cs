using System;
using System.Collections.Generic;
using System.Text;

namespace HW_7
{
    class Matrix
    {
        public int[,] MatrixArr { get; set; }


        public Matrix(int i, int j)
        {
            MatrixArr = new int[i, j];
        }

        public int[,] VariantsWithRecursion(int i, int j)
        {
            if (i >= MatrixArr.GetLength(0) || j >= MatrixArr.GetLength(1))
                return MatrixArr;

            MatrixArr[i, j] += 1;

            MatrixArr = VariantsWithRecursion(i + 1, j);
            MatrixArr = VariantsWithRecursion(i, j + 1);

            return MatrixArr;

        }

        public int[,] VariantsWithSum()
        {
            for (int i = 0; i < MatrixArr.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixArr.GetLength(1); j++)
                {
                    if (i - 1 >= 0)
                    {
                        MatrixArr[i, j] += MatrixArr[i - 1, j];
                    }

                    if (j - 1 >= 0)
                    {
                        MatrixArr[i, j] += MatrixArr[i, j - 1];
                    }
                }
            }
            return MatrixArr;
        }
    }
}
