using System;

namespace TowerDefenseGame.Controllers
{
    using Models;
    using Utilities;
    using System.Windows.Media;
    using TowerDefenseGame.Controllers;
    public static class GameFieldController
    {
        private static FieldSegment[][] gameField = new FieldSegment[Constants.FieldRows][];

        public static FieldSegment[][] GameField
        {
            get
            {
                return GameFieldController.gameField;
            }
        }

        public static void Initialize()
        {
            for (int row = 0; row < Constants.FieldRows; row++)
            {
                GameFieldController.GameField[row] = new FieldSegment[Constants.FieldCols];

                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    GameFieldController.GameField[row][col] = 
                        new FieldSegment(Constants.FieldSegmentSize * col, Constants.FieldSegmentSize * row);
                }
            }
            OccupiedByPath();
            Render();
        }

        public static void Render()
        {
            for (int row = 0; row < Constants.FieldRows; row++)
            {
                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    AnimationController.Renderer.Render(GameFieldController.GameField[row][col]);
                }
            }
        }

        public static void SetGameFieldEvents(MainWindow window)
        {
            for (int row = 0; row < GameFieldController.GameField.Length; row++)
            {
                for (int col = 0; col < GameFieldController.GameField[row].Length; col++)
                {
                    GameFieldController.GameField[row][col].Model.MouseLeftButtonDown += window.GameFieldMouseLeftButtonDown;
                }
            }
        }

        public static void OccupiedByPath()
        {
            //base cordinates
            GameFieldController.GameField[3][26].IsOccupied = true;
            GameFieldController.GameField[3][28].IsOccupied = true;
            GameFieldController.GameField[2][25].IsOccupied = true;
            GameFieldController.GameField[2][26].IsOccupied = true;
            GameFieldController.GameField[2][27].IsOccupied = true;
            GameFieldController.GameField[2][28].IsOccupied = true;
            GameFieldController.GameField[2][29].IsOccupied = true;
            GameFieldController.GameField[1][25].IsOccupied = true;
            GameFieldController.GameField[1][26].IsOccupied = true;
            GameFieldController.GameField[1][27].IsOccupied = true;
            GameFieldController.GameField[1][28].IsOccupied = true;
            GameFieldController.GameField[0][26].IsOccupied = true;
            GameFieldController.GameField[0][27].IsOccupied = true;

            for (int i = 0; i <= EnemyController.EnemyBeacons.Length-2; i++)
            {
                double y2 = EnemyController.EnemyBeacons[i + 1].Y/30;
                double y1 = EnemyController.EnemyBeacons[i].Y/30;
                double x1 = EnemyController.EnemyBeacons[i].X/30;
                double x2 = EnemyController.EnemyBeacons[i + 1].X/30;
                if (Math.Abs(x1 - x2)<=1)
                {
                    if (y1 > y2)
                    {
                        for (double j = y2; j <= y1; j++)
                        {
                            GameFieldController.GameField[(int)(j)][(int)(x2)].IsOccupied = true;
                            
                            
                        }
                    }
                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        for (double j = x2; j <= x1; j++)
                        {
                            GameFieldController.GameField[(int)y1][(int)j].IsOccupied = true;
                        }
                    }
                    else if (x1 < x2)
                    {
                        for (double j = x1; j < x2; j++)
                        {
                            GameFieldController.GameField[(int)(y2)][(int)(j)].IsOccupied = true;
                        }
                    }
                }
            }
        }
    }
}
