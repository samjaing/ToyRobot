using System;
using System.Collections.Generic;
using System.Text;

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
