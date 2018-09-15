using Robots.Interfaces;

namespace Robots.Classes
{
    public class Robot : Person, IRobot
    {

        public Robot()
        {
            _health = GameHelper.GetBotsHealth();
        }

        public bool IsAt(int x, int y)
        {
            return _x == x && _y == y;
        }

        public bool Action(int action)
        {
            switch (action)
            {
                case GameHelper.RobotAction.Action.TakeDamage:
                    _health -= GameHelper.GetPlayersAttack();
                    break;
            }

            return _health <= 0;
        }

    }
}
