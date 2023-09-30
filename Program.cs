using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleSnakeGame
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome.Let's play in SnakeConsoleGame");
            Console.WriteLine("Chose size of map");
            Console.WriteLine("Input width: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input height: ");
            int height = Convert.ToInt32(Console.ReadLine());

            Map map = new Map(width, height);
            Snake snake = new Snake();

            bool error = false;
            Point positionBeforeLoop = new Point(0, 0);
            Point prevPosition = new Point(0, 0);

            Point foodPosition = new Point(0, 0);
            foodPosition.SetPointPosition(GetNextPositionForFood(map));
            map.SetSignToMap(foodPosition, 'x');

            char actualDirection = 'd';
            char chosenDirection = actualDirection;
            int nextXpos = 5;
            int nextYpos = 5;
            int totalNumOfEatenFood = 0;

            while (!error)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();
                    chosenDirection = cki.KeyChar;
                    Console.WriteLine();
                }
                if (IsUserChooseCorrectDirection(chosenDirection, actualDirection))
                {
                    switch (chosenDirection)
                    {
                        case 'd':
                            nextXpos++;
                            break;
                        case 's':
                            nextYpos++;
                            break;
                        case 'w':
                            nextYpos--;
                            break;
                        case 'a':
                            nextXpos--;
                            break;
                        default: Console.WriteLine("Something goes wrong!");
                            Thread.Sleep(1000);
                            error = true;
                            break;
                    }
                    actualDirection = chosenDirection;
                }
                else
                {
                    chosenDirection = actualDirection;
                    continue;
                }
                Point nextPosition = new Point(nextXpos, nextYpos);
                positionBeforeLoop.SetPointPosition(nextPosition);

                if(!IsNextPositionEmpty(map, nextPosition))
                {
                    error = true;
                    map.PrintMap();
                    Console.WriteLine("----- Game Over -----");
                    Thread.Sleep(3000);
                    continue;
                }
                if(nextPosition == foodPosition)
                {
                    totalNumOfEatenFood++;
                    snake.Increase(nextPosition);
                    foodPosition.SetPointPosition(GetNextPositionForFood(map));
                    map.SetSignToMap(foodPosition, 'x');
                }
                PartOfSnake current = new PartOfSnake(snake.GetHead());
                while(current != null)
                {
                    prevPosition.SetPointPosition(current.GetPosition());
                    current.SetPosition(nextPosition);
                    Point position = new Point(current.GetPosition());
                    map.SetSignToMap(position, 'o');
                    nextPosition.SetPointPosition(prevPosition);
                    current = current.GetNext();
                }
                map.SetSignToMap(prevPosition,' ');
                nextPosition.SetPointPosition(positionBeforeLoop);
                Console.Clear();
                map.PrintMap();
                Thread.Sleep(snake.GetSnakeSpeed());
                Console.Clear();
            }
            Console.WriteLine("Congratulation! Your score is {0} points!", totalNumOfEatenFood);
            Console.WriteLine("Write your Name and Surname to put you to scoreboard");
            string name = Console.ReadLine();

            string rootPath = @"D:\dev\dotnet\ConsoleSnakeGame\WinnerList.txt";
            List<string> lines = File.ReadAllLines(rootPath).ToList();
            lines.Add($"{name} - score: {totalNumOfEatenFood}");
            Console.Clear();
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines(rootPath, lines);
        }
        private static Point GetNextPositionForFood(Map map)
        {
            while (true)
            {
                Random rnd = new Random();
                int rndRow = rnd.Next(1, map.GetHeight() -1);
                int rndColumn = rnd.Next(1, map.GetWidth() -1);
                Point foodPosition = new Point(rndColumn, rndRow);
                if (IsEmptyLocationForFood(map, foodPosition)) { return foodPosition; }
            }
        }
        private static bool IsEmptyLocationForFood(Map map, Point point)
        {
            if(map.GetSignFromMap(point) == ' ')
            {
                return true;
            }
            return false;
        }
        public static bool KeyAvailable { get; }
        public static bool IsUserChooseCorrectDirection(char chosenDirection, char actualDirection)
        {
            if (IsUserChoseCorectSign(chosenDirection))
            {
                if (actualDirection == 'd' && chosenDirection == 'a' ||
                    actualDirection == 'a' && chosenDirection == 'd' ||
                    actualDirection == 's' && chosenDirection == 'w' ||
                    actualDirection == 'w' && chosenDirection == 's')
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static bool IsUserChoseCorectSign(char dir)
        {
            if (dir == 'a' || dir == 's' || dir == 'd' || dir == 'w')
            {
                return true;
            }
            return false;
        }
        private static bool IsNextPositionEmpty(Map map, Point point)
        {
            if(map.GetSignFromMap(point) == '|' || map.GetSignFromMap(point) == '-'
                                                || map.GetSignFromMap(point) == 'o')
            {
                return false;
            }
            return true;
        }
    }
}