using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Board
    {
        public int XLimit { get; set; }
        public int YLimit { get; set; }

        public Board()
        {
            XLimit = 5;
            YLimit = 5;
        }
        public Board(int xLimit, int yLimit)
        {
            XLimit = xLimit;
            YLimit = yLimit;
        }

        public bool CheckValidLimits(Coordinates coordinates)
        {
            return coordinates.XAxis <= XLimit && coordinates.XAxis >= 0 && coordinates.YAxis <= YLimit && coordinates.YAxis >= 0;
        }
    }
}
