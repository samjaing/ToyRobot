using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot;
using ToyRobot.Exceptions;
using ToyRobot.Factory;
using Xunit;

namespace ToyRobotUnitTest
{
    public class RobotTest
    {
        private CommandFactory _commandFactory { get; set; }
        private Robot _toyRobot { get; set; }
        private Board _board { get; set; }

        public RobotTest()
        {
            _commandFactory = new CommandFactory();
            _board = new Board(5,5);
        }

        //Command should not execute if robot is not placed.
        [Theory]
        [InlineData("PLACE 3,4")]
        [InlineData("MOVE")]
        [InlineData("LEFT")]
        [InlineData("RIGHT")]
        [InlineData("REPORT")]
        public void IgnoreCommandIfRobotNotPlaced(string inputCommand)
        {
            Robot robot = new Robot();
            var command = _commandFactory.GetCommand(inputCommand);
            Assert.Throws<NotPlacedException>(() => robot.RunCommand(command, _board));
        }

        //Command should execute if robot is placed.Considering Robot is placed on PLACE 1,1,NORTH inintially.
        [Theory]
        [InlineData("PLACE 3,4",3,4,"NORTH")]
        [InlineData("PLACE 3,4,SOUTH", 3, 4, "SOUTH")]
        [InlineData("MOVE",1,2,"NORTH")]
        [InlineData("LEFT",1,1,"WEST")]
        [InlineData("RIGHT", 1, 1, "EAST")]
        [InlineData("REPORT",1,1,"NORTH")]
        [InlineData("PLACE 5,5", 5, 5, "NORTH")]
        public void RunCommandShouldPass(string inputCommand,int expectedXAxis, int expectedYAxis, string expectedDirections)
        {
            Robot robot = new Robot();
            PlaceRobot(robot);
            var command = _commandFactory.GetCommand(inputCommand);

            robot.RunCommand(command, _board);
            var currentPosition = robot.CurrentPosition;

            Assert.Equal(expectedXAxis,currentPosition.XAxis );
            Assert.Equal(expectedYAxis, currentPosition.YAxis);
            Assert.NotNull(currentPosition.Face);
            Assert.Equal(expectedDirections.ToString(),currentPosition.Face?.ToString());
        }

        //Command should not change its positon if resulting coordintate after applying the command are going out of bound.
        [Theory]
        [InlineData("PLACE -1,-1,SOUTH",5,5, "EAST")]
        [InlineData("PLACE 6,6", 5, 5, "EAST")]
        [InlineData("MOVE", 5, 5, "EAST")]
        public void RunCommandShouldFail(string inputCommand, int expectedXAxis, int expectedYAxis, string expectedDirections)
        {
            Robot robot = new Robot();
            PlaceRobot(robot,"PLACE 5,5,EAST");
            var command = _commandFactory.GetCommand(inputCommand);

            robot.RunCommand(command, _board);
            var currentPosition = robot.CurrentPosition;

            Assert.Equal(expectedXAxis, currentPosition.XAxis);
            Assert.Equal(expectedYAxis, currentPosition.YAxis);
            Assert.NotNull(currentPosition.Face);
            Assert.Equal(expectedDirections.ToString(), currentPosition.Face?.ToString());
        }
        private void PlaceRobot(Robot robot, string input = "PLACE 1,1,NORTH")
        {
            var command = _commandFactory.GetCommand(input);
            robot.RunCommand(command, _board);
        }
    }
}
