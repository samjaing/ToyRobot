using System;
using System.Linq;
using ToyRobot.Commands;
using ToyRobot.Exceptions;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        public bool IsPlaced { get; set; }
        private Coordinates CurrentPosition { get; set; }
        public event Func<Coordinates, bool> IsSafeEvent ;

        public Robot()
        {
            IsPlaced = false;
            IsSafeEvent = DefaultIsSafe;
        }
        public Robot(Func<Coordinates, bool> isSafe):base()
        {
            IsSafeEvent = isSafe;
        }

        /// <summary>
        /// Get the current coordinates of the robot.
        /// </summary>
        /// <returns></returns>
        public Coordinates GetCurrentPostions() => IsPlaced ? CurrentPosition : throw new BusinessException("Robot is not placed.");

        private bool DefaultIsSafe(Coordinates coordinate) => throw new ArgumentException("Robot is not prepared. Safety check not provided.");
        
        /// <summary>Method <c>RunCommand</c> apply the command on the current position of the robot.</summary>
        /// <param name="command"> Command to execut on the robot.</param>
        ///
        public void RunCommand(ICommand command)
        {
            if (IsSafeEvent == null)
            {
                throw new BusinessException("Robot is not placed.");
            }
            
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
            var isValidPosition = IsSafeEvent.GetInvocationList()
                                    .Select(checkMethod => (bool)checkMethod.DynamicInvoke(newCoordinates))
                                    .Any(checkResult => checkResult == false);
            if (isValidPosition)
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
