using System;
using System.Collections.Generic;
using System.Linq;
using Robots.Interfaces;

namespace Robots.Classes
{
    class Game : IGame
    { 
        private IArena _arena;
        private IPlayer _player;
        private IList<IRobot> _robots;

        public Game()
        {
            ResetGame();
        }

        public string StartGame()
        {
            var IsDead = false;
            while (!IsDead && _robots.Count > 0)
            {
                var keyPress = GameHelper.GetKeyPress();

                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        IsDead = MoveAction(_player, GameHelper.ActorAction.Move.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        IsDead = MoveAction(_player, GameHelper.ActorAction.Move.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        IsDead = MoveAction(_player, GameHelper.ActorAction.Move.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        IsDead = MoveAction(_player, GameHelper.ActorAction.Move.Right);
                        break;
                    case ConsoleKey.W:
                        IsDead = AttackAction(GameHelper.ActorAction.Attack.Up);
                        break;
                    case ConsoleKey.S:
                        IsDead = AttackAction(GameHelper.ActorAction.Attack.Down);
                        break;
                    case ConsoleKey.A:
                        IsDead = AttackAction(GameHelper.ActorAction.Attack.Left);
                        break;
                    case ConsoleKey.D:
                        IsDead = AttackAction(GameHelper.ActorAction.Attack.Right);
                        break;
                }

                var rand = new Random();
                foreach (var robot in _robots)
                {
                    MoveAction(robot, rand.Next(0, 4));
                }

                _arena.DrawArena();
            }

            string k;
            do
            {
                Console.WriteLine("Player again? (y/n)");
                k = Console.ReadLine()?.ToLower();
            } while (k != "y" && k != "n");

            if (k == "n")
            {
                Console.WriteLine("Bye!");
            }

            return k;
        }

        public void ResetGame()
        {
            _player = new Player();
            _robots = new List<IRobot>();
            _arena = new Arena(_player, _robots);
            _arena.DrawArena();
        }

        public void RestartGame()
        {
            ResetGame();
            StartGame();
        }

        public bool MoveAction(IActor actor, int action)
        {
            int xf, yf;
            switch (action)
            {
                case GameHelper.ActorAction.Move.Up:
                    xf = actor.GetX();
                    yf = actor.GetY() - 1;
                    break;
                case GameHelper.ActorAction.Move.Down:
                    xf = actor.GetX();
                    yf = actor.GetY() + 1;
                    break;
                case GameHelper.ActorAction.Move.Left:
                    xf = actor.GetX() - 1;
                    yf = actor.GetY();
                    break;
                case GameHelper.ActorAction.Move.Right:
                    xf = actor.GetX() + 1;
                    yf = actor.GetY();
                    break;
                default:
                    return actor.GetHealth() <= 0;
            }

            // out of bounds
            if (xf < 0 || xf >= GameHelper.GetNumCols() || yf < 0 || yf >= GameHelper.GetNumRows())
            {
                return actor.GetHealth() <= 0; 
            }

            var nextPos = _arena.GetChar(xf, yf);

            //Make sure that player isnt moving to that position, if so attack
            if (actor.GetType() == typeof(Robot) && xf == _player.GetX() && yf == _player.GetY())
            {
                _player.Action(GameHelper.ActorAction.Action.TakeDamage);
                return actor.GetHealth() <= 0;
            }
            // clear spot to move
            if (nextPos == '.')
            {
                return actor.Action(action);
            }
            // run into robot
            if (actor.GetType() == typeof(Player) && nextPos.ToString().IndexOfAny("R123456789".ToCharArray()) != -1)
            {
                return actor.Action(GameHelper.ActorAction.Action.TakeDamage);
            }
            if (actor.GetType() == typeof(Robot) && nextPos.ToString().IndexOfAny("R12345678".ToCharArray()) != -1)
            {
                return actor.Action(action);
            }
            if (actor.GetType() == typeof(Robot) && nextPos == 'P')
            {
                _player.Action(GameHelper.ActorAction.Action.TakeDamage);
            }
            // else ran into wall, do nothing
            return actor.GetHealth() <= 0;
        }

        public bool AttackAction(int action)
        {
            int xf, yf;
            switch (action)
            {
                case GameHelper.ActorAction.Attack.Up:
                    xf = 0;
                    yf = -1;
                    break;
                case GameHelper.ActorAction.Attack.Down:
                    xf = 0;
                    yf = 1;
                    break;
                case GameHelper.ActorAction.Attack.Right:
                    xf = 1;
                    yf = 0;
                    break;
                case GameHelper.ActorAction.Attack.Left:
                    xf = -1;
                    yf = 0;
                    break;
                default:
                    return _player.GetHealth() <= 0;
            }

            // add support for attack distance
            for (var i = 1; i < 4; i++)
            {
                var posX = _player.GetX() + (xf * i);
                var posY = _player.GetY() + (yf * i);

                // Can't attack through walls
                if (_arena.GetChar(posX, posY) == 'X')
                {
                    break;
                }

                var robot = _robots.FirstOrDefault( x => x.IsAt(posX, posY));

                if (robot != null)
                {
                    var isDead = robot?.Action(GameHelper.ActorAction.Action.TakeDamage);

                    if (isDead == true)
                    {
                        _robots.Remove(robot);
                    }
                    break;
                }
            }

            return _player.GetHealth() <= 0;
        }

    }
}
