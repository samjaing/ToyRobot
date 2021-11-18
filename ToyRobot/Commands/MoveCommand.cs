using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ToyRobot.Attributes;

namespace ToyRobot.Commands
{
    public class MoveCommand : ICommand
    {
        const string NAMEOFCOMMAND = "MOVE";

        public Coordinates GetResultantCoordinates(Coordinates currentPosition)
        {
            var type = currentPosition.Face.GetType();
            var name = Enum.GetName(type, currentPosition.Face);
            var moveToyAttribute = type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<MoveToyAttribute>()
                .SingleOrDefault();

            // If moveToyAttribute is not null, than a direction exists
            if (moveToyAttribute == null)
            {
                throw new ApplicationException("MOVE steps not defined for direction");
            }
            else
            {
                currentPosition.XAxis += moveToyAttribute.X;
                currentPosition.YAxis += moveToyAttribute.Y;                
            }

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
                Console.WriteLine(message);
                throw new Exception(message);
            }

            if (inputCommand.First() != NAMEOFCOMMAND)
            {
                Console.WriteLine("Wrong Input");
                throw new Exception("Wrong Input");
            }

            return true;
        }
    }
}
