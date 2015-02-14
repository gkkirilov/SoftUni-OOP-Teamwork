using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TowerDefenseGame.Models.Towers
{
    class SplashTower:Tower
    {
        private const int TowerSpeed = 10;
        private const int TowerRadius = 400;
        private const string TowerEffect = "SplashTower";

        public SplashTower(int x, int y): base(x, y, 50, 50, SplashTower.TowerSpeed, SplashTower.TowerRadius, SplashTower.TowerEffect, Brushes.Purple)
        {

        }
    }
}
