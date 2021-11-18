using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Coordinates
    {

        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public Direction? Face { get; set; }
        public Coordinates()
        { }

        public Coordinates(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }
        public Coordinates(int xAxis, int yAxis, Direction? face)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            Face = face;
        }
    }
}
