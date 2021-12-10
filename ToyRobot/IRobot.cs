using System;
using ToyRobot.Commands;

namespace ToyRobot
{
    public interface IRobot
    {
        void SetIsSafePosition(Func<Coordinates, bool> isSafe);
        void RunCommand(ICommand command);
    }
}