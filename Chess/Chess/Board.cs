using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Board
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Board(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
