using Robots.Interfaces;

namespace Robots.Classes
{
    public class Robot : Actor, IRobot
    {

        public Robot()
        {
            _health = GameHelper.GetBotsHealth();
        }

        public bool IsAt(int x, int y)
        {
            return _x == x && _y == y;
        }

        public override bool Action(int action)
        {
            switch (action)
            {
                case GameHelper.ActorAction.Move.Up:
                    _y = _y - 1;
                    break;
                case GameHelper.ActorAction.Move.Down:
                    _y = _y + 1;
                    break;
                case GameHelper.ActorAction.Move.Left:
                    _x = _x - 1;
                    break;
                case GameHelper.ActorAction.Move.Right:
                    _x = _x + 1;
                    break;
                case GameHelper.ActorAction.Action.TakeDamage:
                    _health -= GameHelper.GetPlayersAttack();
                    break;
            }

            return _health <= 0;
        }

    }
}
