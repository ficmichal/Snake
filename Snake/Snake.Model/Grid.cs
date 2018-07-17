using System;
using System.Linq;
using System.Windows.Input;
using static Snake.Snake.Model.Snake;

namespace Snake.Snake.Model
{
    public class Grid
    {
        #region Enums
        public enum GameState { GAME, GAMEOVER };
        public enum Cell { EMPTY, FOOD, SNAKE };
        #endregion

        public GameState State { get; set; }
        public Cell[,] Board { get; set; } = new Cell[20, 20];
        public Snake Snake { get; set; } = new Snake();
        public Direction DirectionSelected { get; set; }

        public Grid()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    Board[i, j] = Cell.EMPTY;

            PlaceSnake();
            PlaceFood();
            DirectionSelected = Direction.LEFT;
            State = GameState.GAME;
        }

        public Cell GetCell(int x, int y)
        {
            if (x >= 0 && x < 20 && y >= 0 && y < 20)
                return Board[x, y];
            else
                throw new ArgumentOutOfRangeException("Poważny błąd, przekroczony zakres tablicy!");
        }

        public void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    DirectionSelected = Direction.UP;
                    break;
                case Key.Down:
                    DirectionSelected = Direction.DOWN;
                    break;
                case Key.Right:
                    DirectionSelected = Direction.RIGHT;
                    break;
                case Key.Left:
                    DirectionSelected = Direction.LEFT;
                    break;
                default:
                    break;
            }
        }
        public void UpdateBoard(object sender, EventArgs e)
        {
            Snake.ChangeDirection(DirectionSelected);
            if (!Snake.Move())
            {
                State = GameState.GAMEOVER;
                return;
            }

            Point i = new Point()
            {
                X = Snake.Body.First<Point>().X,
                Y = Snake.Body.First<Point>().Y
            };

            Cell new_head = Board[i.X, i.Y];

            if (new_head == Cell.SNAKE)
            {
                State = GameState.GAMEOVER;
                return;
            }
            else if (new_head == Cell.EMPTY)
            {
                Board[i.X, i.Y] = Cell.SNAKE;
                Point j = Snake.GetTail();
                Board[j.X, j.Y] = Cell.EMPTY;
                Snake.RemoveTail();
            }
            else if (new_head == Cell.FOOD)
            {
                Board[i.X, i.Y] = Cell.SNAKE;
                PlaceFood();
            }
        }

        private void PlaceFood()
        {
            while (true)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 19);
                int y = rnd.Next(0, 19);
                Cell cell = Board[x, y];

                if (cell == Cell.EMPTY)
                {
                    Board[x, y] = Cell.FOOD;
                    return;
                }
            }
        }

        private void PlaceSnake()
        {
            int length = Snake.GetLength();

            for (int i = 0; i < length; i++)
            {
                int x = Snake.Body[i].X;
                int y = Snake.Body[i].Y;
                Board[x, y] = Cell.SNAKE;
            }
        }

        public int GetScore() => Snake.GetLength() - 2;
    }
}
