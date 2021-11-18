using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyRobot.Commands
{
    public class ReportCommand : ICommand
    {
        const string NAMEOFCOMMAND = "REPORT";
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition)
        {
            Console.WriteLine($"-------REPORTING-------------");
            Console.WriteLine($"X {CurrentPosition.XAxis}");
            Console.WriteLine($"Y {CurrentPosition.YAxis}");
            Console.WriteLine($"Direction {CurrentPosition.Face.ToString()}");
            Console.WriteLine($"--------------------------");

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
