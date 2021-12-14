using System;

namespace ToyRobot.Attributes
{
    /// <summary>
    /// This class is used as a decorator on ENUM to accepts input coordinates which moves the toy by incrementing current position by X,Y positions
    /// i.e. If  current position of toy is (X,Y) = (2,3) and attribute defined is (3,3). Toy will move to (2+3, 3+3) i.e. (5,6)
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed public class MoveToyAttribute : Attribute
    {
        /// <summary>
        /// Move the toy by X points
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Move the toy by Y points
        /// </summary>
        public int Y { get; set; }

        //TODO: Implement Clock positions.
        //public short ClockAngle { get; set; }
        //public MoveToyAttribute(int x, int y, short ClockAngle)

        public MoveToyAttribute(int x, int y)
        {
            if ((x < int.MaxValue && x > int.MinValue) && (y < int.MaxValue && y > int.MinValue))
            {
                X = x;
                Y = y;
            }
            else
                throw new Exception("Invalid values of the attribute.");
        }
    }
}
