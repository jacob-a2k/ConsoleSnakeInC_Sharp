using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    internal class Map
    {
        private char[,] gameMap;
        private int width;
        private int height;
        public Map(int width = 20, int height = 10)
        {
            this.width = width;
            this.height = height;
            this.gameMap = new char[height, width];
            FillMap();
        }
        public void PrintMap()
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
        private void FillMap()
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
        public void SetSignToMap(Point point,char sign)
        {
            gameMap[point.GetY(), point.GetX()] = sign;
        }
        public char GetSignFromMap(Point point)
        {
            return gameMap[point.GetY(), point.GetX()];
        }
        public int GetWidth() { return width; }
        public int GetHeight() { return height; }
    }
}
