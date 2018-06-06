using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game
{

    public class Position
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
    class Program
    {
        public static List<Position> squarePos = new List<Position>();
        public static int xP = 0, yP = 0;
        public static int xE = 20, yE = 20;
        static void Main(string[] args)
        {
            ConsoleKey[] enemyWay = new[] { ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow };
            int maxFieldX = 30, maxFieldY = 30;
            Random wayRnd = new Random();
            Console.SetWindowSize(maxFieldX, maxFieldY);
            const char toWrite = '*';
            const char enemyWrite = '-';

            Write(toWrite,xP,yP);
            //WriteEnemy(enemyWrite,xE,yE);
            while (true)
            {
                //checkKey(enemyWay[wayRnd.Next(enemyWay.Length)], xE, yE);
                //WriteEnemy(enemyWrite,xE,yE);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                checkKey(keyInfo.Key, xP, yP);
                //switch (keyInfo.Key)
                //{
                //    case ConsoleKey.DownArrow:
                //        if (!checkPosition(x, y + 1))
                //            y++;

                //        break;
                //    case ConsoleKey.UpArrow:

                //        if (y > 0)
                //        {
                //            if (!checkPosition(x, y - 1))
                //                y--;
                //        }
                //        break;
                //    case ConsoleKey.LeftArrow:
                //        if (x > 0)
                //        {
                //            if (!checkPosition(x - 1, y))
                //                x--;
                //        }
                //        break;
                //    case ConsoleKey.RightArrow:
                //        if (!checkPosition(x + 1, y))
                //            x++;
                //        break;
                //}
                Write(toWrite, xP, yP);
            }

        }

        public static void checkKey(ConsoleKey consoleKey, int x, int y)
        {
            switch (consoleKey)
            {
                case ConsoleKey.DownArrow:
                    if (!checkPosition(x, y + 1))
                        y++;
                    break;
                case ConsoleKey.UpArrow:
                    if (y > 0)
                    {
                        if (!checkPosition(x, y - 1))
                            y--;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (x > 0)
                    {
                        if (!checkPosition(x - 1, y))
                            x--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (!checkPosition(x + 1, y))
                        x++;
                    break;
            }
        }
        public static void WriteEnemy(char enemy, int x , int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(enemy);
            }
            catch (Exception e)
            {

            }
        }
        public static void Write(char toWrite, int x, int y)
        {
            try
            {
                if ((x >= 0 && y >= 0))
                {
                    Console.Clear();
                    PrintSquare();
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static bool checkPosition( int x, int y)
        {
            bool contains = false;
            foreach (Position item in squarePos)
            {
                if (item.PosX == x && item.PosY == y)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        public static void PrintSquare()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    squarePos.Add(new Position() { PosX = 10 + i, PosY = 10 + j });
                    Console.SetCursorPosition(10 + i, 10 + j);

                    Console.Write('+');
                }
                Console.WriteLine();
            }
        }
    }
}
