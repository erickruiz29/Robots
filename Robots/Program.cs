using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robots.Classes;

namespace Robots
{
    class Program
    {
        static int Main(string[] args)
        {

            var game = new Game();
            var goAgain = game.StartGame();

            if (goAgain.Equals("y"))
            {
                game.RestartGame();
            }

            return 0;

            /*
             * Game is created
             * -> Arena is populated
             * -> Robots are instantiated and placed on arena
             * -> Player is instantiated and placed on arena
             *
             * Game init loop:
             *  -> Wait for user input (move up down left right, attack up down left right)
             *  -> execute player actions, then execute robot actions
             *  -> update arena and display
             */
        }
    }
}
