using robot_application_v1_definitions.Grid;

namespace robot_application_v1_definitions
{
    public class Robot(int x, int y)
    {
        private readonly Coordinate _position = new(x, y);

        public void IncrementX(int newValue)
        {
            _position.X += newValue;
        }
    
        public void DecrementX(int newValue)
        {
            _position.X -= newValue;
        }
    
        public int GetX()
        {
            return _position.X;
        }
    
        public void IncrementY(int newValue)
        {
            _position.Y += newValue;
        }
    
        public void DecrementY(int newValue)
        {
            _position.Y -= newValue;
        }
        public int GetY()
        {
            return _position.Y;
        }
    }
}

