using System;
using System.Collections.Generic;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 7; // Ширина доски
            int y = 7; // высота доски

            // Для доски 5x5, хороший вариант 3 , 3
            // Для доски 6x6, хороший вариант 3 , 3 
            // Для доски 7x7, хороший вариант 2 , 2
            // Для доски 8x8, не удалось рассчитать за приемлемое время

            Board board = new Board(x, y);

            Horse horse = new Horse(2, 2);

            Horse.Retry = 0;

            // Вносим первую позицию в списки, чтобы конь не пытался на нее попасть
            List<Horse.Move> disabledMoves = new List<Horse.Move>();
            Horse.Move firstPossition = new Horse.Move(horse.X, horse.Y, 1);
            disabledMoves.Add(firstPossition);

            List<Horse.Move> moves = new List<Horse.Move>();
            moves.Add(firstPossition);

            int i = 1;

            horse.TryToFindMovementsWithAllPositions(board, moves, disabledMoves, ref i);

            Console.WriteLine($"Попыток = {Horse.Retry}");

        }
    }
}
