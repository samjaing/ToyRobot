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
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition)
        {   
            Console.WriteLine($"Output: {CurrentPosition.XAxis},{CurrentPosition.YAxis},{CurrentPosition.Face.ToString()}");
            return CurrentPosition;
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
