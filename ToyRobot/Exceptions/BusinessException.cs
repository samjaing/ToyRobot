using System;

namespace ToyRobot.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string name)
            : base(name)
        {

        }
    }
}
