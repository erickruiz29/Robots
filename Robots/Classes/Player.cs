using Robots.Interfaces;

namespace Robots.Classes
{
    public class Player : Actor, IPlayer
    {

        public Player()
        {
            _health = 100;
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
                    _health -= GameHelper.GetBotsAttack();
                    break;
            }

            return _health <= 0;
        }
    }
}
