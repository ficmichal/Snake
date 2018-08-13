using System.Collections.Generic;
using System.Linq;

namespace Snake.Snake.Model
{
    public class Snake
    {
        public enum Direction { UP, RIGHT, DOWN, LEFT };
        public List<Point> Body { get; set; } = new List<Point>();
        public Direction DirectionOfSnake { get; set; }
        public Snake()
        {
            Body.AddRange(new List<Point>{
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
            DirectionOfSnake = Direction.LEFT;
        }

        public Point GetTail() => Body.Last<Point>();
        public void RemoveTail() => Body.Remove(Body.Last<Point>());
        public bool Move()
        {
            Point newHead = new Point()
            {
                X = Body.First<Point>().X,
                Y = Body.First<Point>().Y
            };

            switch (DirectionOfSnake)
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

            Body.Insert(0, newHead);

            return true;
        }
        public void ChangeDirection(Direction dir)
        {
            //Blocked change Directions.
            if ((DirectionOfSnake == Direction.UP && dir == Direction.DOWN) ||
              (DirectionOfSnake == Direction.LEFT && dir == Direction.RIGHT) ||
              (DirectionOfSnake == Direction.RIGHT && dir == Direction.LEFT) ||
              (DirectionOfSnake == Direction.DOWN && dir == Direction.UP))
            {
                return;
            }
            DirectionOfSnake = dir;
        }

        public int GetLength() => Body.Count;
    }
}
