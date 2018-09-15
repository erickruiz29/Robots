using Robots.Interfaces;

namespace Robots.Classes
{
    public class Person : IPerson
    {
        protected int _x;
        protected int _y;
        protected double _health;

        public Person()
        {
            _x = -1;
            _y = -1;
        }

        public void InitLoc(int x, int y)
        {
            if (_x == -1 && _y == -1)
            {
                _x = x;
                _y = y;
            }
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public double GetHealth()
        {
            return _health;
        }
    }
}
