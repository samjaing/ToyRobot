using System;
using ToyRobot.Commands;

namespace ToyRobot
{
    public interface IRobot
    {
        void RunCommand(ICommand command);
        Coordinates GetCurrentPostions();
        event Func<Coordinates, bool> IsSafeEvent;
    }
}