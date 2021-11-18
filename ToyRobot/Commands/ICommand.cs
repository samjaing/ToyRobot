using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Commands
{
    public interface ICommand
    {
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition);
        public bool HasDirection();
    }
}
