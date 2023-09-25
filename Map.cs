using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    internal class Map
    {
        char[,] gameMap;
        int width;
        int height;
        public Map(int width = 20, int height = 10)
        {
            this.width = width;
            this.height = height;
            this.gameMap = new char[height, width];
            fillMap();
        }
        public void printMap()
        {
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write(gameMap[i,j]);
                }
                Console.WriteLine();
            }
        }
        private void fillMap()
        {
            gameMap[0,0] = '+';
            for (int i = 1; i < width - 1; ++i)
            {
                gameMap[0,i] = '-';
            }
            gameMap[0,width - 1] = '+';
            for (int j = 1; j < height - 1; ++j)
            {
                gameMap[j,0] = '|';
                for (int i = 1; i < width - 1; ++i)
                {
                    gameMap[j,i] = ' ';
                }
                gameMap[j,width - 1] = '|';
            }
            gameMap[height - 1,0] = '+';
            for (int i = 1; i < width - 1; ++i)
            {
                gameMap[height - 1,i] = '-';
            }
            gameMap[height - 1,width - 1] = '+';
        }
    }
}
