namespace TowerDefenseGame.Controllers
{
    using System;
    using Models;
    using Models.Enemies;
    using Utilities;

    public static class GameFieldController
    {
        private static FieldSegment[][] gameField = new FieldSegment[Constants.FieldRows][];

        public static FieldSegment[][] GameField
        {
            get
            {
                return gameField;
            }
        }

        public static void Initialize()
        {
            for (int row = 0; row < Constants.FieldRows; row++)
            {
                GameField[row] = new FieldSegment[Constants.FieldCols];

                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    GameField[row][col] = 
                        new FieldSegment(Constants.FieldSegmentSize * col, Constants.FieldSegmentSize * row);
                }
            }

            SetPathOccupation();
            Render();
        }

        public static void Render()
        {
            for (int row = 0; row < Constants.FieldRows; row++)
            {
                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    AnimationController.Renderer.Render(GameField[row][col]);
                }
            }
        }

        public static void SetGameFieldEvents(MainWindow window)
        {
            for (int row = 0; row < GameField.Length; row++)
            {
                for (int col = 0; col < GameField[row].Length; col++)
                {
                    GameField[row][col].Model.MouseLeftButtonDown += window.GameFieldMouseLeftButtonDown;
                }
            }
        }

        public static void SetPathOccupation()
        {
            // The main base occupation
            GameField[3][26].IsOccupied = true;
            GameField[3][28].IsOccupied = true;
            GameField[2][25].IsOccupied = true;
            GameField[2][26].IsOccupied = true;
            GameField[2][27].IsOccupied = true;
            GameField[2][28].IsOccupied = true;
            GameField[2][29].IsOccupied = true;
            GameField[1][25].IsOccupied = true;
            GameField[1][26].IsOccupied = true;
            GameField[1][27].IsOccupied = true;
            GameField[1][28].IsOccupied = true;
            GameField[0][26].IsOccupied = true;
            GameField[0][27].IsOccupied = true;

            for (int i = 0; i <= Enemy.EnemyBeacons.Length - 2; i++)
            {
                double y2 = Enemy.EnemyBeacons[i + 1].Y / 30;
                double y1 = Enemy.EnemyBeacons[i].Y / 30;
                double x1 = Enemy.EnemyBeacons[i].X / 30;
                double x2 = Enemy.EnemyBeacons[i + 1].X / 30;
                if (Math.Abs(x1 - x2) <= 1)
                {
                    if (y1 > y2)
                    {
                        for (double j = y2; j <= y1; j++)
                        {
                            GameField[(int)j][(int)x2].IsOccupied = true;
                        }
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        for (double j = x2; j <= x1; j++)
                        {
                            GameField[(int)y1][(int)j].IsOccupied = true;
                        }
                    }
                    else if (x1 < x2)
                    {
                        for (double j = x1; j < x2; j++)
                        {
                            GameField[(int)y2][(int)j].IsOccupied = true;
                        }
                    }
                }
            }
        }
    }
}
