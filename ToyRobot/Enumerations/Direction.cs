using ToyRobot.Attributes;

namespace ToyRobot
{
    public enum Direction
    {
        [MoveToy(1, 0)]
        EAST = 90,
        [MoveToy(0, -1)]
        SOUTH = 180,
        [MoveToy(-1, 0)]
        WEST = 270,
        [MoveToy(0, 1)]
        NORTH = 0
    }
}
