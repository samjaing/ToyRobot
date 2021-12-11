namespace ToyRobot.Exceptions
{
    public class NotPlacedException : BusinessException
    {
        public NotPlacedException() { }

        public NotPlacedException(string name)
            : base(name)
        {

        }
    }
}
