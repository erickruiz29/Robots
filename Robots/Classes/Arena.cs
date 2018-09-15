using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Robots.Interfaces;

namespace Robots.Classes
{
    class Arena : IArena
    {
        private char[][] _arena;
        private char[][] _baseArena;
        private IPlayer _player;
        private IList<IRobot> _robots;

        public Arena(IPlayer player, IList<IRobot> robots)
        {
            _player = player;
            _robots = robots;
            _arena = new char[GameHelper.GetNumRows()][];
            _baseArena = new char[GameHelper.GetNumRows()][];
            PopulateArena();
        }

        public void DrawArena()
        {
            _arena = _baseArena.ToList().Select(a => a.ToArray()).ToArray();

            foreach (var robot in _robots)
            {
                var ch = _arena[robot.GetY()][robot.GetX()];
                switch (ch)
                {
                    case '.':
                        _arena[robot.GetY()][robot.GetX()] = 'R';
                        break;
                    case '1':
                        _arena[robot.GetY()][robot.GetX()] = '2';
                        break;
                    case '2':
                        _arena[robot.GetY()][robot.GetX()] = '3';
                        break;
                    case '3':
                        _arena[robot.GetY()][robot.GetX()] = '4';
                        break;
                    case '4':
                        _arena[robot.GetY()][robot.GetX()] = '5';
                        break;
                    case '5':
                        _arena[robot.GetY()][robot.GetX()] = '6';
                        break;
                    case '6':
                        _arena[robot.GetY()][robot.GetX()] = '7';
                        break;
                    case '7':
                        _arena[robot.GetY()][robot.GetX()] = '8';
                        break;
                    case '8':
                        _arena[robot.GetY()][robot.GetX()] = '9';
                        break;
                    default:
                        continue;
                }

            }

            Console.Clear();
            _arena[_player.GetY()][_player.GetX()] = 'P';

            foreach (var line in _arena)
            {
                Console.Write("\t");
                Console.WriteLine(line);
            }

            Console.WriteLine("Player Health: " + _player.GetHealth() + "\tRobots Left: " + _robots.Count);
        }

        public void PopulateArena()
        {
            var lines = File.ReadAllLines(GameHelper.GetFilename());
            int xp = 0, yp = 0;
            for (var i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];

                if (line.Contains("P"))
                {
                    yp = line.IndexOf("P", StringComparison.InvariantCulture);
                    xp = i;
                    _player.InitLoc(yp, xp);
                }

                _baseArena[i] = line.Replace("P", ".").ToCharArray();
            }
            var rnd = new Random();

            for (var i = 0; i < GameHelper.GetNumBots(); i++)
            {
                var robot = new Robot();

                int x, y;
                char curChar;
                do
                {
                    x = rnd.Next(0, GameHelper.GetNumRows());
                    y = rnd.Next(0, GameHelper.GetNumCols());
                    curChar = _baseArena[y][x];

                } while ((x == xp && y == yp) || curChar == 'X');

                robot.InitLoc(x, y);

                _robots.Add(robot);
            }
        }

        public char GetChar(int x, int y)
        {
            return _arena[y][x];
        }
    }
}
