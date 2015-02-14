
using System.Windows.Media;

namespace TowerDefenseGame.Models.Towers
{
    class SlowTower:Tower
    {
        private const int TowerSpeed = 10;
        private const int TowerRadius = 400;
        private const string TowerEffect = "SlowTower";

        public SlowTower(int x, int y): base(x, y, 50, 50, SlowTower.TowerSpeed, SlowTower.TowerRadius, SlowTower.TowerEffect, Brushes.DeepSkyBlue)
        {

        }
    }
}
