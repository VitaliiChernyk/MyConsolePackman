using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Blocks
    {
        char block = '+';
        List<Positions> blocksPos = new List<Positions>();
        public void PrintBlocks(int winSizeX, int winSizeY)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    blocksPos.Add(new Positions() { PosX = 10 + i, PosY = 10 + j });
                    Console.SetCursorPosition(10 + i, 10 + j);
                    Console.Write('+');
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 5; i++)
            {
                blocksPos.Add(new Positions() { PosX = i, PosY = 5 });
                Console.SetCursorPosition(i, 5);
                Console.Write('+');
            }
            for (int i = 0; i < 5; i++)
            {
                blocksPos.Add(new Positions() { PosX = 8, PosY = i });
                Console.SetCursorPosition(8, i);
                Console.Write('+');
            }
            for (int i = 0; i < winSizeY; i++)
            {
                blocksPos.Add(new Positions() { PosX = 20, PosY = i });
                Console.SetCursorPosition(20, i);
                Console.Write('+');
            }
            blocksPos.OrderBy(o => o.PosX).OrderBy(o => o.PosY);
        }


        public char GetBlock { get { return block; } }
        public void AddBlocks(int posX, int posY)
        {
            blocksPos.Add(new Positions() { PosX = posX, PosY = posY });
        }
        public bool CkeckIfNotABlock(int x, int y)
        {
            bool contains = false;
            foreach (Positions item in blocksPos)
            {
                if (item.PosX == x && item.PosY == y)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
    }
}
