using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : IMovingFigure, IDisposable
    {
        const char enemyView = '-';
        ConsoleKey[] enemyWay = new[] {
            ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow
        };
        int xEnemy, yEnemy, xEnemyPrevious, yEnemyPrevious;
        public Enemy(int x, int y)
        {
            xEnemyPrevious = xEnemy = x;
            yEnemyPrevious = yEnemy = y;
        }
        public ConsoleKey GetEnemyWay(int index)
        {
            return enemyWay[index];
        }
        public int EnemyWayLength { get { return enemyWay.Length; } }
        public char getFigure { get { return enemyView; } }
        public int XFigure
        {
            get { return xEnemy; }
            set
            {
                xEnemyPrevious = xEnemy;
                xEnemy = value;
            }
        }
        public int YFigure
        {
            get { return yEnemy; }
            set
            {
                yEnemyPrevious = yEnemy;
                yEnemy = value;
            }
        }
        public int XFigurePrevious
        {
            get { return xEnemyPrevious; }
            set { xEnemyPrevious = value; }
        }
        public int YFigurePrevious
        {
            get { return yEnemyPrevious; }
            set { yEnemyPrevious = value; }
        }
        #region realization safedispose
        bool disposed = false;
        public void Dispose()
        {
            xEnemy= yEnemy= xEnemyPrevious= yEnemyPrevious = 0;
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
