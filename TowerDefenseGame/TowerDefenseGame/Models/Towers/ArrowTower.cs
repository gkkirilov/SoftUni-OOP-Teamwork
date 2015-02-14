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
using TowerDefenseGame.Core;

namespace TowerDefenseGame.Models.Towers
{
    class ArrowTower : Tower
    {
        private const int Speed = 10;
        private const int Range = 400;

        public ArrowTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, 
                ArrowTower.Speed, ArrowTower.Range, Brushes.LawnGreen)
        {
        }
    }
}
