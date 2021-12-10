using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ToyRobot.Attributes;
using ToyRobot.Enumerations;

namespace ToyRobot.Commands
{
    public class MoveCommand : ICommand
    {
        const CommandDescription NAMEOFCOMMAND = CommandDescription.MOVE;

        private MoveCommand() { }

        public MoveCommand(IEnumerable<string> parsed)
        {
            if (!ValidatedInputCommand(parsed))
                throw new ArgumentException("Wrong Format for MOVE Command");
        }

        /// <summary>Method <c>GetResultantCoordinates</c> return the new coordinates of the robot after applying commands on the current cordinates of the robot.</summary>
        /// <param name="currentPosition"> Current coordinates of the robot.</param>
        /// <returns>New set of coordinates after applying command of current corrdinates.</returns>
        ///
        public Coordinates GetResultantCoordinates(Coordinates currentPosition)
        {
            Coordinates newCoordinates = new Coordinates(); 
            var type = currentPosition.Face.GetType();
            var name = Enum.GetName(type, currentPosition.Face);
            var moveToyAttribute = type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<MoveToyAttribute>()
                .SingleOrDefault();

            // If moveToyAttribute is not null, than a direction exists
            if (moveToyAttribute == null)
            {
                throw new ArgumentException("MOVE steps not defined for direction");
            }
            else
            {
                newCoordinates.XAxis = currentPosition.XAxis + moveToyAttribute.X;
                newCoordinates.YAxis = currentPosition.YAxis + moveToyAttribute.Y;
                newCoordinates.Face = currentPosition.Face;
            }

            return newCoordinates;
        }

        public bool HasDirection()
        {
            return false;
        }

        /// <summary>Method <c>ValidatedInputCommand</c> ensures if all the required variable are present to make a valid command.</summary>
        /// <param name="inputCommand"> Takes the user input as a list </param>
        /// <returns>True: All the values are present to create a valid command.
        /// False: Wrong arguments passed to commands.</returns>
        ///
        public static bool ValidatedInputCommand(IEnumerable<string> inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentException("Invalid Command: wrong format");
            }

            //MOVE Command should have exactly 1 parameters ie. name of the command.
            if (!inputCommand.Any() || !(inputCommand.Count() == 1))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }

            if (inputCommand.First() != NAMEOFCOMMAND.ToString())
            {
                throw new Exception("Wrong Input.");
            }

            return true;
        }
    }
}
