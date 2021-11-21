using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ToyRobot.Commands;
using ToyRobot.Factory;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandFactory commandFactory = new CommandFactory();
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
                    var command = commandFactory.GetCommand(inputCommand);
                    myRobot.RunCommand(command, board);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
