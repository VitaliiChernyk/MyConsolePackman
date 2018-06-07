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
        List<Position> blocksPos = new List<Position>();
        public void PrintBlocks()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    blocksPos.Add(new Position() { PosX = 10 + i, PosY = 10 + j });
                    Console.SetCursorPosition(10 + i, 10 + j);

                    Console.Write('+');
                }
                Console.WriteLine();
            }
        }


        public char GetBlock { get { return block; } }
        public void AddBlocks(int posX, int posY)
        {
            blocksPos.Add(new Position() { PosX = posX, PosY = posY });
        }
        public bool CkeckIfNotABlock(int x, int y)
        {
            bool contains = false;
            foreach (Position item in blocksPos)
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
