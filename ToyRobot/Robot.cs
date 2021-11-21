using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Commands;
using ToyRobot.Exceptions;

namespace ToyRobot
{
    public class Robot
    {
        public bool IsPlaced { get; set; }
        public Coordinates CurrentPosition { get; set; }
        public Robot()
        {
            IsPlaced = false;
        }

        /// <summary>Method <c>RunCommand</c> apply the command on the current position of the robot.</summary>
        /// <param name="command"> Command to execut on the robot.</param>
        ///
        public void RunCommand(ICommand command, Board board)
        {
            if (!IsPlaced)
            {
                //Check if command is PLACE with proper direction then we place it.
                if (!command.HasDirection())
                {
                    throw new NotPlacedException("Please place the robot on the board using command : PLACE X,Y,DIRECTION");
                }
            }
            //Here we need to provide some current postion to this command and get if it is a valid command to move.
            var newCoordinates = command.GetResultantCoordinates(CurrentPosition);

            //Check if new coordinates are valid or not.
            if(!board.CheckValidLimits(newCoordinates))
            {
                Console.WriteLine("Invalid Move: Out of the limits.");
                return;
            }

            if (!IsPlaced)
            {
                IsPlaced = true;
                Console.WriteLine("Congratulations you have successfully placed the robot on the board.");
            }

            CurrentPosition = newCoordinates;
        }
    }
}
