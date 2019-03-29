using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Snake : GameObject
    {
        public enum Direction
        {
            RIGHT,
            LEFT,
            UP,
            DOWN
        }
        
        public Direction direction;
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color)
        {
            direction = Direction.DOWN;
        }

        public void Move()
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
               body[i].x = body[i - 1].x;
               body[i].y = body[i - 1].y ;
               Console.ForegroundColor = ConsoleColor.Red;
            }

            if (direction == Direction.UP)
                body[0].y--;
            if (direction == Direction.DOWN)
                body[0].y++;
            if (direction == Direction.LEFT)
                body[0].x--;
            if (direction == Direction.RIGHT)
                body[0].x++;
        }

        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow && direction != Direction.DOWN)
                direction = Direction.UP;
            if (keyInfo.Key == ConsoleKey.DownArrow && direction != Direction.UP)
                direction = Direction.DOWN;
            if (keyInfo.Key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
                direction = Direction.LEFT;
            if (keyInfo.Key == ConsoleKey.RightArrow && direction != Direction.LEFT)
                direction = Direction.RIGHT;
          
        }
    }
}
