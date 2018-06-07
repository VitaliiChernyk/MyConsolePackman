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
            Packman packman = new Packman();
            packman.XPackman = packman.YPackman = 0;
            Write(packman.getPackman, packman.XPackman, packman.YPackman);
            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey().Key;
                packman.XPackman = checkKeyX(pressedKey, packman.XPackman, packman.YPackman);
                packman.YPackman = checkKeyY(pressedKey, packman.YPackman, packman.XPackman);
                Write(packman.getPackman, packman.XPackman, packman.YPackman);
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
        public static int checkKeyY(ConsoleKey consoleKey, int y,int x)
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
        public static void Write(char toWrite, int x, int y)
        {
            try
            {
                if ((x >= 0 && y >= 0))
                {
                    Console.Clear();
                    blocks.PrintBlocks();
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
