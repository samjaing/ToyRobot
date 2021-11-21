using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ToyRobot.Attributes;

namespace ToyRobot
{
    public enum Direction
    {
        [MoveToy(1, 0)]
        EAST = 0,
        [MoveToy(0, -1)]
        SOUTH = 90,
        [MoveToy(-1, 0)]
        WEST = 180,
        [MoveToy(0, 1)]
        NORTH = 270
    }
}
