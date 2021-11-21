using System;
using System.Collections.Generic;
using System.Text;

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
