using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ToyRobot.Commands;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine("Creating Robot.");
            Robot myRobot = new Robot();
            var cmd = GetCommand("PLACE 2,4,NORTH");
            myRobot.RunCommand(cmd, board);

            var cmd2 = GetCommand("PLACE 2,5");
            myRobot.RunCommand(cmd2, board);

            var cmd3 = GetCommand("PLACE 2,1,SOUTH");
            myRobot.RunCommand(cmd3, board);
            PrintCoordinates(myRobot, board); 
            var cmd4 = GetCommand("MOVE");
            myRobot.RunCommand(cmd4, board);
            PrintCoordinates(myRobot, board); 
            cmd3 = GetCommand("PLACE 2,5, EAST");
            myRobot.RunCommand(cmd3, board);
            myRobot.RunCommand(cmd4, board);
            PrintCoordinates(myRobot, board);
            cmd3 = GetCommand("PLACE 2,5, NORTH");
            myRobot.RunCommand(cmd3, board);
            myRobot.RunCommand(cmd4, board);
            PrintCoordinates(myRobot,board);

            cmd3 = GetCommand("PLACE 2,5, NORTH");
            myRobot.RunCommand(cmd3, board);
            PrintCoordinates(myRobot, board);

            var LEFTCommand = GetCommand("LEFT");
            myRobot.RunCommand(LEFTCommand, board);
            PrintCoordinates(myRobot, board);
            var RIGHTCommand = GetCommand("RIGHT");
            myRobot.RunCommand(RIGHTCommand, board);
            PrintCoordinates(myRobot, board);

            cmd3 = GetCommand("PLACE 1,1, EAST");
            myRobot.RunCommand(cmd3, board);
            PrintCoordinates(myRobot, board);
            myRobot.RunCommand(LEFTCommand, board);
            PrintCoordinates(myRobot, board);

            myRobot.RunCommand(RIGHTCommand, board);
            PrintCoordinates(myRobot, board);


        }

        public static void PrintCoordinates(Robot myRobot, Board board)
        {
            var cmd = GetCommand("REPORT");
            myRobot.RunCommand(cmd, board);
        }

        public static ICommand GetCommand(string command)
        {
            var parsed = ParseCommand(command);

            switch(parsed.First())
            {
                case "PLACE":
                    var validPlaceCoordinates = PlaceCommand.ValidatedInputCommand(parsed);
                    return new PlaceCommand(validPlaceCoordinates);
                case "MOVE":
                    if(MoveCommand.ValidatedInputCommand(parsed))
                        return new MoveCommand();
                    else
                    {
                        Console.WriteLine("Wrong Format for MOVE Command");
                        throw new Exception("Wrong Format for MOVE Command");
                    }
                case "REPORT":
                    if (ReportCommand.ValidatedInputCommand(parsed))
                        return new ReportCommand();
                    else
                    {
                        Console.WriteLine("Wrong Format for REPORT Command");
                        throw new Exception("Wrong Format for REPORT Command");
                    }
                case "LEFT":
                    if (LeftCommand.ValidatedInputCommand(parsed))
                        return new LeftCommand();
                    else
                    {
                        Console.WriteLine("Wrong Format for LEFT Command");
                        throw new Exception("Wrong Format for LEFT Command");
                    }
                case "RIGHT":
                    if (RightCommand.ValidatedInputCommand(parsed))
                        return new RightCommand();
                    else
                    {
                        Console.WriteLine("Wrong Format for RIGHT Command");
                        throw new Exception("Wrong Format for RIGHTCommand");
                    }
                default:
                    throw new Exception("Command not found.");

            }
        }

        private static IEnumerable<string> ParseCommand(string cmd1)
        {
            if (String.IsNullOrEmpty(cmd1))
                throw new Exception("Wrong Input.");

            List<string> result = new List<string>();

            // Remove any leading or trailing spaces.
            var cmd = Regex.Replace(cmd1.Trim(), @"\s+", @" ");


            var brkCmd = cmd.Split(' ').ToList();
            if (!brkCmd.Any() || String.IsNullOrEmpty(brkCmd.First()))
                throw new Exception("Wrong Input.");

            result.Add(brkCmd.First());

            if (brkCmd.Count > 1)
            {
                var splitted = cmd.Split(' ', 2)[1];

                var s = Regex.Replace(splitted, @"\s+", "");
                var split = s.Split(',').ToList();
                result.AddRange(split);
            }

            return result;
        }
    }
}
