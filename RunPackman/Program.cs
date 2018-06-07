using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace RunPackman
{
    class Program
    {
        private static ManualResetEvent _stopper = new ManualResetEvent(false);
        static Blocks blocks = new Blocks();
        static Thread threadMain = null;
        static int winsizeX = 50, winsizeY = 50;
        static void Main(string[] args)
        {
            Console.SetWindowSize(winsizeX, winsizeY);
            blocks.PrintBlocks(winsizeX, winsizeY);

            Packman packman = new Packman(0, 0);
            Enemy enemy = new Enemy(5, 5);

            threadMain = new Thread(() =>
            {
                //write Enemy
                WriteEnemy(enemy, packman);
                //write packman
                WritePackman(packman, enemy);
            });
            threadMain.Name = "Packman Main thread";
            threadMain.Start();
        }
        #region check position
        public static int checkKeyX(ConsoleKey consoleKey, int x, int y)
        {
            switch (consoleKey)
            {
                case ConsoleKey.LeftArrow:
                    if (x > 0)
                    {
                        if (!blocks.CkeckIfNotABlock(x - 1, y))
                            x--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (x <= winsizeX)
                        if (!blocks.CkeckIfNotABlock(x + 1, y))
                            x++;
                    break;
            }
            return x;
        }
        public static int checkKeyY(ConsoleKey consoleKey, int x, int y)
        {
            switch (consoleKey)
            {
                case ConsoleKey.DownArrow:
                    if (y <= winsizeY)
                        if (!blocks.CkeckIfNotABlock(x, y + 1))
                            y++;
                    break;
                case ConsoleKey.UpArrow:
                    if (y > 0)
                    {
                        if (!blocks.CkeckIfNotABlock(x, y - 1))
                            y--;
                    }
                    break;
            }
            return y;
        }
        #endregion
        public static void Write(char toWrite, int x, int y, int xPrevious, int yPrevious)
        {
            try
            {
                //if ((x >= 0 && y >= 0) &&(x<winsizeX&&y<winsizeY))
                //{
                Console.SetCursorPosition(xPrevious, yPrevious);
                Console.Write(' ');
                Console.SetCursorPosition(x, y);
                Console.Write(toWrite);
                //}
            }
            catch (Exception ex)
            {

            }
        }
        public static void WritePackman(Packman packman, Enemy enemy)
        {
            Write(packman.getFigure, packman.XFigure, packman.YFigure, packman.XFigurePrevious, packman.YFigurePrevious);

            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey().Key;

                packman.XFigure = checkKeyX(pressedKey, packman.XFigure, packman.YFigure);
                packman.YFigure = checkKeyY(pressedKey, packman.XFigure, packman.YFigure);

                Write(packman.getFigure, packman.XFigure, packman.YFigure, packman.XFigurePrevious, packman.YFigurePrevious);
                //check if packman and not meeted
                FiguresNotMeeted(enemy, packman);
            }
        }
        static void FiguresNotMeeted(Enemy enemy, Packman packman)
        {
            if (enemy.XFigure == packman.XFigure && enemy.YFigure == packman.YFigure)
            {
                packman.Dispose();
                enemy.Dispose();
                Console.WriteLine("End Game");
                Console.ReadKey();
            }
        }
        public static void WriteEnemy(Enemy enemy, Packman packman)
        {
            Random random = new Random();
            ConsoleKey enemyWay = ConsoleKey.RightArrow;
            Thread threadEnemy = new Thread(delegate ()
            {
                Write(enemy.getFigure, enemy.XFigure, enemy.YFigure, enemy.XFigurePrevious, enemy.YFigurePrevious);
                while (true)
                {
                    lock (enemy)
                    {
                        enemyWay = enemy.GetEnemyWay(random.Next(enemy.EnemyWayLength));

                        enemy.XFigure = checkKeyX(enemyWay, enemy.XFigure, enemy.YFigure);
                        enemy.YFigure = checkKeyY(enemyWay, enemy.XFigure, enemy.YFigure);

                        Write(enemy.getFigure, enemy.XFigure, enemy.YFigure, enemy.XFigurePrevious, enemy.YFigurePrevious);
                        FiguresNotMeeted(enemy, packman);
                        Thread.Sleep(500);
                    }
                }
            });
            threadEnemy.Name = "Enemy thread";
            threadEnemy.IsBackground = true;
            threadEnemy.Start();
        }

    }
}
