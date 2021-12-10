using System;

namespace ToyRobot
{
    public class Board
    {
        public int XLimit { get; set; }
        public int YLimit { get; set; }
        public IRobot Bot { get; set; }
        public bool BotLinked => !(Bot == null);

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

        public void AssignRobot(IRobot bot) 
        {
            if (BotLinked)
                throw new ArgumentException("Board already have a robot.");
            Bot = bot;
            //TODO : Reset bot to a not place position.
            Bot.SetIsSafePosition(CheckValidLimits);
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
