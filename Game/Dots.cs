using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Dots
    {
        const char dot = '.';
        const char superDot = '.';
        int pointDot = 10, pointSuperDot = 20;
        public char GetDot { get { return dot; } }
        public char GetSuperDot { get { return superDot; } }
        public int GetPoints(char figure)
        {
            if (figure == dot)
                return pointDot;
            if (figure == superDot)
                return pointSuperDot;
            return 0;
        }
    }
}
