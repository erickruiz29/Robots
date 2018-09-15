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
            while (_player.GetHealth() > 0)
            {
                var keyPress = GameHelper.GetKeyPress();

                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        MoveAction(GameHelper.PlayerAction.Move.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveAction(GameHelper.PlayerAction.Move.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveAction(GameHelper.PlayerAction.Move.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveAction(GameHelper.PlayerAction.Move.Right);
                        break;
                    case ConsoleKey.W:
                        AttackAction(GameHelper.PlayerAction.Attack.Up);
                        break;
                    case ConsoleKey.S:
                        AttackAction(GameHelper.PlayerAction.Attack.Down);
                        break;
                    case ConsoleKey.A:
                        AttackAction(GameHelper.PlayerAction.Attack.Left);
                        break;
                    case ConsoleKey.D:
                        AttackAction(GameHelper.PlayerAction.Attack.Right);
                        break;
                }

                _arena.DrawArena();
            }

            string k;
            do
            {
                Console.WriteLine("Player again? (y/n)");
                k = Console.ReadLine()?.ToLower();
            } while (k != "y" && k != "n");

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

        public void MoveAction(int action)
        {
            int xf, yf;
            switch (action)
            {
                case GameHelper.PlayerAction.Move.Up:
                    xf = _player.GetX();
                    yf = _player.GetY() - 1;
                    break;
                case GameHelper.PlayerAction.Move.Down:
                    xf = _player.GetX();
                    yf = _player.GetY() + 1;
                    break;
                case GameHelper.PlayerAction.Move.Left:
                    xf = _player.GetX() - 1;
                    yf = _player.GetY();
                    break;
                case GameHelper.PlayerAction.Move.Right:
                    xf = _player.GetX() + 1;
                    yf = _player.GetY();
                    break;
                default:
                    return;
            }

            // out of bounds
            if (xf < 0 || xf >= GameHelper.GetNumCols() || yf < 0 || yf >= GameHelper.GetNumRows())
            {
                return;
            }

            var nextPos = _arena.GetChar(xf, yf);

            // clear spot to move
            if (nextPos == '.')
            {
                _player.Action(action);
            }
            // run into robot
            else if (nextPos.ToString().IndexOfAny("R123456789".ToCharArray()) != -1)
            {
                _player.Action(GameHelper.PlayerAction.Action.TakeDamage);
            }
            // else ran into wall, do nothing
        }

        public void AttackAction(int action)
        {
            int xf, yf;
            switch (action)
            {
                case GameHelper.PlayerAction.Attack.Up:
                    xf = 0;
                    yf = -1;
                    break;
                case GameHelper.PlayerAction.Attack.Down:
                    xf = 0;
                    yf = 1;
                    break;
                case GameHelper.PlayerAction.Attack.Right:
                    xf = 1;
                    yf = 0;
                    break;
                case GameHelper.PlayerAction.Attack.Left:
                    xf = -1;
                    yf = 0;
                    break;
                default:
                    return;
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
                    var isDead = robot?.Action(GameHelper.RobotAction.Action.TakeDamage);

                    if (isDead == true)
                    {
                        _robots.Remove(robot);
                    }
                    break;
                }
            }
        }

    }
}
