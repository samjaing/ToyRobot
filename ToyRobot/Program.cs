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
            Console.WriteLine("Place your robot on the board:");
            while (true)
            {
                Console.Write("Cmd>>");
                string inputCommand = Console.ReadLine();
                
                if (string.IsNullOrEmpty(inputCommand) || string.IsNullOrWhiteSpace(inputCommand))
                    continue;
                try
                {
                    var command = GetCommand(inputCommand);
                    myRobot.RunCommand(command, board);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
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
                        throw new ArgumentException("Wrong Format for MOVE Command");
                    }
                case "REPORT":
                    if (ReportCommand.ValidatedInputCommand(parsed))
                        return new ReportCommand();
                    else
                    {
                        throw new ArgumentException("Wrong Format for REPORT Command");
                    }
                case "LEFT":
                    if (LeftCommand.ValidatedInputCommand(parsed))
                        return new LeftCommand();
                    else
                    {
                        throw new ArgumentException("Wrong Format for LEFT Command");
                    }
                case "RIGHT":
                    if (RightCommand.ValidatedInputCommand(parsed))
                        return new RightCommand();
                    else
                    {
                        throw new ArgumentException("Wrong Format for RIGHTCommand");
                    }
                default:
                    throw new ArgumentException("Command not found.");

            }
        }

        private static IEnumerable<string> ParseCommand(string cmd1)
        {
            if (String.IsNullOrEmpty(cmd1))
                throw new ArgumentException("Invalid Command.");


            List<string> result = new List<string>();

            // Remove any leading or trailing spaces.
            var cmd = Regex.Replace(cmd1.Trim(), @"\s+", @" ");


            var brkCmd = cmd.Split(' ').ToList();
            if (!brkCmd.Any() || String.IsNullOrEmpty(brkCmd.First()))
                throw new ArgumentException("Invalid Command.");

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
