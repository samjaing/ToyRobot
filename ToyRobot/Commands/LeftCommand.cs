using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Extensions;

namespace ToyRobot.Commands
{
    public class LeftCommand : ICommand
    {
        const string NAMEOFCOMMAND = "LEFT";

        public Coordinates GetResultantCoordinates(Coordinates currentPosition)
        {
            Direction? newFace = currentPosition.Face?.Previous();
            currentPosition.Face = newFace;
            return currentPosition;
        }

        public bool HasDirection()
        {
            return false;
        }

        public static bool ValidatedInputCommand(IEnumerable<string> inputCommand)
        {
            //PLACE Command cannot have more than 3 parameters X Axis, Y Axis and Directions   
            if (!inputCommand.Any() || !(inputCommand.Count() == 1))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }

            if (inputCommand.First() != NAMEOFCOMMAND)
            {
                throw new Exception("Wrong Input");
            }

            return true;
        }

    }
}
