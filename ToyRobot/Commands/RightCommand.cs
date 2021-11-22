using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Enumerations;
using ToyRobot.Extensions;


namespace ToyRobot.Commands
{
    public class RightCommand : ICommand
    {
        const CommandDescription NAMEOFCOMMAND = CommandDescription.RIGHT;

        private RightCommand() { }

        public RightCommand(IEnumerable<string> parsed)
        {
            if (!ValidatedInputCommand(parsed))
                throw new ArgumentException("Wrong Format for RIGHT Command");
        }

        /// <summary>Method <c>GetResultantCoordinates</c> return the new coordinates of the robot after applying commands on the current cordinates of the robot.</summary>
        /// <param name="currentPosition"> Current coordinates of the robot.</param>
        /// <returns>New set of coordinates after applying command of current corrdinates.</returns>
        ///
        public Coordinates GetResultantCoordinates(Coordinates currentPosition)
        {
            Direction? newFace = currentPosition.Face?.Next();
            currentPosition.Face = newFace;
            return currentPosition;
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

            //RIGHT Command should have exactly 1 parameters ie. name of the command.
            if (!inputCommand.Any() || !(inputCommand.Count() == 1))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }

            if (inputCommand.First() != NAMEOFCOMMAND.ToString())
            {
                Console.WriteLine("Wrong Input");
                throw new Exception("Wrong Input");
            }

            return true;
        }
    }
}
