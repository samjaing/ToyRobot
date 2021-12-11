namespace ToyRobot
{
    public class Coordinates
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        //public FacePosition Face;

        public Direction? Face { get; set; }
        private Coordinates() { }

        public Coordinates(int xAxis, int yAxis) : base()
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public Coordinates(int xAxis, int yAxis, Direction? face) : this(xAxis, yAxis)
        {
            Face = face;
        }
    }

    //TODO: Implement Clock Positions.
    public struct FacePosition
    {
        short Degree;
        Direction Face;
    }
}
