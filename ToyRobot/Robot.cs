using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Commands;

namespace ToyRobot
{
    public class Robot
    {
        public bool IsPlaced { get; set; }
        public Board Board { get; set; }
        public Coordinates CurrentPosition { get; set; }
        public Robot()
        {
            IsPlaced = false;
            //CHECK::Should we do it???
            Board = null;
        }

        internal void RunCommand(ICommand command, Board board)
        {
            if (!IsPlaced)
            {
                //Check if command is PLACE with proper inputs then we place it.
                //LOGIC
                if (command.HasDirection())
                {
                    IsPlaced = true;
                    Board = board; //Initialize the board.
                }
                else
                {
                    Console.WriteLine("Invalid Move: first place command needs direction.");
                    return;
                }
            }
            //Here we need to provide some current postion to this command and get if it is a valid command to move.
            var newCoordinates = command.GetResultantCoordinates(CurrentPosition);

            //Check if new coordinates are valid or not.
            if(!Board.CheckValidLimits(newCoordinates))
            {
                Console.WriteLine("Invalid Move: Out of the limits.");
                return;
            }

            CurrentPosition = newCoordinates;
        }
    }
}
