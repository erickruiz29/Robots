using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Interfaces
{
    public interface IRobot : IPerson
    {
        bool IsAt(int x, int y);
        bool Action(int action);
    }
}
