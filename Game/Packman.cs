using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Packman : IMovingFigure, IDisposable
    {
        const char packmanView = '*';
        int totalPoints = 0;
        int xPackman, yPackman, xPackmanPrevious, yPackmanPrevious;

        public Packman(int x, int y)
        {
            xPackmanPrevious = xPackman = x;
            yPackmanPrevious = yPackman = y;
        }
        public int Points
        {
            get { return totalPoints; }
            set { totalPoints += value; }
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
        #region realization safedispose
        bool disposed = false;
        public void Dispose()
        {
            totalPoints = xPackman = yPackman = xPackmanPrevious = yPackmanPrevious = 0;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
                handle.Dispose();
            disposed = true;
        }
        #endregion
    }
}
