using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Interfaces
{
    public interface IPlayer : IPerson
    {
        void Action(int action);
    }
}
