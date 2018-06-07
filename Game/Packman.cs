using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Packman
    {
        const char packmanView = '*';
        int xPackman, yPackman ;
        public char getPackman { get { return packmanView; } }
        public int XPackman
        {
            get { return xPackman; }
            set { xPackman = value; }
        }
        public int YPackman
        {
            get { return yPackman; }
            set { yPackman = value; }
        }
    }
}
