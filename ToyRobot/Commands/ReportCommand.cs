using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Enumerations;

namespace ToyRobot.Commands
{
    public class ReportCommand : ICommand
    {
        const CommandDescription NAMEOFCOMMAND = CommandDescription.REPORT;

        private ReportCommand() { }

        public ReportCommand(IEnumerable<string> parsed)
        {
            if (!ValidatedInputCommand(parsed))
                throw new ArgumentException("Wrong Format for REPORT Command");
        }

        /// <summary>Method <c>GetResultantCoordinates</c> return the new coordinates of the robot after applying commands on the current cordinates of the robot.</summary>
        /// <param name="currentPosition"> Current coordinates of the robot.</param>
        /// <returns>New set of coordinates after applying command of current corrdinates.</returns>
        ///
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition)
        {   
            Console.WriteLine($"Output: {CurrentPosition.XAxis},{CurrentPosition.YAxis},{CurrentPosition.Face.ToString()}");
            return CurrentPosition;
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
            //PLACE Command cannot have more than 3 parameters X Axis, Y Axis and Directions   
            if (!inputCommand.Any() || !(inputCommand.Count() == 1))
            {
                var message = "Invalid Command: wrong format";
                Console.WriteLine(message);
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
