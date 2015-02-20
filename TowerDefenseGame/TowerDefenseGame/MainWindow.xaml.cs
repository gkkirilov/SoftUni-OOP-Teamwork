namespace TowerDefenseGame
{
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Models.Towers;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Enumerations;
    using TowerDefenseGame.Models;
    using TowerDefenseGame.Resources;

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
                if (selection.Count() > 0)
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
            TowerController.GenerateTower(x, y);
            TowerController.Towers[TowerController.Towers.Count - 1].Model.MouseLeftButtonDown += TowerMouseButtonDown;

        }

        void TowerMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle) sender).Stroke = Brushes.Red;
            ((Rectangle) sender).StrokeThickness = 2;
            ((Rectangle)sender).RadiusX = 15;
            ((Rectangle)sender).RadiusY = 15;

            for (int index = 0; index < TowerController.Towers.Count; index++)
            {
                if (TowerController.Towers[index].Model == (Rectangle)sender)
                {
                    if (PlayerInterfaceController.TowerSelected != null)
                    {
                        PlayerInterfaceController.TowerSelected.Model.StrokeThickness = 0;
                    }

                    PlayerInterfaceController.TowerSelected = TowerController.Towers[index];
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
                    this.SlowTowerSelection.StrokeThickness = 0;
                    this.ArrowTowerSelection.StrokeThickness = 0;
                    break;
                case "FireTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Fire;
                    this.SniperTowerSelection.StrokeThickness = 0;
                    this.SlowTowerSelection.StrokeThickness = 0;
                    this.ArrowTowerSelection.StrokeThickness = 0;
                    break;
                case "SlowTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Slow;
                    this.SniperTowerSelection.StrokeThickness = 0;
                    this.ArrowTowerSelection.StrokeThickness = 0;
                    this.FireTowerSelection.StrokeThickness = 0;
                    break;
                case "ArrowTowerSelection":
                    PlayerInterfaceController.TowerTypeSelected = TowerType.Arrow;
                    this.SniperTowerSelection.StrokeThickness = 0;
                    this.FireTowerSelection.StrokeThickness = 0;
                    this.SlowTowerSelection.StrokeThickness = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
