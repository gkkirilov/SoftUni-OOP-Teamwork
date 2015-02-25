using System.Windows.Forms;

namespace TowerDefenseGame
{
    using System.Media;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Controllers;
    using Core;
    using Enumerations;
    using Models;
    using Utilities;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Engine engine;

        public MainWindow()
        {
            this.InitializeComponent();
            AnimationController.ConfigureRenderer(this.MainCanvas);
            this.engine = new Engine();
            GameFieldController.SetGameFieldEvents(this);
        }

        public void GameFieldMouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle model = (Rectangle)sender;
            FieldSegment fieldSegment = null;

            for (int row = 0; row < Constants.FieldRows; row++)
            {
                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    if (GameFieldController.GameField[row][col].Model.Equals(model))
                    {
                        if (GameFieldController.GameField[row][col].IsOccupied)
                        {
                            return;
                        }
                        else
                        {
                            GameFieldController.GameField[row][col].IsOccupied = true;
                        }
                    }
                }
            }

            for (int col = 0; col < Constants.FieldCols; col++)
            {
                var selection = GameFieldController.GameField.Select(f => f[col]).Where(f => f.Model == model);
                if (selection.Any())
                {
                    fieldSegment = selection.First();
                    break;
                }
            }

            if (fieldSegment == null || fieldSegment.FieldType != FieldType.Regular)
            {
                return;
            }

            double x = Canvas.GetLeft(model);
            double y = Canvas.GetTop(model);
            bool hasGenerated = TowerController.GenerateTower(x, y);

            if (hasGenerated)
            {
                TowerController.Towers[TowerController.Towers.Count - 1].Model.MouseLeftButtonDown += TowerMouseButtonDown;

                for (int row = 0; row < Constants.FieldRows; row++)
                {
                    for (int col = 0; col < Constants.FieldCols; col++)
                    {
                        if (GameFieldController.GameField[row][col].Model.Equals(model))
                        {
                            if (GameFieldController.GameField[row][col].IsOccupied)
                            {
                                return;
                            }
                            else
                            {
                                GameFieldController.GameField[row][col].IsOccupied = true;
                            }
                        }
                    }
                }
            }
        }

        void TowerMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Stroke = Brushes.Red;
            ((Rectangle)sender).StrokeThickness = 2;

            ((Rectangle)sender).RadiusX = 15;
            ((Rectangle)sender).RadiusY = 15;


            for (int index = 0; index < TowerController.Towers.Count; index++)
            {
                if (TowerController.Towers[index].Model == (Rectangle)sender)
                {
                    if (PlayerInterfaceController.TowerSelected != null &&
                        PlayerInterfaceController.TowerSelected != TowerController.Towers[index])
                    {
                        PlayerInterfaceController.TowerSelected.Model.StrokeThickness = 0;
                    }
                    PlayerInterfaceController.TowerSelected = TowerController.Towers[index];

                    this.towerImageFrame.Fill = TowerController.Towers[index].ProfileImage;
                    this.towerImageFrame.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#e07400"));
                    this.towerImageFrame.RadiusY = 5;
                    this.towerImageFrame.RadiusX = 5;
                    this.towerImageFrame.StrokeThickness = 5;

                    return;
                }
            }
        }

        private void SelectionFieldMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle selectionField = (Rectangle)sender;
            selectionField.Stroke = Brushes.Blue;
            selectionField.StrokeThickness = 3;

            switch (selectionField.Name)
            {
                case "SniperTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Sniper;
                    this.FireTowerSelection.StrokeThickness = 0;
                    this.FreezeTowerSelection.StrokeThickness = 0;
                    this.ArrowTowerSelection.StrokeThickness = 0;
                    break;
                case "FireTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Fire;
                    this.SniperTowerSelection.StrokeThickness = 0;
                    this.FreezeTowerSelection.StrokeThickness = 0;
                    this.ArrowTowerSelection.StrokeThickness = 0;
                    break;
                case "FreezeTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Freeze;
                    this.SniperTowerSelection.StrokeThickness = 0;
                    this.ArrowTowerSelection.StrokeThickness = 0;
                    this.FireTowerSelection.StrokeThickness = 0;
                    break;
                case "ArrowTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Arrow;
                    this.SniperTowerSelection.StrokeThickness = 0;
                    this.FireTowerSelection.StrokeThickness = 0;
                    this.FreezeTowerSelection.StrokeThickness = 0;
                    break;
                default:
                    break;
            }
        }

        private void RemoveClickedOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle RemoveButton = (Rectangle)sender;
            RemoveButton.Stroke = Brushes.Sienna;
            RemoveButton.StrokeThickness = 3;
            RemoveButton.RadiusX = 3;
            RemoveButton.RadiusY = 3;
            PlayerInterfaceController.DestroySelectedTower();

        }

        private void RemoveClicekdOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle RemoveButton = (Rectangle)sender;
            RemoveButton.Stroke = Brushes.Transparent;
        }

        private void UpdateClickedOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle UpgradeButton = (Rectangle)sender;
            UpgradeButton.Stroke = Brushes.Sienna;
            UpgradeButton.StrokeThickness = 3;
            UpgradeButton.RadiusX = 3;
            UpgradeButton.RadiusY = 3;
            PlayerInterfaceController.UpgradeSelectedTower();
        }

        private void UpdateClickedOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle UpgradeButton = (Rectangle)sender;
            UpgradeButton.Stroke = Brushes.Transparent;
        }
    }
}
