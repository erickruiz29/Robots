using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Interfaces
{
    public interface IRobot : IActor
    {
        bool IsAt(int x, int y);
    }
}
