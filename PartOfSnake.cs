using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnakeGame
{
    public class PartOfSnake
    {
        private Point position;
        private PartOfSnake nextPart;
        public PartOfSnake(Point position)
        {
            this.position = position;
            this.nextPart = null;
        }
        public PartOfSnake(Point position, PartOfSnake nextPart)
        {
            this.position = position;
            this.nextPart = nextPart;
        }
        public PartOfSnake(PartOfSnake previousPart)
        {
            this.position = previousPart.position;
            this.nextPart = previousPart.nextPart;
        }
        public Point GetPosition()
        {
            return this.position;
        }
        public void SetPosition(Point position)
        {
            this.position.SetPointPosition(position);
        }
        public PartOfSnake GetNext()
        {
            return nextPart;
        }
    }
}
