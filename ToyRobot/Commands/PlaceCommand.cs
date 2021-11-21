using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Enumerations;

namespace ToyRobot.Commands
{
    public class PlaceCommand : ICommand
    {
        public const CommandDescription NAMEOFCOMMAND = CommandDescription.PLACE;
        public Coordinates Coordinate { get; set; }

        public PlaceCommand(IEnumerable<string> commandElements)
        {  
            var coordinates = ValidatedInputCommand(commandElements);
            
            Coordinate = new Coordinates(
            coordinates.XAxis,
            coordinates.YAxis,
            coordinates.Face
            );
        }

        public bool HasDirection() => Coordinate.Face != null;

        /// <summary>Method <c>GetResultantCoordinates</c> return the new coordinates of the robot after applying commands on the current cordinates of the robot.</summary>
        /// <param name="currentPosition"> Current coordinates of the robot.</param>
        /// <returns>New set of coordinates after applying command of current corrdinates.</returns>
        ///
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition)
        {
            if (Coordinate.Face == null)
            {
                Coordinate.Face = CurrentPosition.Face;
            }
            return Coordinate;
        }

        /// <summary>Method <c>ValidatedInputCommand</c> ensures if all the required variable are present to make a valid command and extract the coordinates.</summary>
        /// <param name="inputCommand"> Takes the user input as a list </param>
        /// <returns>Coordinates suppied by user in the input command. </returns>
        ///
        public static Coordinates ValidatedInputCommand(IEnumerable<string> inputCommand)
        {
            if(inputCommand.First() != NAMEOFCOMMAND.ToString())
            {
                throw new Exception("Wrong Input");
            }

            //PLACE Command cannot have more than 3 parameters X Axis, Y Axis and Directions   
            if (!inputCommand.Any() || !(inputCommand.Count() < 5 && inputCommand.Count() >= 3))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }
            
            var xAxisValue = inputCommand.ElementAt(1);
            int xAxis;
            if(!int.TryParse(xAxisValue,out xAxis))
            {
                throw new ArgumentException($"Invalid integer value for x-axis: {xAxisValue} ");
            }
            var yAxisValue = inputCommand.ElementAt(2);
            int yAxis;
            if (!int.TryParse(yAxisValue, out yAxis))
            {
                throw new ArgumentException($"Invalid integer value for y-axis: {yAxisValue} ");
            }

            var coordinates = new Coordinates(xAxis,yAxis);
            
            if (inputCommand.Count() == 4)
            {
                var directionsAsString = inputCommand.ElementAt(3);
                Object directions;
                if (!Enum.TryParse(typeof(Direction), directionsAsString, out directions))
                {
                    throw new ArgumentException($"Invalid Direction: {directionsAsString}. Please make sure directions can be NORTH, SOUTH, EAST, WEST.");
                }
                else
                    coordinates.Face = (Direction)directions;
            }
            return coordinates;
        }
    }
}
