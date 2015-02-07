using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace WpfTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int MainGridRows = 6;
        public const int MainGridCols = 10;
        private static Rectangle[][] gameField = new Rectangle[6][];
        private List<Rectangle> movingRectangles = new List<Rectangle>();
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();

            for (int row = 0; row < MainGridRows; row++)
            {
                gameField[row] = new Rectangle[MainGridCols];
                for (int col = 0; col < MainGridCols; col++)
                {
                    gameField[row][col] = new Rectangle();
                    gameField[row][col].Stroke = Brushes.White;
                    gameField[row][col].Fill = Brushes.Black;
                    gameField[row][col].Width = 50;
                    gameField[row][col].Height = 50;

                    gameField[row][col].MouseDown += MainWindow_MouseDown;
                    this.MainCanvas.Children.Add(gameField[row][col]);
                    Canvas.SetTop(gameField[row][col], 50 * row);
                    Canvas.SetLeft(gameField[row][col], 50 * col + 1);
                }
            }

            Rectangle movingRect = new Rectangle();
            movingRect.Width = 10;
            movingRect.Height = 10;
            movingRect.Fill = Brushes.Aqua;

            this.MainCanvas.Children.Add(movingRect);
            Canvas.SetTop(movingRect, 600);
            Canvas.SetLeft(movingRect, 100);
            movingRectangles.Add(movingRect);

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (obj, args) =>
            {
                this.MoveRect();
            };
            timer.Start();
        }

        private void MoveRect()
        {
            for (int i = 0; i < this.movingRectangles.Count; i++)
            {
                Canvas.SetLeft(this.movingRectangles[i], 100 + count);
                count += 5;
            }
        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as Rectangle).Fill == Brushes.Pink)
            {
                (sender as Rectangle).Fill = Brushes.Black;
            }
            else
            {
                (sender as Rectangle).Fill = Brushes.Pink;
            }
        }

        void item_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle rect = new Rectangle();
        }
    }
}
