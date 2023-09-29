using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public class Point
    {
        private int x;
        private int y;

        public Point(Point point)
        {
            this.x = point.x;
            this.y = point.y;
        }
        public Point(int x = 5, int y = 5)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX() { return x;}
        public int GetY() { return y;}
        public void SetPointPosition(Point point)
        {
            this.x = point.x;
            this.y = point.y;
        }
        public static bool operator==(Point firstPoint, Point secondPoint)
        {
            return (firstPoint.GetX() == secondPoint.GetX() 
                && firstPoint.GetY() == secondPoint.GetY() );
        }
        public static bool operator!=(Point firstPoint, Point secondPoint)
        {
            return (firstPoint.x != secondPoint.x
                && firstPoint.y != secondPoint.y);
        }
    }
}
