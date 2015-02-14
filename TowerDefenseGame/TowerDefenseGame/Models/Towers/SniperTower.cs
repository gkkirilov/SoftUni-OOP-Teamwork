
using System.Windows.Media;

namespace TowerDefenseGame.Models.Towers
{
    class SniperTower :Tower
    {
        private const int TowerSpeed = 2;
        private const int TowerRadius = 1000;
        private const string TowerEffect = "SniperTower";

        public SniperTower(int x, int y)
            : base(x, y, 50, 50, SniperTower.TowerSpeed, SniperTower.TowerRadius, SniperTower.TowerEffect, Brushes.Yellow)
        {

        }
    }
}
