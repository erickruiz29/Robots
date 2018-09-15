using Robots.Interfaces;

namespace Robots.Classes
{
    public class Player : Person, IPlayer
    {

        public Player()
        {
            _health = 100;
        }

        public void Action(int action)
        {
            switch (action)
            {
                case GameHelper.PlayerAction.Move.Up:
                    _y = _y - 1;
                    break;
                case GameHelper.PlayerAction.Move.Down:
                    _y = _y + 1;
                    break;
                case GameHelper.PlayerAction.Move.Left:
                    _x = _x - 1;
                    break;
                case GameHelper.PlayerAction.Move.Right:
                    _x = _x + 1;
                    break;
                case GameHelper.PlayerAction.Action.TakeDamage:
                    _health -= GameHelper.GetBotsAttack();
                    break;
            }
        }
    }
}
