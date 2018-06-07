using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Packman : IMovingFigure
    {
        const char packmanView = '*';
        int xPackman, yPackman, xPackmanPrevious, yPackmanPrevious;
        public Packman(int x, int y)
        {
            xPackmanPrevious -= xPackman = x;
            yPackmanPrevious -= yPackman = y;
        }
        public char getFigure { get { return packmanView; } }
        public int XFigure
        {
            get { return xPackman; }
            set
            {
                xPackmanPrevious = xPackman;
                xPackman = value;
            }
        }
        public int YFigure
        {
            get { return yPackman; }
            set
            {
                yPackmanPrevious = yPackman;
                yPackman = value;
            }
        }
        public int XFigurePrevious { get { return xPackmanPrevious; } set { xPackmanPrevious = value; } }
        public int YFigurePrevious { get { return yPackmanPrevious; } set { yPackmanPrevious = value; } }
    }
}
