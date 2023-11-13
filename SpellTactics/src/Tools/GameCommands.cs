using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public delegate void PassObject(object i);
    public delegate object PassObjectAndReturn(object i);
    public static class GameCommands
    {
        public static PassObject PassDestructible;
    }
}
