using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Interfaces
{
    public interface IActor
    {
        void InitLoc(int x, int y);
        int GetX();
        int GetY();
        double GetHealth();
        bool Action(int action);
    }
}
