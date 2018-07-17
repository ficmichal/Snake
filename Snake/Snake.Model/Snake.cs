using System.Collections.Generic;
using System.Linq;

namespace Snake.Snake.Model
{
    public class Snake
    {
        public enum Direction { UP, RIGHT, DOWN, LEFT };
        public List<Point> body { get; set; } = new List<Point>();
        public Direction direction { get; set; }
        public Snake()
        {
            body.AddRange(new List<Point>{
                new Point
            {
                X = 4,
                Y = 5
            },
                new Point
            {
                X = 5,
                Y = 5
            }});
            direction = Direction.LEFT;
        }

        public Point GetTail() => body.Last<Point>();
        public void RemoveTail() => body.Remove(body.Last<Point>());
        public bool Move()
        {
            Point newHead = new Point()
            {
                X = body.First<Point>().X,
                Y = body.First<Point>().Y
            };

            switch (direction)
            {
                case Direction.UP:
                    {
                        newHead.Y -= 1;
                        break;
                    }
                case Direction.DOWN:
                    {
                        newHead.Y += 1;
                        break;
                    }
                case Direction.RIGHT:
                    {
                        newHead.X += 1;
                        break;
                    }
                case Direction.LEFT:
                    {
                        newHead.X -= 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }
            //Too far - Game Over
            if (newHead.Y < 0 || newHead.Y > 19
             || newHead.X < 0 || newHead.X > 19)
                return false;

            body.Insert(0, newHead);

            return true;
        }
        public void ChangeDirection(Direction dir)
        {
            //Blocked change directions.
            if ((direction == Direction.UP && dir == Direction.DOWN) ||
              (direction == Direction.LEFT && dir == Direction.RIGHT) ||
              (direction == Direction.RIGHT && dir == Direction.LEFT) ||
              (direction == Direction.DOWN && dir == Direction.UP))
            {
                return;
            }
            direction = dir;
        }

        public int GetLength() => body.Count;
    }
}
