using System;
using System.Collections.Generic;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 8; // Ширина доски
            int y = 8; // высота доски

            // Для доски 5x5, хороший вариант 3 , 3
            // Для доски 6x6, хороший вариант 3 , 3 
            // Для доски 7x7, хороший вариант 2 , 2
            // Для доски 

            Board board = new Board(x, y);

            Horse horse = new Horse(0, 0);
            bool found = false;

            for (int z = 1; z <= x; z++)
            {
                for (int a = 1; a <= y; a++)
                {
                    horse.X = z;
                    horse.Y = a;

                    Console.WriteLine($"Проверяем конфигурацию X = {z}, Y = {a}");
                    Horse.Retry = 0;

                    // Вносим первую позицию в списки, чтобы конь не пытался на нее попасть
                    List<Horse.Move> disabledMoves = new List<Horse.Move>();
                    Horse.Move firstPossition = new Horse.Move(horse.X, horse.Y, 1);
                    disabledMoves.Add(firstPossition);

                    List<Horse.Move> moves = new List<Horse.Move>();
                    moves.Add(firstPossition);

                    int i = 1;

                    horse.TryToFindMovementsWithAllPositions(board, moves, disabledMoves, ref i);
                    if (i == x * y)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
            
            Console.WriteLine($"Попыток = {Horse.Retry}");

        }
    }
}
