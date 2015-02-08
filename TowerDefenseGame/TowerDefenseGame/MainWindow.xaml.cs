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
using TowerDefenseGame.Controllers;
using TowerDefenseGame.Core;

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
        }
    }
}
