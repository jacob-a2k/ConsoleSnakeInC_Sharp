using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

            bool error = false; // dlaczego gdybym wstawił 'public' przed typem bool to compilator wyswietla błąd
            Point positionBeforeLoop = new Point(0, 0);
            Point prevPosition = new Point(0, 0);

            Point foodPosition = new Point(0, 0);
            foodPosition = GetNextPositionForFood(map);
            map.SetToMap(foodPosition, 'x');

            char actualDirection = 'd';
            char chosenDirection = actualDirection;
            int nextXpos = 5;
            int nextYpos = 5;
            ConsoleKeyInfo cki;
            while (!error)
            {
                if(Console.KeyAvailable)
                {
                    cki = Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine("Input catch in time: {0}", cki.KeyChar);
                }
            }

        }
        private static Point GetNextPositionForFood(Map map)
        {
            while (true)
            {
                Random rnd = new Random();
                int rndRow = rnd.Next(1, map.GetWidth());
                int rndColumn = rnd.Next(1, map.GetHeight());
                Point foodPosition = new Point(rndRow, rndColumn);
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
    }
}