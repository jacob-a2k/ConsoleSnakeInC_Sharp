using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public class Snake
    {
        private int size;
        private int speed;
        private PartOfSnake head;
        private void IncreaseSnakeSpeed() { speed = speed / 2; }
        public Snake(int size = 1, int speed = 100)
        {
            this.size = size;
            this.speed = speed;
            Point headPosition = new Point(5, 5);
            head = new PartOfSnake(headPosition);
        }
        public PartOfSnake GetHead() { return head; }
        public void SetHead(PartOfSnake newHead) { head = newHead; }
        public void Increase(Point position)
        {
            PartOfSnake tmp = new PartOfSnake(head);
            PartOfSnake newPartOfSnake = new PartOfSnake(position, head);
            head = newPartOfSnake;
            if (size % 5 == 0) { IncreaseSnakeSpeed(); }
        }
        public int GetSnakeSize() { return size; }
        public int GetSnakeSpeed() { return speed; }
    }
}
