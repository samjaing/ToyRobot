using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyRobot.Commands
{
    public class PlaceCommand : ICommand
    {
        const string NAMEOFCOMMAND = "PLACE";
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
            if(inputCommand.First() != NAMEOFCOMMAND)
            {
                Console.WriteLine("Wrong Input");
                throw Exception("Wrong Input");
            }

            //PLACE Command cannot have more than 3 parameters X Axis, Y Axis and Directions   
            if (!inputCommand.Any() || !(inputCommand.Count() < 5 && inputCommand.Count() >= 3))
            {
                var message = "Invalid Command: wrong format";
                Console.WriteLine(message);
                throw new Exception(message);
            }
            
            var xAxisValue = inputCommand.ElementAt(1);
            int xAxis;
            if(!int.TryParse(xAxisValue,out xAxis))
            {
                var message = $"Invalid integer value: {xAxisValue} ";
                Console.WriteLine(message);
                throw new Exception(message);
            }
            var yAxisValue = inputCommand.ElementAt(2);
            int yAxis;
            if (!int.TryParse(yAxisValue, out yAxis))
            {
                var message = $"Invalid integer value: {yAxisValue} ";
                Console.WriteLine(message);
                throw new Exception(message);
            }

            var coordinates = new Coordinates(xAxis,yAxis);
            
            if (inputCommand.Count() == 4)
            {
                var directionsAsString = inputCommand.ElementAt(3);
                Object directions;
                if (!Enum.TryParse(typeof(Direction), directionsAsString, out directions))
                {
                    var message = $"Invalid Direction: {directionsAsString} ";
                    Console.WriteLine(message);
                    throw new Exception(message);
                }
                else
                    coordinates.Face = (Direction)directions;
            }
            return coordinates;
        }

        private static Exception Exception(string v)
        {
            throw new NotImplementedException();
        }
    }
}
