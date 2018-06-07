using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : IMovingFigure
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
    }
}
