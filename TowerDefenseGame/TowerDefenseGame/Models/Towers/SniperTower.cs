
using System.Windows.Media;
using TowerDefenseGame.Core;

namespace TowerDefenseGame.Models.Towers
{
    class SniperTower :Tower
    {
        private const int Speed = 100;
        private const int Range = 10;

        public SniperTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize,
                SniperTower.Speed, SniperTower.Range, Brushes.Yellow)
        {
        }
    }
}
