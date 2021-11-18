using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed public class MoveToyAttribute : Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MoveToyAttribute(int x, int y)
        {
            if ((x < int.MaxValue && x > int.MinValue) && (y < int.MaxValue && y > int.MinValue))
            {
                X = x;
                Y = y;
            }
            else
                throw new Exception("Invalid Arguments");
        }
    }
}
