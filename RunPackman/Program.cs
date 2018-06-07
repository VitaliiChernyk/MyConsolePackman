using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
namespace RunPackman
{
    class Program
    {
        static Blocks blocks = new Blocks();
        static void Main(string[] args)
        {
            Packman packman = new Packman(0, 0);
            Enemy enemy = new Enemy(5, 5);
            WriteEnemy(enemy);
            
            //write packman
            Write(packman.getFigure, packman.XFigure, packman.YFigure, packman.XFigurePrevious, packman.YFigurePrevious);
            
            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey().Key;
                packman.XFigure = checkKeyX(pressedKey, packman.XFigure, packman.YFigure);
                packman.YFigure = checkKeyY(pressedKey, packman.YFigure, packman.XFigure);
                //write packman
                Write(packman.getFigure, packman.XFigure, packman.YFigure,packman.XFigurePrevious,packman.YFigurePrevious);
            }
        }
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
                    if (!blocks.CkeckIfNotABlock(x + 1, y))
                        x++;
                    break;
            }
            return x;
        }
        public static int checkKeyY(ConsoleKey consoleKey, int y, int x)
        {
            switch (consoleKey)
            {
                case ConsoleKey.DownArrow:
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
        public static void Write(char toWrite, int x, int y, int xPrevious, int yPrevious)
        {
            try
            {
                if ((x >= 0 && y >= 0))
                {
                    Console.SetCursorPosition(xPrevious, yPrevious);
                    Console.Write(' ');
                    //Console.Clear();
                    blocks.PrintBlocks();
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void WriteEnemy(Enemy enemy)
        {
            lock (enemy)
            {
                Write(enemy.getFigure, enemy.XFigure, enemy.YFigure, enemy.XFigurePrevious, enemy.YFigurePrevious);
                //Console.SetCursorPosition(enemy.XFigure, enemy.YFigure);
                //Console.Write(enemy.getFigure);
            }
        }
    }
}
