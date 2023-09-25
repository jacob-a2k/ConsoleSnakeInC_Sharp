using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Map map = new Map();
            //map.PrintMap();

            Point point = new Point(6, 8);
            map.SetToMap(point, 'x');
            map.PrintMap();
        }

    }
}