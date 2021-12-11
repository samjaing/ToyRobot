namespace ToyRobot.Commands
{
    public interface ICommand
    {
        public Coordinates GetResultantCoordinates(Coordinates CurrentPosition);
        public bool HasDirection();
    }
}
