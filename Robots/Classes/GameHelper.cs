using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Robots.Classes;
using Robots.Interfaces;

namespace Robots
{
    public static class GameHelper
    {
        private const string FileName = @"../../arena1.map";
        private const int NumRows = 20;
        private const int NumCols = 20;
        private const int NumBots = 20;
        private const int BotsHealth = 5;
        private const int PlayersHealth = 20;
        private const int PlayersAttack = 2;
        private const int BotsAttack = 1;

        public static class PlayerAction
        {
            public static class Move
            {
                public const int Up = 0;
                public const int Down = 1;
                public const int Left = 2;
                public const int Right = 3;
            }

            public static class Attack
            {
                public const int Up = 4;
                public const int Down = 5;
                public const int Left = 6;
                public const int Right = 7;
            }

            public static class Action
            {
                public const int TakeDamage = 8;
            }
        }

        public static class RobotAction
        {
            public static class Action
            {
                public const int TakeDamage = 8;
            }
        }

        public static string GetFilename()
        {
            return FileName;
        }

        public static int GetNumBots()
        {
            return NumBots;
        }

        public static int GetNumRows()
        {
            return NumRows;
        }

        public static int GetNumCols()
        {
            return NumCols;
        }

        public static int GetBotsHealth()
        {
            return BotsHealth;
        }

        public static int GetBotsAttack()
        {
            return BotsAttack;
        }

        public static int GetPlayersHealth()
        {
            return BotsHealth;
        }

        public static int GetPlayersAttack()
        {
            return BotsAttack;
        }

        public static ConsoleKey GetKeyPress()
        {
            return Console.ReadKey(true).Key;
        }
    }
}
