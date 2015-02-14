
using System.Windows.Media;
using TowerDefenseGame.Core;

namespace TowerDefenseGame.Models.Towers
{
    class SlowTower:Tower
    {
        private const int Speed = 10;
        private const int Range = 400;

        public SlowTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize,
                SlowTower.Speed, SlowTower.Range, Brushes.DeepSkyBlue)
        {
        }
    }
}
