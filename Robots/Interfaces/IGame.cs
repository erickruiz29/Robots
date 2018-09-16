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
        bool MoveAction(IActor actor, int action);
        bool AttackAction(int action);
    }
}
