namespace ToyRobot.Extensions
{
    public static class DirectionExtension
    {
        /// <summary>Method <c>Next</c> return the new Direction after applying Right command.</summary>
        /// <param name="Rotation"> Degree of rotation when applying Right command.</param>
        /// <returns>Returns new direction after applying rotation.</returns>
        ///
        public static Direction Next(this Direction direction, int Rotation = 90)
        {
            int CurrentDirectionValue = (int)direction;
            int newDirection = (CurrentDirectionValue + Rotation) % 360;

            return (Direction)newDirection;
        }

        /// <summary>Method <c>Previous</c> return the new Direction after applying LEFT command.</summary>
        /// <param name="Rotation"> Degree of rotation when applying LEFT command.</param>
        /// <returns>Returns new direction after applying rotation.</returns>
        ///
        public static Direction Previous(this Direction direction, int Rotation = 90)
        {
            int CurrentDirectionValue = (int)direction;

            CurrentDirectionValue = CurrentDirectionValue == 0 ? 360 : CurrentDirectionValue;
            int newDirection = (CurrentDirectionValue - Rotation) % 360;

            return (Direction)newDirection;
        }
    }
}
