using System;
using ToyRobot.Commands;
using ToyRobot.Exceptions;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        public bool IsPlaced { get; set; }
        public Coordinates CurrentPosition { get; set; }
        private Func<Coordinates, bool> IsSafe;

        public Robot()
        {
            IsPlaced = false;
            IsSafe = DefaultIsSafe;
        }
        public Robot(Func<Coordinates, bool> isSafe)
        {
            IsPlaced = false;
            IsSafe = isSafe;
        }

        private bool DefaultIsSafe(Coordinates coordinate) => throw new ArgumentException("Robot is not prepared. Safety check not provided.");
        public void SetIsSafePosition(Func<Coordinates, bool> isSafe)
        {
            IsSafe = isSafe;
        }
        
        /// <summary>Method <c>RunCommand</c> apply the command on the current position of the robot.</summary>
        /// <param name="command"> Command to execut on the robot.</param>
        ///
        public void RunCommand(ICommand command)
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
            if (!IsSafe(newCoordinates))
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
