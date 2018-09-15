using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Interfaces
{
    public interface IGame
    {
        string StartGame();
        void ResetGame();
        void RestartGame();
        void MoveAction(int action);
        void AttackAction(int action);
    }
}
