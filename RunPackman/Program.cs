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

        
        static int winsizeX = 50, winsizeY = 50;

        static void Main(string[] args)
        {
            Blocks blocks = new Blocks();
            Console.SetWindowSize(winsizeX, winsizeY);
            blocks.PrintBlocks(winsizeX, winsizeY);

            Packman packman = new Packman(0, 0);
            Enemy enemy = new Enemy(5, 5);
            GameLogic gameLogic = new GameLogic(blocks, winsizeX, winsizeY);
            Thread threadEnemy = new Thread(() =>
            {
                //write Enemy
                gameLogic.WriteEnemy(enemy, packman);
            });
            threadEnemy.IsBackground = true;
            threadEnemy.Name = "Enemy thread";
            threadEnemy.Start();

            Thread threadMain = new Thread(() =>
            {
                //write packman
                gameLogic.WritePackman(packman, enemy);
            });
            threadMain.Name = "Packman Main thread";
            threadMain.Start();
        }
        #region check position
        //method checkKeyX

        //checkKeyY

        #endregion
        //method Write

        //method WritePackman

        //method FiguresNotMeeted

        //method WriteEnemy


    }
}
