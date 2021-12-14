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
            XLimit = 7;
            YLimit = 7;
        }
        public Board(int xLimit, int yLimit)
        {
            XLimit = xLimit;
            YLimit = yLimit;
        }
        /// <summary>
        /// CheckValidLimits checks if the provided cooredinates present in the limits of the board.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>Boolean value</returns>
        public bool CheckValidLimits(Coordinates coordinates)
        {
            return coordinates.XAxis <= XLimit && coordinates.XAxis >= 0 && coordinates.YAxis <= YLimit && coordinates.YAxis >= 0;
        }
    }
}
