using System;
using System.Collections.Generic;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 7;
            int y = 7;

            Board board = new Board(x, y);

            Horse horse = new Horse(4, 4);

            /*List<Horse.Move> moves = horse.PossibleMovements(board, horse.X, horse.Y);

            foreach (Horse.Move move in moves)
            {
                move.DisplayPossition();
            }*/

            Console.WriteLine();

            List<Horse.Move> disabledMoves = new List<Horse.Move>();
            Horse.Move firstPossition = new Horse.Move(horse.X, horse.Y, 1);
            disabledMoves.Add(firstPossition);

            List<Horse.Move> moves = new List<Horse.Move>();
            moves.Add(firstPossition);

            horse.TryToFindMovementsWithAllPositions(board, moves, disabledMoves);
            Console.WriteLine(Horse.MaxTurns);
            Console.WriteLine(Horse.Retry);

        }
    }
}
