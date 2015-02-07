using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using TowerDefenseGame.Core;

namespace TowerDefenseGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GenerateNextWave();

            Initialize();
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (obj, args) =>
            {
                Engine.Update();
                foreach (var enemy in Engine.Enemies)
                {
                    Canvas.SetTop(enemy.Model, enemy.Coordinates.Y);
                    Canvas.SetLeft(enemy.Model, enemy.Coordinates.X);
                }
            };
            timer.Start();
        }

        private void Initialize()
        {
            for (int row = 0; row < Constants.FieldRows; row++)
            {
                Engine.GameField[row] = new Rectangle[Constants.FieldCols];

                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    Engine.GameField[row][col] = new Rectangle();
                    Engine.GameField[row][col].Stroke = Brushes.White;
                    Engine.GameField[row][col].Fill = Brushes.Black;
                    Engine.GameField[row][col].Width = Constants.FieldRectangeSize;
                    Engine.GameField[row][col].Height = Constants.FieldRectangeSize;

                    // Engine.GameField[row][col].MouseDown += MainWindow_MouseDown;
                    this.MainCanvas.Children.Add(Engine.GameField[row][col]);

                    Canvas.SetTop(Engine.GameField[row][col], Constants.FieldRectangeSize * row);
                    Canvas.SetLeft(Engine.GameField[row][col], Constants.FieldRectangeSize * col);
                }
            }

            Engine.GameField[10][2].Fill = Brushes.Brown;
            Engine.GameField[1][2].Fill = Brushes.Brown;
            Engine.GameField[1][7].Fill = Brushes.Brown;
        }

        public void GenerateNextWave()
        {
            var enemyGeneratorTimer = new DispatcherTimer();
            enemyGeneratorTimer.Interval = TimeSpan.FromMilliseconds(2000);
            enemyGeneratorTimer.Tick += (obj, args) =>
            {
                Engine.GenerateEnemy(Constants.EnemyStartCol * Constants.FieldRectangeSize,
                    Constants.EnemyStartRow * Constants.FieldRectangeSize);

                this.MainCanvas.Children.Add(Engine.Enemies[Engine.Enemies.Count - 1].Model);
                Engine.Enemies[Engine.Enemies.Count - 1].SetBeacons(Constants.GetEnemyBeacons());

                Canvas.SetTop(Engine.Enemies[Engine.Enemies.Count - 1].Model, (double)Engine.Enemies[Engine.Enemies.Count - 1].Coordinates.Y);
                Canvas.SetLeft(Engine.Enemies[Engine.Enemies.Count - 1].Model, (double)Engine.Enemies[Engine.Enemies.Count - 1].Coordinates.X);
            };
            enemyGeneratorTimer.Start();
        }
    }
}
