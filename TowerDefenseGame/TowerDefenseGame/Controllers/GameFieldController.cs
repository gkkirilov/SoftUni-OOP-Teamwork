namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Models;

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

            GameFieldController.GameField[10][2].Model.Fill = Brushes.Brown;
            GameFieldController.GameField[1][2].Model.Fill = Brushes.Brown;
            GameFieldController.GameField[1][7].Model.Fill = Brushes.Brown;
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
    }
}
