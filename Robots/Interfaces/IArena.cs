using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Robots.Classes;

namespace Robots.Interfaces
{
    public interface IArena
    {
        void DrawArena();
        char GetChar(int x, int y);
    }
}
