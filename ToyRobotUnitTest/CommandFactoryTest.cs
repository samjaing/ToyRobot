using System;
using System.Linq;
using ToyRobot.Commands;
using ToyRobot.Enumerations;
using ToyRobot.Factory;
using Xunit;

namespace ToyRobotUnitTest
{
    public class CommandFactoryTest
    {
        private CommandFactory _commandFactory { get; set; }

        public CommandFactoryTest()
        {
            _commandFactory = new CommandFactory();
        }
        
        [Theory]
        [InlineData("LEFT",CommandDescription.LEFT)]
        [InlineData("RIGHT", CommandDescription.RIGHT)]
        [InlineData("PLACE", CommandDescription.PLACE)]
        [InlineData("MOVE", CommandDescription.MOVE)]
        [InlineData("REPORT", CommandDescription.REPORT)]
        public void GetCommandTypeShouldPass(string inputCommand, CommandDescription expectedValue)
        {
            var actualCommand = _commandFactory.GetCommandType(inputCommand);

            Assert.Equal(actualCommand, expectedValue);
        }

        [Theory]
        [InlineData("left")]
        [InlineData("right")]
        [InlineData("place")]
        [InlineData("move")]
        [InlineData("report")]
        [InlineData("")]
        [InlineData(null)]
        public void GetCommandTypeShouldFail(string inputCommand)
        {
            Assert.Throws<ArgumentException>(() => _commandFactory.GetCommandType(inputCommand));
        }

        [Theory]
        [InlineData("LEFT", 1)]
        [InlineData("RIGHT", 1)]
        [InlineData("MOVE", 1)]
        [InlineData("REPORT", 1)]
        [InlineData("PLACE 1,2", 3)]
        [InlineData("PLACE 1,2,NORTH", 4)]
        [InlineData(" PLACE   1, 2 ,  SOUTH", 4)]    // Testing for irregular spaces
        public void ParseCommandShouldPass(string inputCommand ,int expectedCount)
        {
            var parsedCommandResult = _commandFactory.ParseCommand(inputCommand);
            Assert.Equal(parsedCommandResult.ToList().Count(), expectedCount);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ParseCommandShouldFail(string inputCommand)
        {
            Assert.Throws<ArgumentException>(() => _commandFactory.ParseCommand(inputCommand));
        }

        [Theory]
        [InlineData("LEFT", typeof(LeftCommand))]
        [InlineData("RIGHT", typeof(RightCommand))]
        [InlineData("MOVE", typeof(MoveCommand))]
        [InlineData("PLACE 1,2", typeof(PlaceCommand))]
        [InlineData("PLACE 1,2,NORTH", typeof(PlaceCommand))]
        [InlineData("REPORT", typeof(ReportCommand))]
        public void GetCommandShouldPass(string inputCommand, Type expectedType)
        {
            ICommand command = _commandFactory.GetCommand(inputCommand);
            Assert.Equal(expectedType, command.GetType());
        }
        
        [Theory]
        [InlineData("LEFT 1,3")]
        [InlineData("RIGHT 3,2")]
        [InlineData("MOVE NORTH")]
        [InlineData("PALCE 1,2,SOUTHEAST")]
        [InlineData("PALCE 1,2.3")]
        [InlineData("REPORT MOVE")]
        public void GetCommandShouldFail(string inputCommand)
        {
            Assert.Throws<ArgumentException>(() => _commandFactory.GetCommand(inputCommand));
        }
    }
}
