using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyRobot.Enumerations;

namespace ToyRobot.Commands
{
    public class PlaceCommand : ICommand
    {
        const CommandDescription NAMEOFCOMMAND = CommandDescription.PLACE;
        public Coordinates Coordinate { get; set; }

        public PlaceCommand(Coordinates coordinates)
        {
            Coordinate = new Coordinates(
            coordinates.XAxis,
            coordinates.YAxis,
            coordinates.Face
            );
        }

        public bool HasDirection() => Coordinate.Face != null;
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition)
        {
            if (Coordinate.Face == null)
            {
                Coordinate.Face = CurrentPosition.Face;
            }
            return Coordinate;
        }
        
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
