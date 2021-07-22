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
        public static long Retry;

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

            public void PrintPossition()
            {
                Console.WriteLine($"X = {X}, Y = {Y}");
            }

            public void PrintPossitionAndMoves()
            {
                Console.WriteLine($"X = {X}, Y = {Y}, Moves = {Moves}");
            }

            public static void DisplayPossitionAndMoves(Board board, List<Move> moves)
            {
                int x = board.X;
                int y = board.Y;

                char[,] marks = new char[x, y];

                foreach (Move move in moves)
                {
                    Console.Clear();

                    marks[move.X - 1, move.Y - 1] = 'К';

                    // Рисуем доску

                    for (int i = 0; i < y; i++)
                    {
                        Console.WriteLine($"{new string('-', x * 4 + 1)}");
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write($"|   ");
                        }
                        Console.Write('|');
                        Console.WriteLine();
                    }
                    Console.WriteLine($"{new string('-', x * 4 + 1)}");

                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            Console.SetCursorPosition(i * 4 + 2, j * 2 + 1);
                            Console.Write($"{marks[i, j]}");
                        }
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                    Console.SetCursorPosition((move.X - 1) * 4 + 2, (move.Y - 1) * 2 + 1);
                    marks[move.X - 1, move.Y - 1] = 'x';
                    Console.Write($"{marks[move.X - 1, move.Y - 1]}");

                }

                Console.SetCursorPosition(0, board.Y * 2 + 2);

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

        public List<Move> TryToFindMovementsWithAllPositions(Board board, List<Move> moves, List<Move> disabledCells, ref int i)
        {

            List<Move> possibleMoves = new List<Move>();
            bool display = false;

            // Определяем возможные шаги
            possibleMoves = PossibleMovements(board, X, Y, disabledCells);

            foreach (Move move in possibleMoves)
            {
                // Подсчет статистики и вывод на экран, чтобы не было скучно ждать
                Retry++;
                if (Retry % 1_000_000 == 0)
                {
                    Console.WriteLine($"Attempts =  {Retry}, best result = {MaxTurns}, current result = {i}");
                }

                // Запоминаем текущую позицию, чтобы можно было вернуться
                int x = X;
                int y = Y;

                // Меняем позицию
                Move newPossition = ChangePossition(board, move.X, move.Y, i);
                i = newPossition.Moves;

                // Также подсчет статистики
                if (i > MaxTurns)
                    MaxTurns = i;

                // Записываем сделанные ходы
                moves.Add(newPossition);

                // Маркируем пройденные клетки
                disabledCells.Add(newPossition);

                // Проверка на окончание поиска
                if (i == board.X * board.Y)
                {
                    Console.WriteLine("решение найдено");
                    display = true;
                    break;
                }

                // Рекурсивный вызов после хода
                TryToFindMovementsWithAllPositions(board, moves, disabledCells, ref i);

                // Остановка поиска, если решение было найдено
                if (i == board.X * board.Y)
                    return moves;

                // Откат хода, если закончились ходы
                moves.RemoveAt(moves.Count - 1);
                i--;
                ChangePossition(board, x, y, i - 1);
                disabledCells.RemoveAt(disabledCells.Count - 1);
            }

            // Вывод решения
            if (display)
            {
                foreach (Move move in moves)
                {
                    move.PrintPossitionAndMoves();
                }

                Console.WriteLine("Отрисовать? y/n");
                if (Console.ReadLine().ToLower() == "y")
                    Move.DisplayPossitionAndMoves(board, moves);
            }

            return moves;
        }


    }
}
