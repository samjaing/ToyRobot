using ToyRobot.Factory;
using Xunit;

namespace ToyRobotUnitTest
{
    public class CommandTest
    {
        private CommandFactory _commandFactory { get; set; }
        public CommandTest()
        {
            _commandFactory = new CommandFactory();
        }

        [Theory]
        [InlineData("PLACE 3,4,NORTH", true)]
        [InlineData("PLACE 3,4", false)]
        [InlineData("MOVE", false)]
        [InlineData("REPORT", false)]
        [InlineData("LEFT", false)]
        [InlineData("RIGHT", false)]
        public void HasDirectionTest(string inputCommand, bool expectedValue)
        {
            var command = _commandFactory.GetCommand(inputCommand);
            var hasDirection = command.HasDirection();

            Assert.Equal(expectedValue, hasDirection);
        }
    }
}
