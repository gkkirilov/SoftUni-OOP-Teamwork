using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TowerDefenseGame.Controllers;
using TowerDefenseGame.Core;
using TowerDefenseGame.Enumerations;
using TowerDefenseGame.Models;
using TowerDefenseGame.Models.Enemies;
using TowerDefenseGame.Models.Projectiles;

namespace TowerDefenseGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Engine engine;

        public MainWindow()
        {
            InitializeComponent();
            engine = new Engine();
            AnimationController.ConfigureRenderer(this.MainCanvas);
            GameFieldController.SetGameFieldEvents(this);
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
                case "CannonTowerSelection":
                    PlayerInterfaceController.TowerSelected = TowerType.Cannon;
                    this.FireTowerSelection.StrokeThickness = 0;
                    break;
                case "FireTowerSelection":
                    PlayerInterfaceController.TowerSelected = TowerType.Fire;
                    this.CannonTowerSelection.StrokeThickness = 0;
                    break;
                default:
                    break;
            }
        }

        public void GameFieldMouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            if (!(sender is Rectangle))
            {
                return;
            }

            Rectangle model = (Rectangle)sender;
            FieldSegment fieldSegment = null;

            for (int col = 0; col < Constants.FieldCols; col++)
            {
                var selection = GameFieldController.GameField.Select(f => f[col]).Where(f => f.Model == model);
                if (selection.Count() > 0)
                {
                    fieldSegment = selection.First();
                    break;
                }
            }

            if (fieldSegment != null && fieldSegment.FieldType == FieldType.Regular)
            {
                double x = Canvas.GetLeft(model);
                double y = Canvas.GetTop(model);

                ProjectileController.Projectiles.Add(new BasicProjectile(x, y)); // To be changed to a tower when it is created
                AnimationController.Renderer.Render(ProjectileController.Projectiles[ProjectileController.Projectiles.Count - 1]);  
            }
        }
    }
}
