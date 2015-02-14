using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;

namespace TowerDefenseGame.Models.Towers
{
    class ArrowTower :Tower
    {
        
        private const int TowerSpeed = 10;
        private const int TowerRadius = 400;
        private const string TowerEffect = "ArrowTower";

        public ArrowTower(int x, int y) : base(x, y, 50, 50, ArrowTower.TowerSpeed, ArrowTower.TowerRadius,ArrowTower.TowerEffect, Brushes.LawnGreen)
        {

        }

        
    }
}
