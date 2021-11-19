using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Commands;

namespace ToyRobot
{
    public class Robot
    {
        public bool IsPlaced { get; set; }
        //public Board Board { get; set; }
        public Coordinates CurrentPosition { get; set; }
        public Robot()
        {
            IsPlaced = false;
            //CHECK::Should we do it???
            //Board = null;
        }

        internal void RunCommand(ICommand command, Board board)
        {
            if (!IsPlaced)
            {
                //Check if command is PLACE with proper inputs then we place it.
                //LOGIC
                if (!command.HasDirection())
                {
                    Console.WriteLine("Please place the robot on the board using command : PLACE X,Y,DIRECTION");
                    return;
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
                //Board = board; //Initialize the board.
                Console.WriteLine("Congratulations you have successfully placed the robot on the board.");
            }

            CurrentPosition = newCoordinates;
        }
    }
}
