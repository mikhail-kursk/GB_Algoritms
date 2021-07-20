using System;

namespace HW_7
{
    class Program
    {
        // Задание
        // Для прямоугольного поля размера M на N клеток, подсчитать количество путей из верхней левой клетки в правую нижнюю. 
        // Известно что ходить можно только на одну клетку вправо или вниз. 
        static void Main(string[] args)
        {
            int n = 10; // строки
            int m = 8; // столбцы


            // Вариант с рекурсией
            Console.WriteLine("Вариант с рекурсией");
            Matrix matrix = new Matrix(n, m);
            matrix.VariantsWithRecursion(0, 0);

            string res = null;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res += matrix.MatrixArr[i, j].ToString() + "\t";
                }
                Console.WriteLine(res);
                res = "";
            }
            
            Console.WriteLine();

            Console.WriteLine("Вариант со сложением");
            Matrix matrix_2 = new Matrix(n, m);
            matrix_2.MatrixArr[0, 0] = 1;

            matrix_2.VariantsWithSum();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res += matrix_2.MatrixArr[i, j].ToString() + "\t";
                }
                Console.WriteLine(res);
                res = "";
            }
        }
    }
}
