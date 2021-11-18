using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Extensions
{
    public static class DirectionExtension
    {
        public static Direction Next(this Direction direction, int Rotation=90)
        {
            int CurrentDirectionValue = (int)direction;
            int newDirection = (CurrentDirectionValue + Rotation) % 360;

            return (Direction)newDirection;
        }

        public static Direction Previous(this Direction direction, int Rotation = 90)
        {
            int CurrentDirectionValue = (int)direction;

            CurrentDirectionValue = CurrentDirectionValue == 0 ? 360 : CurrentDirectionValue;
            int newDirection = (CurrentDirectionValue - Rotation) % 360;

            return (Direction)newDirection;
        }
    }
}
