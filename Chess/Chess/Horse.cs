using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Horse
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static int MaxTurns;
        public static int Retry;

        public struct Move
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Moves { get; set; }

            public Move(int x, int y)
            {
                this.X = x;
                this.Y = y;
                this.Moves = 0;
            }

            public Move(int x, int y, int moves)
            {
                this.X = x;
                this.Y = y;
                this.Moves = moves;
            }

            public void DisplayPossition()
            {
                Console.WriteLine($"X = {X}, Y = {Y}");
            }

            public void DisplayPossitionAndMoves()
            {
                Console.WriteLine($"X = {X}, Y = {Y}, Moves = {Moves}");
            }
        }

        public Horse(int x, int y)
        {
            X = x;
            Y = y;
        }

        public List<Move> PossibleMovements(Board board, int x, int y, List<Move> disabledCells)
        {
            List<Move> moves = new List<Move>();
            bool present = false;

            //вверх и налево
            if (x - 1 > 0 && y - 2 > 0)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x - 1 && move.Y == y - 2)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x - 1, y - 2));
                else
                    present = false;
            }

            //вверх и направо
            if (x + 1 <= board.X && y - 2 > 0)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x + 1 && move.Y == y - 2)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x + 1, y - 2));
                else
                    present = false;
            }

            //направо и вверх
            if (x + 2 <= board.X && y - 1 > 0)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x + 2 && move.Y == y - 1)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x + 2, y - 1));
                else
                    present = false;
            }

            //направо и вниз
            if (x + 2 <= board.X && y + 1 <= board.Y)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x + 2 && move.Y == y + 1)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x + 2, y + 1));
                else
                    present = false;
            }

            //вниз и направо
            if (x + 1 <= board.X && y + 2 <= board.Y)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x + 1 && move.Y == y + 2)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x + 1, y + 2));
                else
                    present = false;
            }

            //вниз и налево
            if (x - 1 > 0 && y + 2 <= board.Y)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x - 1 && move.Y == y + 2)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x - 1, y + 2));
                else
                    present = false;
            }

            //налево и вниз
            if (x - 2 > 0 && y + 1 <= board.Y)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x - 2 && move.Y == y + 1)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x - 2, y + 1));
                else
                    present = false;
            }

            //налево и вверх
            if (x - 2 > 0 && y - 1 > 0)
            {
                foreach (Move move in disabledCells)
                {
                    if (move.X == x - 2 && move.Y == y - 1)
                    {
                        present = true;
                        break;
                    }
                }
                if (!present)
                    moves.Add(new Move(x - 2, y - 1));
            }

            return moves;
        }

        public Move ChangePossition(Board board, int x, int y, int moves)
        {
            if ((x > 0 && x <= board.X) && (y > 0 && y <= board.Y))
            {
                X = x;
                Y = y;
            }

            return new Move(x, y, moves + 1);
        }

        public List<Move> TryToFindMovementsWithAllPositions(Board board, List<Move> moves, List<Move> disabledCells, int i = 1)
        {
            
            List<Move> possibleMoves = new List<Move>();
            bool display = false;

            possibleMoves = PossibleMovements(board, X, Y, disabledCells);

            foreach (Move move in possibleMoves)
            {
                Retry++;

                if (Retry % 1000000 == 0)
                {
                    Console.WriteLine($"Attempts =  {Retry}, best result = {MaxTurns}, current result = {i}");
                }

                int x = X;
                int y = Y;

                Move newPossition = ChangePossition(board, move.X, move.Y, i);
                i = newPossition.Moves;

                if (i > MaxTurns)
                    MaxTurns = i;

                moves.Add(newPossition);

                disabledCells.Add(newPossition);

                if (i == board.X * board.Y)
                {
                    Console.WriteLine("решение найдено");
                    display = true;
                    break;
                }

                TryToFindMovementsWithAllPositions(board, moves, disabledCells, i);
                moves.RemoveAt(moves.Count - 1);
                i--;
                ChangePossition(board, x, y, i - 1);
                disabledCells.RemoveAt(disabledCells.Count - 1);
            }

            if (display)
            {
                foreach (Move move in moves)
                {
                    move.DisplayPossitionAndMoves();
                }
            }

            return moves;
        }


    }
}
