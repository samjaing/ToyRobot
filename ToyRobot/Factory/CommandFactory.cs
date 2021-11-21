using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ToyRobot.Commands;
using ToyRobot.Enumerations;

namespace ToyRobot.Factory
{
    /// <summary>Class <c>CommandFactory</c> serve as a command factory</summary>
    ///
    public class CommandFactory
    {
        /// <summary>Method <c>GetCommand</c> provide instance of type <c>ICommand</c> based on the user input.</summary>
        /// <param name="command"> Takes the user input in string format </param>
        /// <returns>Instance of type ICommand</returns>
        ///
        public ICommand GetCommand(string command)
        {
            var parsed = ParseCommand(command);

            var commandType = GetCommandType(parsed.First());

            switch (commandType)
            {
                case CommandDescription.PLACE:
                    return new PlaceCommand(parsed);

                case CommandDescription.MOVE:
                    return new MoveCommand(parsed);
                case CommandDescription.REPORT:
                    return new ReportCommand(parsed);
                case CommandDescription.LEFT:
                    return new LeftCommand(parsed);
                case CommandDescription.RIGHT:
                    return new RightCommand(parsed);
                default:
                    throw new ArgumentException("Command not supported.");

            }
        }

        /// <summary>Method <c>GetCommandType</c> get the description of command that will be used to instanciate the command.</summary>
        /// <param name="command"> Takes name of the command in string format </param>
        /// <returns>Enum of type CommandDescription </returns>
        ///
        public CommandDescription GetCommandType(string command)
        {
            CommandDescription cmd;
            
            if(!Enum.TryParse(command, out cmd))
                throw new ArgumentException("Command not found.");

            return cmd;
        }

        /// <summary>Method <c>ParseCommand</c> parse the user input and place the input elements in a list.</summary>
        /// <param name="command"> Takes the user input in string format </param>
        /// <returns>Instance of type ICommand</returns>
        ///
        public IEnumerable<string> ParseCommand(string userInput)
        {
            if (String.IsNullOrEmpty(userInput))
                throw new ArgumentException("Invalid Command.");


            List<string> result = new List<string>();

            // Remove any leading or trailing spaces.
            var cmd = Regex.Replace(userInput.Trim(), @"\s+", @" ");


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
